using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

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

        public async Task<List<BookDTO>> GetAllBooks()
        {
            try
            {
                List<Book> books = await _bookDAL.GetAllBooks();

                List<BookDTO> booksDTO = _mapper.Map<List<BookDTO>>(books);

                return booksDTO;

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllBooks BL");
                return null;
            }
        }

        public async Task<BookDTO> GetBookById(int id)
        {
            try
            {
                Book book = await _bookDAL.GetBookById(id);
                BookDTO bookDTO = _mapper.Map<BookDTO>(book);
                return bookDTO;

            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "GetBookById BL");
                return null;
            }
        }

        public async Task<List<BookDTO>> AddBook(BookDTO book)
        {
            try
            {
                Book b = _mapper.Map<Book>(book);
                List<Book> books = await _bookDAL.AddBook(b);

                List<BookDTO> booksDTO = _mapper.Map<List<BookDTO>>(books);

                return booksDTO;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "AddBook BL");
                return null;
            }
        }

        public async Task<BookDTO> UpdateBook(BookDTO book)
        {
            try
            {
                Book b = _mapper.Map<Book>(book);
                Book bUP = await _bookDAL.UpdateBook(b);
                BookDTO btd = _mapper.Map<BookDTO>(bUP);
                return btd;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "UpdateBook BL");
                return null;
            }
        }

        public async Task RemoveBook(int id)
        {
            try
            {
                await _bookDAL.RemoveBook(id);
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "RemoveBook BL");

            }
        }

        public async Task<(List<BookDTO>, bool)> GetBooksByPage(int page)
        {
            try
            {
                int pageSize = 18;
                int skipCount = (page - 1) * pageSize;
                // Retrieve books from the repository based on skipCount and pageSize
                (List<Book> books, bool hasNext) = await _bookDAL.GetBooksByPage(skipCount, pageSize);

                List<BookDTO> booksDTO = _mapper.Map<List<BookDTO>>(books);

                return (booksDTO, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetBooksByPage in BookBL");
                return (null, false); // Propagate the exception to the controller for centralized error handling
            }
        }
        public async Task<(List<BookDTO>, bool)> GetSearchBooksByPage(int page, string str)
        {
            try
            {
                //int pageSize = 16;
                int pageSize = 18;
                int skipCount = (page - 1) * pageSize;
                // Retrieve books from the repository based on skipCount and pageSize
                (List<Book> books, bool hasNext) = await _bookDAL.GetSearchBooksByPage(skipCount, pageSize, str);

                List<BookDTO> booksDTO = _mapper.Map<List<BookDTO>>(books);

                return (booksDTO, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetSearchBooksByPage in BookBL");
                return (null, false); // Propagate the exception to the controller for centralized error handling
            }
        }
        public async Task<(List<BookDTO>, bool)> GetFilterBooksByPage(int page, string str)
        {
            try
            {
                int pageSize = 18;
                int skipCount = (page - 1) * pageSize;

                // Retrieve filtered books from the DAL layer along with the hasNext flag
                (List<Book> filteredBooks, bool hasNext) = await _bookDAL.GetFilterBooksByPage(skipCount, pageSize, str);

                // Map filtered books to DTOs
                List<BookDTO> booksDTO = _mapper.Map<List<BookDTO>>(filteredBooks);

                return (booksDTO, hasNext);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetFilterBooksByPage in BookBL");
                return (null, false); // Propagate the exception to the controller for centralized error handling
            }
        }

    }
}