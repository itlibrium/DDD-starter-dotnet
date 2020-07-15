using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Contacts.Tags;
using MyCompany.Crm.TechnicalStuff.Crud.Api;

namespace MyCompany.Crm.Contacts.Companies
{
    [Route("/api/companies/{companyId}/tags")]
    public class CompaniesTagsController : ControllerBase
    {
        private readonly ContactsCrudDao _dao;

        public CompaniesTagsController(ContactsCrudDao dao) => _dao = dao;

        [HttpGet]
        public IAsyncEnumerable<Tag> Read(Guid companyId) => _dao
            .Read<CompanyTag, Tag>(query => query
                .Include(companyTag => companyTag.Tag)
                .Where(companyTag => companyTag.CompanyId == companyId)
                .Select(companyTag => companyTag.Tag));

        [HttpPut("{tagId}")]
        public Task<NoContentResult> Add(Guid companyId, Guid tagId) => _dao
            .Update<Company>(companyId,
                query => query.Include(company => company.Tags),
                company =>
                {
                    if (company.Tags.Any(tag => tag.TagId == tagId))
                        return;
                    company.Tags.Add(new CompanyTag
                    {
                        CompanyId = companyId,
                        TagId = tagId
                    });
                })
            .ToNoContentResult();

        [HttpDelete("{tagId}")]
        public Task<NoContentResult> Remove(Guid companyId, Guid tagId) => _dao
            .Update<Company>(companyId,
                query => query.Include(company => company.Tags),
                company =>
                {
                    var tagToRemove = company.Tags.FirstOrDefault(tag => tag.TagId == tagId);
                    if (tagToRemove is null)
                        return;
                    company.Tags.Remove(tagToRemove);
                })
            .ToNoContentResult();
    }
}