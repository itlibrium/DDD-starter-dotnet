using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Contacts.Tags;
using TechnicalStuff.Crud.Api;

namespace MyCompany.Crm.Contacts.Groups.RestApi
{
    [ApiController]
    [Route("/rest/groups/{groupId}/tags")]
    [ApiVersion("1")]
    public class GroupsTagsController : ControllerBase
    {
        private readonly ContactsCrudOperations _operations;

        public GroupsTagsController(ContactsCrudOperations operations) => _operations = operations;

        [HttpGet]
        public IAsyncEnumerable<Tag> Read(Guid groupId) => _operations
            .Read<GroupTag, Tag>(query => query
                .Include(groupTag => groupTag.Tag)
                .Where(groupTag => groupTag.GroupId == groupId)
                .Select(groupTag => groupTag.Tag));
        
        [HttpPut("{tagId}")]
        public Task<NoContentResult> Add(Guid groupId, Guid tagId) => _operations
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
            .ToNoContentResult();

        [HttpDelete("{tagId}")]
        public Task<NoContentResult> Remove(Guid groupId, Guid tagId) => _operations
            .Update<Group>(groupId,
                query => query.Include(group => group.Tags),
                group =>
                {
                    var tagToRemove = group.Tags.FirstOrDefault(tag => tag.TagId == tagId);
                    if (tagToRemove is null)
                        return;
                    group.Tags.Remove(tagToRemove);
                })
            .ToNoContentResult();
    }
}