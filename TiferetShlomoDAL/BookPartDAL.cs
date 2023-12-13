using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class BookPartDAL : IBookPartDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

        public IEnumerable<BookPart> GetAllBookParts()
        {
            try
            {
                return _context.BookParts.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BookPart GetBookPartById(int id)
        {
            try
            {
                return _context.BookParts.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddBookPart(BookPart bookPart)
        {
            try
            {
                _context.BookParts.Add(bookPart);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateBookPart(BookPart bookPart)
        {
            try
            {
                _context.Entry(bookPart).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveBookPart(int id)
        {
            try
            {
                var bookPart = _context.BookParts.Find(id);
                if (bookPart != null)
                {
                    _context.BookParts.Remove(bookPart);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
