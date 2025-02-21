using Connektify.Application.IServices;
using Connektify.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connektify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            var contacts = await _contactService.GetContactsAsync();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateContact([FromBody] Contact contact)
        {
            var contactId = await _contactService.CreateContactAsync(contact);
            return CreatedAtAction(nameof(GetContacts), new { id = contactId }, contactId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateContact(int id, [FromBody] Contact contact)
        {
            if (id != contact.ContactId)
                return BadRequest();

            var updatedContactId = await _contactService.UpdateContactAsync(contact);
            return Ok(updatedContactId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContactAsync(id);
            return NoContent();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<Contact>>> FilterContacts([FromQuery] int countryId, [FromQuery] int companyId)
        {
            var filteredContacts = await _contactService.FilterContactsAsync(countryId, companyId);
            return Ok(filteredContacts);
        }
    }
}
