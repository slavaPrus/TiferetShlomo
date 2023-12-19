using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;

namespace TiferetShlomoBL
{
    public class ContactBL : IContactBL
    {
        private readonly IContactDAL _contactDAL; // Inject the ContactDAL interface here
        private readonly IMapper _mapper;

        public ContactBL(IContactDAL contactDAL, IMapper mapper)
        {
            _contactDAL = contactDAL;
            _mapper = mapper;
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
