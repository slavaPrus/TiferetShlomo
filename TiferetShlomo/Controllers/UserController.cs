using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomo.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpGet]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                List<UserDTO> users = await _userBL.GetAllUsers();
                return users;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllUsers Controller");
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> GetUserById(int id)
        {
            try
            {
                UserDTO user = await _userBL.GetUserById(id);
                return user;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetUserById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<UserDTO>> AddUser([FromBody] UserDTO user)
        {
            try
            {
                List<UserDTO> users = await _userBL.AddUser(user);
                return users;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddUser Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<UserDTO> UpdateUser(int id, [FromBody] UserDTO user)
        {
            try
            {
                UserDTO existingUser = await _userBL.UpdateUser(user);
                return existingUser;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateUser Controller");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task RemoveUser(int id)
        {
            try
            {
                await _userBL.RemoveUser(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveUser Controller");
            }
        }
    }
}
 
