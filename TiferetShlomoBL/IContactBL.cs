using TiferetShlomoDAL.Models;

namespace TiferetShlomoBL
{
    public interface IContactBL
    {
        void AddContact(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int personId);
        void RemoveContact(int personId);
        void UpdateContact(Contact contact);
    }
}