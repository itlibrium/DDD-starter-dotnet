using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.TechnicalStuff.Crud.Api;
using MyCompany.Crm.TechnicalStuff.Crud.DataAccess;

namespace MyCompany.Crm.Contacts.Companies
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ContactsCrudDao _dao;

        public CompaniesController(ContactsCrudDao dao) => _dao = dao;

        [HttpPost]
        public Task<ActionResult<Company>> Create(Company company)
        {
            company.AddedOn = DateTime.UtcNow;
            company.Address = new Address();
            return _dao
                .Create(company)
                .ToCreatedAtActionResult();
        }

        [HttpGet("{id}")]
        public Task<ActionResult<Company>> Read(Guid id) => _dao
            .Read(id, DefaultIncludes)
            .ToOkResult();

        [HttpGet]
        public IAsyncEnumerable<ListItem> Read(string name = null, int skip = 0, int take = 20) => _dao
            .Read<Company, ListItem>(query => query
                .Apply(ListIncludes)
                .Where(company => name == null || company.Name.Contains(name))
                .Skip(skip)
                .Take(take)
                .Select(ToListItem));

        [HttpPut("{id}")]
        public Task<ActionResult<Company>> Update(Guid id, Company patch) => _dao
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

        [HttpDelete("{id}")]
        public Task<StatusCodeResult> Delete(Guid id) => _dao
            .Delete<Company>(id, DeletePolicy.Soft)
            .ToStatusCodeResult();

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