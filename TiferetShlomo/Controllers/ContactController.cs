using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomo.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactBL _contactBL;

        public ContactController(IContactBL contactBL)
        {
            _contactBL = contactBL;
        }

        [HttpGet]
        public async Task<List<ContactDTO>> GetAllContacts()
        {
            try
            {
                List<ContactDTO> contacts = await _contactBL.GetAllContacts();
                return contacts;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllContacts Controller");
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<ContactDTO> GetContactById(int id)
        {
            try
            {
                ContactDTO contact = await _contactBL.GetContactById(id);
                return contact;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetContactById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<ContactDTO>> AddContact([FromBody] ContactDTO contact)
        {
            try
            {
                List<ContactDTO> contacts = await _contactBL.AddContact(contact);
                return contacts;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddContact Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<ContactDTO> UpdateContact(int id, [FromBody] ContactDTO contact)
        {
            try
            {
                ContactDTO existingContact = await _contactBL.UpdateContact(contact);
                return existingContact;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateContact Controller");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task RemoveContact(int id)
        {
            try
            {
                await _contactBL.RemoveContact(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveContact Controller");
            }
        }
    }
}
