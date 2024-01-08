using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IUserDAL
    {
        Task<List<User>> AddUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task RemoveUser(int id);
        Task<User> UpdateUser(User user);
    }
}