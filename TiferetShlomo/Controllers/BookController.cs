using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;
using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace TiferetShlomo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL _bookBL;

        public BookController(IBookBL bookBL)
        {
            _bookBL = bookBL;
        }

        [HttpGet]
        public async Task<List<BookDTO>> GetAllBooks()
        {
            try
            {
                List<BookDTO> books = await _bookBL.GetAllBooks();
                return books;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "GetAllBooks Controller");
                return null;
            }
        }

        [HttpGet("getBooksByPage/{page}")]
        public async Task<List<BookDTO>> GetBooksByPage( int page)
        {
            try
            {
                List<BookDTO> books = await _bookBL.GetBooksByPage(page);
                return books;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "GetBooksByPage Controller");
                return null;
            }
        }

        [HttpGet("GetSearchBooksByPage")]
        public async Task<List<BookDTO>> GetSearchBooksByPage([FromQuery] int page,[FromQuery]string str)
        {
            try
            {
                List<BookDTO> books = await _bookBL.GetSearchBooksByPage(page,str);
                return books;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "GetSearchBooksByPage Controller");
                return null;
            }
        }
        [HttpGet("{id}")]
        public async Task<BookDTO> GetBookById(int id)
        {
            try
            {
                BookDTO book = await _bookBL.GetBookById(id);
                return book;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetBookById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<BookDTO>> AddBook([FromBody] BookDTO book)
        {
            try
            {
                List<BookDTO> books = await _bookBL.AddBook(book);
                return books;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddBook Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<BookDTO> UpdateBook(int id ,[FromBody] BookDTO book)
        {
            try
            {

                BookDTO existingBook = await _bookBL.UpdateBook(book);
                return existingBook;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateBook Controller");
                return null;
            }
        }
        [HttpDelete("{id}")]
        public async Task RemoveBook(int id)
        {
            try
            {
                await _bookBL.RemoveBook(id);

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveBook Controller");

            }
        }
        
    } 
}
