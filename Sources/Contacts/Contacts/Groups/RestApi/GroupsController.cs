using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.TechnicalStuff.Crud.Api;
using MyCompany.ECommerce.TechnicalStuff.Crud.Operations;

namespace MyCompany.ECommerce.Contacts.Groups.RestApi;

[ApiController]
[Route("/rest/groups")]
[ApiVersion("1")]
public class GroupsController : ControllerBase
{
    private readonly ContactsCrudOperations _operations;

    public GroupsController(ContactsCrudOperations operations) => _operations = operations;

    [HttpPost]
    public Task<ActionResult<Group>> Create(Group group) => _operations
        .Create<Group>(group)
        .ToCreatedAtActionResult();
        
    [HttpGet("{id}")]
    public Task<ActionResult<Group>> Read(Guid id) => _operations
        .Read<Group>(id)
        .ToOkResult();

    [HttpGet]
    public IAsyncEnumerable<Group> Search(string name = null, int skip = 0, int take = 20) => _operations
        .Read<Group>(query => query
            .Where(group => name == null || group.Name.Contains(name))
            .Skip(skip)
            .Take(take));

    [HttpPut("{id}")]
    public Task<ActionResult<Group>> Update(Guid id, Group group) => _operations
        .Update(id, group)
        .ToOkResult();

    [HttpDelete("{id}")]
    public Task<StatusCodeResult> Delete(Guid id) => _operations
        .Delete<Group>(id, DeletePolicy.Soft)
        .ToStatusCodeResult();
}