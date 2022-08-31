using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Contacts.Groups;
using MyCompany.Crm.TechnicalStuff.Crud.Api;

namespace MyCompany.Crm.Contacts.Companies.RestApi
{
    [ApiController]
    [Route("/rest/companies/{companyId}/groups")]
    [ApiVersion("1")]
    public class CompaniesGroupsController : ControllerBase
    {
        private readonly ContactsCrudOperations _operations;

        public CompaniesGroupsController(ContactsCrudOperations operations) => _operations = operations;

        [HttpGet]
        public IAsyncEnumerable<Group> Read(Guid companyId) => _operations
            .Read<CompanyGroup, Group>(query => query
                .Include(companyGroup => companyGroup.Group)
                .Where(companyGroup => companyGroup.CompanyId == companyId)
                .Select(companyGroup => companyGroup.Group));
        
        [HttpPut("{groupId}")]
        public Task<NoContentResult> Add(Guid companyId, Guid groupId) => _operations
            .Update<Company>(companyId,
                query => query.Include(company => company.Groups),
                company =>
                {
                    if (company.Groups.Any(group => group.GroupId == groupId))
                        return;
                    company.Groups.Add(new CompanyGroup
                    {
                        CompanyId = companyId,
                        GroupId = groupId
                    });
                })
            .ToNoContentResult();

        [HttpDelete("{groupId}")]
        public Task<NoContentResult> Remove(Guid companyId, Guid groupId) => _operations
            .Update<Company>(companyId,
                query => query.Include(company => company.Groups),
                company =>
                {
                    var groupToRemove = company.Groups.FirstOrDefault(group => group.GroupId == groupId);
                    if (groupToRemove is null)
                        return;
                    company.Groups.Remove(groupToRemove);
                })
            .ToNoContentResult();
    }
}