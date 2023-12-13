using System;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookPartController : ControllerBase
    {
        private readonly IBookPartBL _bookPartBL; // Inject BookPartBL interface here

        public BookPartController(IBookPartBL bookPartBL)
        {
            _bookPartBL = bookPartBL;
        }

        [HttpGet]
        public IActionResult GetAllBookParts()
        {
            try
            {
                var bookParts = _bookPartBL.GetAllBookParts();
                return Ok(bookParts);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBookPartById(int id)
        {
            try
            {
                var bookPart = _bookPartBL.GetBookPartById(id);
                if (bookPart == null)
                {
                    return NotFound();
                }

                return Ok(bookPart);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult AddBookPart([FromBody] BookPart bookPart)
        {
            try
            {
                _bookPartBL.AddBookPart(bookPart);
                return CreatedAtAction(nameof(GetBookPartById), new { id = bookPart.PartId }, bookPart);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookPart(int id, [FromBody] BookPart bookPart)
        {
            try
            {
                if (id != bookPart.PartId)
                {
                    return BadRequest("Id mismatch");
                }

                _bookPartBL.UpdateBookPart(bookPart);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBookPart(int id)
        {
            try
            {
                _bookPartBL.RemoveBookPart(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
