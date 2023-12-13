using System;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactBL _contactBL; // Inject IContactBL interface here

        public ContactController(IContactBL contactBL)
        {
            _contactBL = contactBL;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            try
            {
                var contacts = _contactBL.GetAllContacts();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            try
            {
                var contact = _contactBL.GetContactById(id);
                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] Contact contact)
        {
            try
            {
                _contactBL.AddContact(contact);
                return CreatedAtAction(nameof(GetContactById), new { id = contact.PersonId }, contact);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] Contact contact)
        {
            try
            {
                if (id != contact.PersonId)
                {
                    return BadRequest("Id mismatch");
                }

                _contactBL.UpdateContact(contact);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveContact(int id)
        {
            try
            {
                _contactBL.RemoveContact(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }
    }
}