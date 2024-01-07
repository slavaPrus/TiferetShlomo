using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomo.Controllers
{
    [Route("api/bookparts")]
    [ApiController]
    public class BookPartController : ControllerBase
    {
        private readonly IBookPartBL _bookPartBL;

        public BookPartController(IBookPartBL bookPartBL)
        {
            _bookPartBL = bookPartBL;
        }

        [HttpGet]
        public async Task<List<BookPartDTO>> GetAllBookParts()
        {
            try
            {
                List<BookPartDTO> bookParts = await _bookPartBL.GetAllBookParts();
                return bookParts;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllBookParts Controller");
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<BookPartDTO> GetBookPartById(int id)
        {
            try
            {
                BookPartDTO bookPart = await _bookPartBL.GetBookPartById(id);
                return bookPart;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetBookPartById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<BookPartDTO>> AddBookPart([FromBody] BookPartDTO bookPart)
        {
            try
            {
                List<BookPartDTO> bookParts = await _bookPartBL.AddBookPart(bookPart);
                return bookParts;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddBookPart Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<BookPartDTO> UpdateBookPart(int id, [FromBody] BookPartDTO bookPart)
        {
            try
            {
                BookPartDTO existingBookPart = await _bookPartBL.UpdateBookPart(bookPart);
                return existingBookPart;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateBookPart Controller");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task RemoveBookPart(int id)
        {
            try
            {
                await _bookPartBL.RemoveBookPart(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveBookPart Controller");
            }
        }
    }
}
