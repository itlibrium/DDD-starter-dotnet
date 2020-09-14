using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.TechnicalStuff.Crud.Api;

namespace MyCompany.Crm.Contacts.Companies.RestApi
{
    [ApiController]
    [Route("/rest/companies/{companyId}/address")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class CompaniesAddressController : ControllerBase
    {
        private readonly ContactsCrudDao _dao;

        public CompaniesAddressController(ContactsCrudDao dao) => _dao = dao;

        [HttpGet]
        [MapToApiVersion("1")]
        public Task<ActionResult<Address>> Read(Guid companyId) => _dao
            .Read<Company, Address>(companyId, query => query
                .Include(c => c.Address)
                .Select(c => c.Address))
            .ToOkResult();

        [HttpPut]
        [MapToApiVersion("1")]
        public Task<ActionResult<Address>> UpdateV1(Guid companyId, AddressV1 addressV1) => _dao
            .Update<Company, Address>(companyId,
                query => query.Include(c => c.Address),
                company => company.Address = MapFrom(addressV1))
            .ToOkResult();

        [HttpPut]
        [MapToApiVersion("2")]
        public Task<ActionResult<Address>> UpdateV2(Guid companyId, Address address) => _dao
            .Update<Company, Address>(companyId,
                query => query.Include(c => c.Address),
                company => company.Address = address)
            .ToOkResult();

        private Address MapFrom(AddressV1 address) => new Address
        {
            Street = GetStreetFrom(address),
            ZipCode = address.ZipCode,
            City = address.City
        };

        private static string GetStreetFrom(AddressV1 address)
        {
            if (string.IsNullOrWhiteSpace(address.Street))
                return null;
            if (string.IsNullOrWhiteSpace(address.HouseNo))
                return address.Street;
            if (string.IsNullOrWhiteSpace(address.ApartmentNo))
                return $"{address.Street} {address.HouseNo}";
            return $"{address.Street} {address.HouseNo} {address.ApartmentNo}";
        }

        public class AddressV1
        {
            public string Street { get; set; }
            public string HouseNo { get; set; }
            public string ApartmentNo { get; set; }
            public string ZipCode { get; set; }
            public string City { get; set; }
        }
    }
}