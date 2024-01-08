using Microsoft.EntityFrameworkCore;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class TsfileDAL : ITsfileDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

        public async Task<List<Tsfile>> GetAllTsfiles()
        {
            try
            {
                return await _context.Tsfiles.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllTsfiles DAL");
                return null;
            }
        }

        public async Task<Tsfile> GetTsfileById(int id)
        {
            try
            {
                return await _context.Tsfiles.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetTsfileById DAL");
                return null;
            }
        }

        public async Task<List<Tsfile>> AddTsfile(Tsfile tsfile)
        {
            try
            {
                await _context.Tsfiles.AddAsync(tsfile);
                _context.SaveChanges();
                return await GetAllTsfiles();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddTsfile DAL");
                return null;
            }
        }

        public async Task<Tsfile> UpdateTsfile(Tsfile tsfile)
        {
            try
            {
                Tsfile t = await _context.Tsfiles.FirstOrDefaultAsync(x => x.FileId == tsfile.FileId);
                if (t != null)
                {
                    t.NameFile = tsfile.NameFile;
                    t.FileData = tsfile.FileData;
                    _context.SaveChanges();
                }
                return t;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateTsfile DAL");
                return null;
            }
        }

        public async Task RemoveTsfile(int id)
        {
            try
            {
                Tsfile tsfile = _context.Tsfiles.Find(id);
                _context.Tsfiles.Remove(tsfile);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveTsfile DAL");
            }
        }
    }
}
