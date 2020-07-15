using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.TechnicalStuff.Crud.Api;

namespace MyCompany.Crm.Contacts.Companies
{
    [ApiController]
    [Route("/api/companies/{companyId}/address")]
    public class CompaniesAddressController : ControllerBase
    {
        private readonly ContactsCrudDao _dao;

        public CompaniesAddressController(ContactsCrudDao dao) => _dao = dao;

        [HttpGet]
        public Task<ActionResult<Address>> Read(Guid companyId) => _dao
            .Read<Company, Address>(companyId, query => query
                .Include(c => c.Address)
                .Select(c => c.Address))
            .ToOkResult();

        [HttpPut]
        public Task<ActionResult<Address>> Update(Guid companyId, Address address) => _dao
            .Update<Company, Address>(companyId,
                query => query.Include(c => c.Address),
                company => company.Address = address)
            .ToOkResult();
    }
}