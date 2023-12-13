using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;

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

        public IEnumerable<BookPart> GetAllBookParts()
        {
            try
            {
                return _bookPartDAL.GetAllBookParts();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public BookPart GetBookPartById(int id)
        {
            try
            {
                return _bookPartDAL.GetBookPartById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddBookPart(BookPart bookPart)
        {
            try
            {
                _bookPartDAL.AddBookPart(bookPart);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateBookPart(BookPart bookPart)
        {
            try
            {
                _bookPartDAL.UpdateBookPart(bookPart);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveBookPart(int id)
        {
            try
            {
                _bookPartDAL.RemoveBookPart(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
