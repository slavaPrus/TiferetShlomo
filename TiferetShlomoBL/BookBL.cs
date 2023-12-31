using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;

namespace TiferetShlomoBL
{
    public class BookBL : IBookBL
    {
        private readonly IBookDAL _bookDAL;
        private readonly IMapper _mapper;

        public BookBL(IBookDAL bookDAL, IMapper mapper)
        {
            _bookDAL = bookDAL;
            _mapper = mapper;
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            try
            {
                IEnumerable<Book> books = _bookDAL.GetAllBooks();

                IEnumerable<BookDTO> booksDTO = _mapper.Map<IEnumerable<BookDTO>>(books);

                return booksDTO;

            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                throw new Exception("Error fetching all books.", ex);
            }
        }

        public BookDTO GetBookById(int id)
        {
            try
            {
                Book book = _bookDAL.GetBookById(id);
                BookDTO bookDTO = _mapper.Map<BookDTO>(book);
                return bookDTO;
                
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                throw new Exception($"Error fetching book with ID {id}.", ex);
            }
        }

        public void AddBook(BookDTO book)
        {
            try
            {
                Book b = _mapper.Map<Book>(book);
                _bookDAL.AddBook(b);
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                throw new Exception("Error adding a new book.", ex);
            }
        }

        public void UpdateBook(BookDTO book)
        {
            try
            {
                Book b = _mapper.Map<Book>(book);
                _bookDAL.UpdateBook(b);
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                throw new Exception($"Error updating book with ID {book.BookId}.", ex);
            }
        }

        public void RemoveBook(int id)
        {
            try
            {
                _bookDAL.RemoveBook(id);
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                throw new Exception($"Error removing book with ID {id}.", ex);
            }
        }
    }
}
