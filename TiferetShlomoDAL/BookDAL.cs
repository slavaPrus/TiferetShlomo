using Microsoft.EntityFrameworkCore;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class BookDAL : IBookDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();


        public async Task<List<Book>> GetAllBooks()
        {
            try
            {
                return await _context.Books.ToListAsync();

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllBooks DAL");
                return null;
            }

        }
    public async Task<Book> GetBookById(int id)
        {
            try
            {
                return await _context.Books.FindAsync(id);

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetBookById DAL");
                return null;
                
            }

        }

        public async Task<List<Book>> AddBook(Book book)
        {
            try
            {
                await _context.Books.AddAsync(book);
                _context.SaveChanges();
                return await GetAllBooks();

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddBook DAL");
                return null;
                
            }

        }

        public async Task<Book> UpdateBook(Book book)
        {
            try
            {
                Book b = await _context.Books.FirstOrDefaultAsync(x => x.BookId == book.BookId);
                if (b != null)
                {
                    b.Part = book.Part;
                    b.BookParts = book.BookParts;
                    b.Describe = book.Describe;
                    b.PictureId = book.PictureId;
                    _context.SaveChanges();

                }
                return b;

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateBook DAL");
                return null;
                           }

        }

        public async Task RemoveBook(int id)
        {
            try
            {
                Book book = _context.Books.Find(id);
                _context.Books.Remove(book);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "RemoveBook DAL");
            }

        }

        public async Task<List<Book>> GetBooksByPage(int skipCount, int pageSize)
        {
            try
            {
                // Use your DbContext to query the database for books based on skipCount and pageSize
                List<Book> books = await _context.Books
                    .OrderBy(book => book.BookId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();

                return books;
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetBooksByPage in BookDAL");
                return null; // Propagate the exception to the BL layer for centralized error handling
            }
        }
    }
}
