using Microsoft.AspNetCore.Mvc;

namespace MyCompany.Crm.Contacts
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        // more coming soon
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("test");
        }
    }
}