using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;

        public UserBL(IUserDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                List<User> users = await _userDAL.GetAllUsers();
                List<UserDTO> usersDTO = _mapper.Map<List<UserDTO>>(users);
                return usersDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllUsers BL");
                return null;
            }
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            try
            {
                User user = await _userDAL.GetUserById(id);
                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetUserById BL");
                return null;
            }
        }

        public async Task<List<UserDTO>> AddUser(UserDTO user)
        {
            try
            {
                User u = _mapper.Map<User>(user);
                List<User> users = await _userDAL.AddUser(u);
                List<UserDTO> usersDTO = _mapper.Map<List<UserDTO>>(users);
                return usersDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddUser BL");
                return null;
            }
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            try
            {
                User u = _mapper.Map<User>(user);
                User updatedUser = await _userDAL.UpdateUser(u);
                UserDTO updatedUserDTO = _mapper.Map<UserDTO>(updatedUser);
                return updatedUserDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateUser BL");
                return null;
            }
        }

        public async Task RemoveUser(int id)
        {
            try
            {
                await _userDAL.RemoveUser(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveUser BL");
            }
        }
        public async Task<UserDTO> AuthenticateUser(UserLoginDTO userDTO)
        {

            if (string.IsNullOrEmpty(userDTO.email) || string.IsNullOrEmpty(userDTO.password))
            {
                return null;
            }

            // Retrieve user from the database based on the email
            User user = await _userDAL.GetUserByEmail(userDTO.email);

            // Check if the user exists and the password matches
            if (user != null && userDTO.password == user.UserPassword)
            {

                UserDTO u = _mapper.Map<UserDTO>(user);
                // Authentication successful
                return u;
            }

            // Authentication failed
            return null;
        }
    }
}

