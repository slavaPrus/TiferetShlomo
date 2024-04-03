using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;


namespace TiferetShlomoBL
{
    public class MarkBL : IMarkBL
    {
        private readonly IMarkDAL _markDAL;
        private readonly IMapper _mapper;


        public MarkBL(IMarkDAL markDAL, IMapper mapper)
        {
            _markDAL = markDAL;
            _mapper = mapper;
        }

        public async Task<List<MarkDTO>> GetAllMarks()
        {
            try
            {
                List<Mark> marks = await _markDAL.GetAllMarks();
                List<MarkDTO> marksDTO = _mapper.Map<List<MarkDTO>>(marks);
                return marksDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetAllMarks BL");
                return null;
            }
        }

        public async Task<List<MarkDTO>> GetMarksByUserId(int id)
        {
            try
            {
                List<Mark> marks = await _markDAL.GetMarksByUserId(id);
                List<MarkDTO> marksDTO = _mapper.Map<List<MarkDTO>>(marks);
                return marksDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetMarkById BL");
                return null;
            }
        }

        public async Task<List<MarkDTO>> AddMark(MarkDTO mark)
        {
            try
            {
                Mark m = _mapper.Map<Mark>(mark);
                List<Mark> marks = await _markDAL.AddMark(m);
                List<MarkDTO> marksDTO = _mapper.Map<List<MarkDTO>>(marks);
                return marksDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "AddMark BL");
                return null;
            }
        }

        public async Task<MarkDTO> UpdateMark(MarkDTO mark)
        {
            try
            {
                Mark markEntity = _mapper.Map<Mark>(mark);
                Mark updatedMark = await _markDAL.UpdateMark(markEntity);
                MarkDTO updatedMarkDTO = _mapper.Map<MarkDTO>(updatedMark);
                return updatedMarkDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateMark BL");
                return null;
            }
        }

        public async Task RemoveMark(int id)
        {
            try
            {
                await _markDAL.RemoveMark(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "RemoveMark BL");
            }
        }
    }
}

