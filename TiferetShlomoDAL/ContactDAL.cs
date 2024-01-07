using Microsoft.EntityFrameworkCore;
using TiferetShlomoDAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomoDAL
{
    public class ContactDAL : IContactDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

        public async Task<List<Contact>> GetAllContacts()
        {
            try
            {
                return await _context.Contacts.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllContacts DAL");
                return null;
            }
        }

        public async Task<Contact> GetContactById(int id)
        {
            try
            {
                return await _context.Contacts.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetContactById DAL");
                return null;
            }
        }

        public async Task<List<Contact>> AddContact(Contact contact)
        {
            try
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
                return await GetAllContacts();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddContact DAL");
                return null;
            }
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            try
            {
                Contact existingContact = await _context.Contacts.FirstOrDefaultAsync(x => x.PersonId == contact.PersonId);
                if (existingContact != null)
                {
                    existingContact.FirstName = contact.FirstName;
                    existingContact.LastName = contact.LastName;
                    existingContact.Email = contact.Email;
                    // Update other properties as needed
                    await _context.SaveChangesAsync();
                }
                return existingContact;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateContact DAL");
                return null;
            }
        }

        public async Task RemoveContact(int id)
        {
            try
            {
                Contact contact = await _context.Contacts.FindAsync(id);
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveContact DAL");
            }
        }
    }
}
