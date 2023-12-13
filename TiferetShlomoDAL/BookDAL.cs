using Microsoft.EntityFrameworkCore;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class BookDAL : IBookDAL
    {
        private readonly TIFERET_SHLOMOContext _context = new TIFERET_SHLOMOContext();

       
        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
               return _context.Books.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public Book GetBookById(int id)
        {
            try
            {
                return _context.Books.Find(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void AddBook(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public void UpdateBook(Book book)
        {
            try
            {
               _context.Entry(book).State = EntityState.Modified;
               _context.SaveChanges(); 

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void RemoveBook(int id)
        {
            try
            {
                var book = _context.Books.Find(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
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
