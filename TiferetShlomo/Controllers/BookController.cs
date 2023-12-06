using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;

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
            var books = _bookBL.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookBL.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookBL.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
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

        [HttpDelete("{id}")]
        public IActionResult RemoveBook(int id)
        {
            var existingBook = _bookBL.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            _bookBL.RemoveBook(id);
            return NoContent();
        }
    }


}
