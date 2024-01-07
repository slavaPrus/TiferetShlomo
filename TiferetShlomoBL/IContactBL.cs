using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IContactBL
    {
        Task<List<ContactDTO>> AddContact(ContactDTO contact);
        Task<List<ContactDTO>> GetAllContacts();
        Task<ContactDTO> GetContactById(int id);
        Task RemoveContact(int id);
        Task<ContactDTO> UpdateContact(ContactDTO contact);
    }
}