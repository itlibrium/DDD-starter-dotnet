using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.TechnicalStuff.Crud.Api;
using MyCompany.Crm.TechnicalStuff.Crud.DataAccess;

namespace MyCompany.Crm.Contacts.Groups
{
    [ApiController]
    [Route("/api/groups")]
    public class GroupsController : ControllerBase
    {
        private readonly ContactsCrudDao _dao;

        public GroupsController(ContactsCrudDao dao) => _dao = dao;

        [HttpGet("{id}")]
        public Task<ActionResult<Group>> Read(Guid id) => _dao
            .Read<Group>(id)
            .ToOkResult();

        [HttpGet]
        public IAsyncEnumerable<Group> Read(string name = null, int skip = 0, int take = 20) => _dao
            .Read<Group>(query => query
                .Where(group => name == null || group.Name.Contains(name))
                .Skip(skip)
                .Take(take));

        [HttpPut("{id}")]
        public Task<ActionResult<Group>> Update(Guid id, Group group) => _dao
            .Update(id, group)
            .ToOkResult();

        [HttpDelete("{id}")]
        public Task<StatusCodeResult> Delete(Guid id) => _dao
            .Delete<Group>(id, DeletePolicy.Soft)
            .ToStatusCodeResult();
    }
}