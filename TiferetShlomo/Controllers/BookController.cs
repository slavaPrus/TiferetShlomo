using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;
using System;

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
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookBL.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving all books.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var book = _bookBL.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving book with ID {id}.");
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO book)
        {
            try
            {
                _bookBL.AddBook(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, book);
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding a new book.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDTO book)
        {
            try
            {
                if (id != book.BookId)
                {
                    return BadRequest("Invalid ID");
                }

                var existingBook = _bookBL.GetBookById(id);
                if (existingBook == null)
                {
                    return NotFound();
                }

                _bookBL.UpdateBook(book);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating book with ID {id}.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBook(int id)
        {
            try
            {
                var existingBook = _bookBL.GetBookById(id);
                if (existingBook == null)
                {
                    return NotFound();
                }

                _bookBL.RemoveBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or perform necessary error handling
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error removing book with ID {id}.");
            }
        }
    }
}
