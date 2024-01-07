using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomoBL
{
    public class ContactBL : IContactBL
    {
        private readonly IContactDAL _contactDAL;
        private readonly IMapper _mapper;

        public ContactBL(IContactDAL contactDAL, IMapper mapper)
        {
            _contactDAL = contactDAL;
            _mapper = mapper;
        }

        public async Task<List<ContactDTO>> GetAllContacts()
        {
            try
            {
                List<Contact> contacts = await _contactDAL.GetAllContacts();
                List<ContactDTO> contactsDTO = _mapper.Map<List<ContactDTO>>(contacts);
                return contactsDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllContacts BL");
                return null;
            }
        }

        public async Task<ContactDTO> GetContactById(int id)
        {
            try
            {
                Contact contact = await _contactDAL.GetContactById(id);
                ContactDTO contactDTO = _mapper.Map<ContactDTO>(contact);
                return contactDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetContactById BL");
                return null;
            }
        }

        public async Task<List<ContactDTO>> AddContact(ContactDTO contact)
        {
            try
            {
                Contact c = _mapper.Map<Contact>(contact);
                List<Contact> contacts = await _contactDAL.AddContact(c);
                List<ContactDTO> contactsDTO = _mapper.Map<List<ContactDTO>>(contacts);
                return contactsDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddContact BL");
                return null;
            }
        }

        public async Task<ContactDTO> UpdateContact(ContactDTO contact)
        {
            try
            {
                Contact c = _mapper.Map<Contact>(contact);
                Contact updatedContact = await _contactDAL.UpdateContact(c);
                ContactDTO updatedContactDTO = _mapper.Map<ContactDTO>(updatedContact);
                return updatedContactDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateContact BL");
                return null;
            }
        }

        public async Task RemoveContact(int id)
        {
            try
            {
                await _contactDAL.RemoveContact(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveContact BL");
            }
        }
    }
}
