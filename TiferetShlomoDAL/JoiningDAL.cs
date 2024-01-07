using Microsoft.EntityFrameworkCore;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class JoiningDAL : IJoiningDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

        public async Task<List<Joining>> GetAllJoinings()
        {
            try
            {
                return await _context.Joinings.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllJoinings DAL");
                return null;
            }
        }

        public async Task<Joining> GetJoiningById(int id)
        {
            try
            {
                return await _context.Joinings.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetJoiningById DAL");
                return null;
            }
        }

        public async Task<List<Joining>> AddJoining(Joining joining)
        {
            try
            {
                await _context.Joinings.AddAsync(joining);
                await _context.SaveChangesAsync();
                return await GetAllJoinings();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddJoining DAL");
                return null;
            }
        }

        public async Task<Joining> UpdateJoining(Joining joining)
        {
            try
            {
                Joining j = await _context.Joinings.FirstOrDefaultAsync(x => x.JoinId == joining.JoinId);
                if (j != null)
                {
                    j.Phone = joining.Phone;
                    j.Email = joining.Email;
                    j.CategoryId = joining.CategoryId;
                    _context.SaveChanges();
                }
                return j;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateJoining DAL");
                return null;
            }
        }

        public async Task RemoveJoining(int id)
        {
            try
            {
                Joining joining = _context.Joinings.Find(id);
                _context.Joinings.Remove(joining);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveJoining DAL");
            }
        }
    }
}
