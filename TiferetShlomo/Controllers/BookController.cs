﻿using Microsoft.AspNetCore.Http;
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
                (List<BookDTO> books, bool hasNext) = await _bookBL.GetBooksByPage(page);
                if (!hasNext)
                {
                    books.Add(null);
                }

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
                (List<BookDTO> books, bool hasNext) = await _bookBL.GetSearchBooksByPage(page, str);
                if (!hasNext)
                {
                    books.Add(null);
                }
                return books;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString(), "GetSearchBooksByPage Controller");
                return null;
            }
        }
        [HttpGet("GetFilterBooksByPage")]
        public async Task<List<BookDTO>> GetFilterBooksByPage([FromQuery] int page, [FromQuery] string str)
        {
            try
            {
                // Call the BL layer function to retrieve filtered books
                (List<BookDTO> filteredBooks, bool hasNext) = await _bookBL.GetFilterBooksByPage(page, str);

                // Add a null book at the end if hasNext is false
                if (!hasNext)
                {
                    filteredBooks.Add(null);
                }
                return filteredBooks;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetFilterBooksByPage Controller");
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
        public async Task<BookDTO> UpdateBook([FromBody] BookDTO book)
        {
            try
            {

                BookDTO existingBook = await _bookBL.UpdateBook(book);
                return existingBook;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "UpdateBook Controller");
                return null;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveBook(int id)
        {
            try
            {
                await _bookBL.RemoveBook(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveBook Controller");
                return StatusCode(500, "error server");
            }
        }
        
    } 
}
