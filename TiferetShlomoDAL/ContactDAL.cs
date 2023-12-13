using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class ContactDAL : IContactDAL
    {
        private readonly TIFERET_SHLOMOContext _context;

        public ContactDAL(TIFERET_SHLOMOContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                return _context.Contacts.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contact GetContactById(int personId)
        {
            try
            {
                return _context.Contacts.FirstOrDefault(c => c.PersonId == personId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddContact(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                _context.Contacts.Update(contact);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveContact(int personId)
        {
            try
            {
                var contact = _context.Contacts.FirstOrDefault(c => c.PersonId == personId);
                if (contact != null)
                {
                    _context.Contacts.Remove(contact);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
