using Microsoft.EntityFrameworkCore;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class BookPartDAL : IBookPartDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

        public async Task<List<BookPart>> GetAllBookParts()
        {
            try
            {
                return await _context.BookParts.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllBookParts DAL");
                return null;
            }
        }

        public async Task<BookPart> GetBookPartById(int id)
        {
            try
            {
                return await _context.BookParts.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetBookPartById DAL");
                return null;
            }
        }

        public async Task<List<BookPart>> AddBookPart(BookPart bookPart)
        {
            try
            {
                await _context.BookParts.AddAsync(bookPart);
                _context.SaveChanges();
                return await GetAllBookParts();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddBookPart DAL");
                return null;
            }
        }

        public async Task<BookPart> UpdateBookPart(BookPart bookPart)
        {
            try
            {
                BookPart bp = await _context.BookParts.FirstOrDefaultAsync(x => x.PartId == bookPart.PartId);
                if (bp != null)
                {
                    bp.BookId = bookPart.BookId;
                    bp.Describe = bookPart.Describe;
                    bp.FilePartUrl = bookPart.FilePartUrl;
                    bp.Cost = bookPart.Cost;
                    bp.FileId = bookPart.FileId;

                    _context.SaveChanges();
                }
                return bp;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateBookPart DAL");
                return null;
            }
        }

        public async Task RemoveBookPart(int id)
        {
            try
            {
                BookPart bookPart = _context.BookParts.Find(id);
                _context.BookParts.Remove(bookPart);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveBookPart DAL");
            }
        }
    }
}
