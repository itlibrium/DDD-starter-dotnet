using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.TechnicalStuff.Crud.Operations;
using TechnicalStuff.Crud.Api;

namespace MyCompany.Crm.Contacts.Companies.OldApi
{
    [ApiController]
    [Route("/api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ContactsCrudOperations _operations;

        public CompaniesController(ContactsCrudOperations operations) => _operations = operations;

        [HttpPost("create")]
        public Task<ActionResult<Company>> Create(Company company)
        {
            company.AddedOn = DateTime.UtcNow;
            company.Address = new Address();
            return _operations
                .Create(company)
                .ToOkResult();
        }

        [HttpGet("get")]
        public Task<ActionResult<Company>> Get(Guid id) => _operations
            .Read(id, DefaultIncludes)
            .ToOkResult();

        [HttpGet("search")]
        public IAsyncEnumerable<ListItem> Search(string name = null, int skip = 0, int take = 20) => _operations
            .Read<Company, ListItem>(query => query
                .Apply(ListIncludes)
                .Where(company => name == null || company.Name.Contains(name))
                .Skip(skip)
                .Take(take)
                .Select(ToListItem));

        [HttpPost("update")]
        public Task<ActionResult<Company>> Update(Guid id, Company patch) => _operations
            .Update<Company>(id, DefaultIncludes, company =>
            {
                //Custom action is needed to replace Phones collection.
                //If patch is passed to the ORM then all Phones are treated as new items and inserted to the database.
                //    This behavior does not match the semantics of the PUT request.
                //To merge two collections you can use JSON Patch.
                //To add or remove single entry you can use separate resource (like for Company's Groups or Tags).
                company.Name = patch.Name;
                company.Phones.Clear();
                company.Phones.AddRange(patch.Phones);
                return company;
            })
            .ToOkResult();

        [HttpPost("delete")]
        public Task<OkResult> Delete(Guid id) => _operations
            .Delete<Company>(id, DeletePolicy.Soft)
            .ToOkResult();
        
        [HttpPost("set-address")]
        public Task<ActionResult<Address>> SetAddress(Guid companyId, Address address) => _operations
            .Update<Company, Address>(companyId,
                query => query.Include(c => c.Address),
                company => company.Address = address)
            .ToOkResult();
        
        [HttpPost("add-group")]
        public Task<OkResult> AddGroup(Guid companyId, Guid groupId) => _operations
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
            .ToOkResult();

        [HttpPost("remove-group")]
        public Task<OkResult> RemoveGroup(Guid companyId, Guid groupId) => _operations
            .Update<Company>(companyId,
                query => query.Include(company => company.Groups),
                company =>
                {
                    var groupToRemove = company.Groups.FirstOrDefault(group => group.GroupId == groupId);
                    if (groupToRemove is null)
                        return;
                    company.Groups.Remove(groupToRemove);
                })
            .ToOkResult();
        
        [HttpPost("add-tag")]
        public Task<OkResult> AddTag(Guid companyId, Guid tagId) => _operations
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
            .ToOkResult();

        [HttpPost("remove-tag")]
        public Task<OkResult> RemoveTag(Guid companyId, Guid tagId) => _operations
            .Update<Company>(companyId,
                query => query.Include(company => company.Tags),
                company =>
                {
                    var tagToRemove = company.Tags.FirstOrDefault(tag => tag.TagId == tagId);
                    if (tagToRemove is null)
                        return;
                    company.Tags.Remove(tagToRemove);
                })
            .ToOkResult();

        private static readonly QueryConfig<Company> DefaultIncludes = query => query
            .Include(company => company.Phones);

        private static readonly QueryConfig<Company> ListIncludes = query => query
            .Include(company => company.Phones)
            .Include(company => company.Tags)
            .ThenInclude(companyTag => companyTag.Tag);

        private static readonly Expression<Func<Company, ListItem>> ToListItem = company => new ListItem(
            company.Id,
            company.Name,
            company.Phones.Select(phone => phone.Number),
            company.Tags.Select(companyTag => companyTag.Tag.Name));

        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public readonly struct ListItem
        {
            public Guid Id { get; }
            public string Name { get; }
            public IEnumerable<string> Phones { get; }
            public IEnumerable<string> Tags { get; }

            public ListItem(Guid id, string name, IEnumerable<string> phones, IEnumerable<string> tags)
            {
                Id = id;
                Name = name;
                Phones = phones;
                Tags = tags;
            }
        }
    }
}