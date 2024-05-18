using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.TechnicalStuff.Crud.Api;
using MyCompany.ECommerce.TechnicalStuff.Crud.Operations;

namespace MyCompany.ECommerce.Contacts.Tags.RestApi;

[ApiController]
[Route("/rets/tags")]
[ApiVersion("1")]
public class TagsController : ControllerBase
{
    private readonly ContactsCrudOperations _operations;

    public TagsController(ContactsCrudOperations operations) => _operations = operations;

    [HttpPost]
    public Task<ActionResult<Tag>> Create(Tag tag) => _operations
        .Create(tag)
        .ToCreatedAtActionResult();
        
    [HttpGet("{id}")]
    public Task<ActionResult<Tag>> Read(Guid id) => _operations
        .Read<Tag>(id)
        .ToOkResult();

    [HttpGet]
    public IAsyncEnumerable<Tag> Search(string name = null, int skip = 0, int take = 20) => _operations
        .Read<Tag>(query => query
            .Where(tag => name == null || tag.Name.Contains(name))
            .Skip(skip)
            .Take(take));

    [HttpPut("{id}")]
    public Task<ActionResult<Tag>> Update(Guid id, Tag tag) => _operations
        .Update(id, tag)
        .ToOkResult();

    [HttpDelete("{id}")]
    public Task<StatusCodeResult> Delete(Guid id) => _operations
        .Delete<Tag>(id, DeletePolicy.Hard)
        .ToStatusCodeResult();
}