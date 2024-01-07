using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IContactDAL
    {
        Task<List<Contact>> AddContact(Contact contact);
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
        Task RemoveContact(int id);
        Task<Contact> UpdateContact(Contact contact);
    }
}