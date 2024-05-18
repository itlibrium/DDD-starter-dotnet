using System.Linq.Expressions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.ECommerce.TechnicalStuff.Crud.Api;
using MyCompany.ECommerce.TechnicalStuff.Crud.Operations;

namespace MyCompany.ECommerce.Contacts.Companies.RestApi;

[ApiController]
[Route("rest/companies")]
[ApiVersion("1")]
[ApiVersion("2")]
public class CompaniesController : ControllerBase
{
    private readonly ContactsCrudOperations _operations;

    public CompaniesController(ContactsCrudOperations operations) => _operations = operations;

    [HttpPost]
    [MapToApiVersion("1")]
    public Task<ActionResult<Company>> Create(Company company)
    {
        company.AddedOn = DateTime.UtcNow;
        company.Address = new Address();
        return _operations
            .Create(company)
            .ToCreatedAtActionResult();
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1")]
    public Task<ActionResult<Company>> Read(Guid id) => _operations
        .Read(id, DefaultIncludes)
        .ToOkResult();

    [HttpGet]
    [MapToApiVersion("1")]
    public IAsyncEnumerable<ListItem> SearchV1(string name = null, int skip = 0, int take = 20) => _operations
        .Read<Company, ListItem>(query => query
            .Apply(ListIncludes)
            .Where(company => name == null || company.Name.Contains(name))
            .Skip(skip)
            .Take(take)
            .Select(ToListItem));
        
    [HttpGet]
    [MapToApiVersion("2")]
    public IAsyncEnumerable<ListItem> SearchV2(string query = null, int page = 1, int pageSize = 20)
    {
        // TODO: search using full text search in postgresql
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    [MapToApiVersion("1")]
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

    [HttpDelete("{id}")]
    [MapToApiVersion("1")]
    public Task<StatusCodeResult> Delete(Guid id) => _operations
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