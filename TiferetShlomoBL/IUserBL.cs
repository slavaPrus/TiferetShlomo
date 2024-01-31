using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IUserBL
    {
        Task<List<UserDTO>> AddUser(UserDTO user);
        Task<UserDTO> AuthenticateUser(UserLoginDTO userDTO);
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(int id);
        Task RemoveUser(int id);
        Task<UserDTO> UpdateUser(UserDTO user);
    }
}