using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.TechnicalStuff.Crud.Api;
using MyCompany.Crm.TechnicalStuff.Crud.Operations;

namespace MyCompany.Crm.Contacts.Tags.OldApi
{
    [ApiController]
    [Route("/api/tags")]
    public class TagsController : ControllerBase
    {
        private readonly ContactsCrudOperations _operations;

        public TagsController(ContactsCrudOperations operations) => _operations = operations;

        [HttpPost("create")]
        public Task<ActionResult<Tag>> Create(Tag tag) => _operations
            .Create(tag)
            .ToOkResult();
        
        [HttpGet("get")]
        public Task<ActionResult<Tag>> Get(Guid id) => _operations
            .Read<Tag>(id)
            .ToOkResult();

        [HttpGet("search")]
        public IAsyncEnumerable<Tag> Search(string name = null, int skip = 0, int take = 20) => _operations
            .Read<Tag>(query => query
                .Where(tag => name == null || tag.Name.Contains(name))
                .Skip(skip)
                .Take(take));

        [HttpPost("update")]
        public Task<ActionResult<Tag>> Update(Guid id, Tag tag) => _operations
            .Update(id, tag)
            .ToOkResult();

        [HttpPost("delete")]
        public Task<OkResult> Delete(Guid id) => _operations
            .Delete<Tag>(id, DeletePolicy.Hard)
            .ToOkResult();
    }
}