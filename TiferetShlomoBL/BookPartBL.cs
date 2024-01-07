using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomoBL
{
    public class BookPartBL : IBookPartBL
    {
        private readonly IBookPartDAL _bookPartDAL;
        private readonly IMapper _mapper;

        public BookPartBL(IBookPartDAL bookPartDAL, IMapper mapper)
        {
            _bookPartDAL = bookPartDAL;
            _mapper = mapper;
        }

        public async Task<List<BookPartDTO>> GetAllBookParts()
        {
            try
            {
                List<BookPart> bookParts = await _bookPartDAL.GetAllBookParts();
                List<BookPartDTO> bookPartsDTO = _mapper.Map<List<BookPartDTO>>(bookParts);
                return bookPartsDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllBookParts BL");
                return null;
            }
        }

        public async Task<BookPartDTO> GetBookPartById(int id)
        {
            try
            {
                BookPart bookPart = await _bookPartDAL.GetBookPartById(id);
                BookPartDTO bookPartDTO = _mapper.Map<BookPartDTO>(bookPart);
                return bookPartDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetBookPartById BL");
                return null;
            }
        }

        public async Task<List<BookPartDTO>> AddBookPart(BookPartDTO bookPart)
        {
            try
            {
                BookPart bp = _mapper.Map<BookPart>(bookPart);
                List<BookPart> bookParts = await _bookPartDAL.AddBookPart(bp);
                List<BookPartDTO> bookPartsDTO = _mapper.Map<List<BookPartDTO>>(bookParts);
                return bookPartsDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddBookPart BL");
                return null;
            }
        }

        public async Task<BookPartDTO> UpdateBookPart(BookPartDTO bookPart)
        {
            try
            {
                BookPart bp = _mapper.Map<BookPart>(bookPart);
                BookPart updatedBookPart = await _bookPartDAL.UpdateBookPart(bp);
                BookPartDTO updatedBookPartDTO = _mapper.Map<BookPartDTO>(updatedBookPart);
                return updatedBookPartDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateBookPart BL");
                return null;
            }
        }

        public async Task RemoveBookPart(int id)
        {
            try
            {
                await _bookPartDAL.RemoveBookPart(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveBookPart BL");
            }
        }
    }
}
