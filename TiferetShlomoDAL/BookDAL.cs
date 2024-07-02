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
                    b.Describe = book.Describe;
                    //b.PictureData = book.PictureData;
                    b.BookUrl = book.BookUrl;
                    b.Cost = book.Cost;
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

        public async Task<(List<Book>, bool)> GetBooksByPage(int skipCount, int pageSize)
        {
            try
            {
                // Use your DbContext to query the database for books based on skipCount and pageSize
                List<Book> books = await _context.Books
                    .OrderBy(book => book.BookId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();
                int totalCount = await _context.Books
                .CountAsync();

                // Calculate if there are more books available based on pagination parameters and total count
                bool hasNext = skipCount + pageSize < totalCount;

                return (books, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetBooksByPage in BookDAL");
                return (null, false); // Propagate the exception to the BL layer for centralized error handling
            }
        }
        public async Task<(List<Book>, bool)> GetSearchBooksByPage(int skipCount, int pageSize, string str)
        {
            try
            {
                // Use your DbContext to query the database for books based on skipCount and pageSize
                List<Book> books = await _context.Books
                    .Where(book => book.BookName.Contains(str)) // search for books based on the bookname property
                    .OrderBy(book => book.BookId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();
                int totalCount = await _context.Books
                   .Where(book => book.BookName.Contains(str))
                   .CountAsync();

                // Calculate if there are more books available based on pagination parameters and total count
                bool hasNext = skipCount + pageSize < totalCount;

                return (books, hasNext);

                return (books, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetSearchBooksByPage in BookDAL");
                return (null, false); // Propagate the exception to the BL layer for centralized error handling
            }
        }
        public async Task<(List<Book>, bool)> GetFilterBooksByPage(int skipCount, int pageSize, string str)
        {
            try
            {
                // Retrieve filtered books from the repository based on category and pagination parameters
                List<Book> books = await _context.Books
                    .Where(book => book.Category == str) // Filter books based on category
                    .OrderBy(book => book.BookId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();

                // Calculate total count of books for the given filter criteria
                int totalCount = await _context.Books
                    .Where(book => book.Category == str)
                    .CountAsync();

                // Calculate if there are more books available based on pagination parameters and total count
                bool hasNext = skipCount + pageSize < totalCount;

                return (books, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetFilterBooksByPage in BookDAL");
                return (null, false); // Propagate the exception to the BL layer for centralized error handling
            }
        }

    }
}
