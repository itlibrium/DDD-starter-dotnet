using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Contacts.Tags;
using MyCompany.Crm.TechnicalStuff.Crud.Api;

namespace MyCompany.Crm.Contacts.Groups
{
    [Route("/api/groups/{groupId}/tags")]
    public class GroupsTagsController : ControllerBase
    {
        private readonly ContactsCrudDao _dao;

        public GroupsTagsController(ContactsCrudDao dao) => _dao = dao;

        [HttpGet]
        public IAsyncEnumerable<Tag> Read(Guid groupId) => _dao
            .Read<GroupTag, Tag>(query => query
                .Include(groupTag => groupTag.Tag)
                .Where(groupTag => groupTag.GroupId == groupId)
                .Select(groupTag => groupTag.Tag));
        
        [HttpPut("{tagId}")]
        public Task<NoContentResult> Add(Guid groupId, Guid tagId) => _dao
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
        public Task<NoContentResult> Remove(Guid groupId, Guid tagId) => _dao
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