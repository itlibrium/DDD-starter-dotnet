using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.ECommerce.TechnicalStuff.Crud.Api;
using MyCompany.ECommerce.TechnicalStuff.Crud.Operations;

namespace MyCompany.ECommerce.Contacts.Groups.OldApi;

[ApiController]
[Route("/api/groups")]
public class GroupsController : ControllerBase
{
    private readonly ContactsCrudOperations _operations;

    public GroupsController(ContactsCrudOperations operations) => _operations = operations;

    [HttpGet("get")]
    public Task<ActionResult<Group>> Get(Guid id) => _operations
        .Read<Group>(id, query => query
            .Include(group => group.Tags))
        .ToOkResult();

    [HttpGet("search")]
    public IAsyncEnumerable<Group> Search(string name = null, int skip = 0, int take = 20) => _operations
        .Read<Group>(query => query
            .Include(group => group.Tags)
            .Where(group => name == null || group.Name.Contains(name))
            .Skip(skip)
            .Take(take));

    [HttpPost("update")]
    public Task<ActionResult<Group>> Update(Guid id, Group group) => _operations
        .Update(id, group)
        .ToOkResult();

    [HttpPost("delete")]
    public Task<OkResult> Delete(Guid id) => _operations
        .Delete<Group>(id, DeletePolicy.Soft)
        .ToOkResult();
        
    [HttpPost("add-tag")]
    public Task<OkResult> AddTag(Guid groupId, Guid tagId) => _operations
        .Update<Group>(groupId,
            query => query.Include(group => group.Tags),
            group =>
            {
                if (group.Tags.Any(tag => tag.TagId == tagId))
                    return;
                group.Tags.Add(new GroupTag
                {
                    GroupId = groupId,
                    TagId = tagId
                });
            })
        .ToOkResult();

    [HttpPost("remove-tag")]
    public Task<OkResult> RemoveTag(Guid groupId, Guid tagId) => _operations
        .Update<Group>(groupId,
            query => query.Include(group => group.Tags),
            group =>
            {
                var tagToRemove = group.Tags.FirstOrDefault(tag => tag.TagId == tagId);
                if (tagToRemove is null)
                    return;
                group.Tags.Remove(tagToRemove);
            })
        .ToOkResult();
}