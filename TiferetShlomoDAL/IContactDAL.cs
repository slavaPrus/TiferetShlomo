using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IContactDAL
    {
        void AddContact(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int personId);
        void RemoveContact(int personId);
        void UpdateContact(Contact contact);
    }
}