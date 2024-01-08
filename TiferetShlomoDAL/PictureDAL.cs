using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class PictureDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();
        public async Task<List<Picture>> GetAllPictures()
        {
            try
            {
                return await _context.Pictures.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllPictures DAL");
                return null;
            }
        }

        public async Task<Picture> GetPictureById(int id)
        {
            try
            {
                return await _context.Pictures.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetPictureById DAL");
                return null;
            }
        }

        public async Task<List<Picture>> AddPicture(Picture picture)
        {
            try
            {
                await _context.Pictures.AddAsync(picture);
                await _context.SaveChangesAsync();
                return await GetAllPictures();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddPicture DAL");
                return null;
            }
        }

        public async Task<Picture> UpdatePicture(Picture picture)
        {
            try
            {
                Picture p = await _context.Pictures.FirstOrDefaultAsync(x => x.PictureId == picture.PictureId);
                if (p != null)
                {
                    p.PictureName = picture.PictureName;
                    p.PictureData = picture.PictureData;
                    // Update other properties as needed

                    await _context.SaveChangesAsync();
                }
                return p;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdatePicture DAL");
                return null;
            }
        }

        public async Task RemovePicture(int id)
        {
            try
            {
                Picture picture = await _context.Pictures.FindAsync(id);
                if (picture != null)
                {
                    _context.Pictures.Remove(picture);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemovePicture DAL");
            }
        }
    }
}