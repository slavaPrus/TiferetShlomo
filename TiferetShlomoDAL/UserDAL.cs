using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class UserDAL : IUserDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllUsers DAL");
                return null;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetUserById DAL");
                return null;
            }
        }

        public async Task<List<User>> AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                _context.SaveChanges();
                return await GetAllUsers();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddUser DAL");
                return null;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                User u = await _context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId);
                if (u != null)
                {
                    u.FirstName = user.FirstName;
                    u.LastName = user.LastName;
                    u.Phone = user.Phone;
                    u.Email = user.Email;
                    u.UserPassword = user.UserPassword;
                    u.UserType = user.UserType;
                    // Other properties assignment if needed

                    _context.SaveChanges();
                }
                return u;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateUser DAL");
                return null;
            }
        }

        public async Task RemoveUser(int id)
        {
            try
            {
                User user = _context.Users.Find(id);
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveUser DAL");
            }
        }


        public async Task<User> GetUserByEmail(string email)
        {
            // Assuming you have a DbSet<User> in your DbContext
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}

