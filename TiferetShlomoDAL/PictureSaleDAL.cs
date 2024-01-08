using Microsoft.EntityFrameworkCore;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class PictureSaleDAL : IPictureSaleDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

        public async Task<List<PictureSale>> GetAllPictureSales()
        {
            try
            {
                return await _context.PictureSales.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllPictureSales DAL");
                return null;
            }
        }

        public async Task<PictureSale> GetPictureSaleById(int id)
        {
            try
            {
                return await _context.PictureSales.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetPictureSaleById DAL");
                return null;
            }
        }

        public async Task<List<PictureSale>> AddPictureSale(PictureSale pictureSale)
        {
            try
            {
                await _context.PictureSales.AddAsync(pictureSale);
                _context.SaveChanges();
                return await GetAllPictureSales();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddPictureSale DAL");
                return null;
            }
        }

        public async Task<PictureSale> UpdatePictureSale(PictureSale pictureSale)
        {
            try
            {
                PictureSale ps = await _context.PictureSales.FirstOrDefaultAsync(x => x.PictureSaleId == pictureSale.PictureSaleId);
                if (ps != null)
                {
                    ps.PictureSaleName = pictureSale.PictureSaleName;
                    ps.Describe = pictureSale.Describe;
                    ps.PictureUrl = pictureSale.PictureUrl;
                    ps.PictureId = pictureSale.PictureId;
                    _context.SaveChanges();
                }
                return ps;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdatePictureSale DAL");
                return null;
            }
        }

        public async Task RemovePictureSale(int id)
        {
            try
            {
                PictureSale pictureSale = _context.PictureSales.Find(id);
                _context.PictureSales.Remove(pictureSale);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemovePictureSale DAL");
            }
        }
    }
}
