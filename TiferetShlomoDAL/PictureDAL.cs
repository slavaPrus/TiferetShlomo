using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class PictureDAL : IPictureDAL
    {
        private readonly TIFERET_SHLOMOContext _context;

        public PictureDAL(TIFERET_SHLOMOContext context)
        {
            _context = context;
        }

        public IEnumerable<Picture> GetAllPictures()
        {
            return _context.Pictures.ToList();
        }

        public Picture GetPictureById(int id)
        {
            return _context.Pictures.Find(id);
        }

        public void AddPicture(Picture picture)
        {
            _context.Pictures.Add(picture);
            _context.SaveChanges();
        }

        public void UpdatePicture(Picture picture)
        {
            _context.Entry(picture).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemovePicture(int id)
        {
            var picture = _context.Pictures.Find(id);
            if (picture != null)
            {
                _context.Pictures.Remove(picture);
                _context.SaveChanges();
            }
        }
    }
}
