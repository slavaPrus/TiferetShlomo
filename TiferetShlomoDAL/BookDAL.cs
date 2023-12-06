using Microsoft.EntityFrameworkCore;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class BookDAL : IBookDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

       
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
