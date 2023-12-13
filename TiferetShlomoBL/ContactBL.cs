using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;

namespace TiferetShlomoBL
{
    public class ContactBL : IContactBL
    {
        private readonly IContactDAL _contactDAL; // Inject the ContactDAL interface here

        public ContactBL(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                return _contactDAL.GetAllContacts();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public Contact GetContactById(int personId)
        {
            try
            {
                return _contactDAL.GetContactById(personId);
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
                _contactDAL.AddContact(contact);
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
                _contactDAL.UpdateContact(contact);
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
                _contactDAL.RemoveContact(personId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
