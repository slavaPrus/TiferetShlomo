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

        public IEnumerable<MarkDTO> GetAllMarks()
        {
            IEnumerable<Mark> marks = _markDAL.GetAllMarks();

            IEnumerable<MarkDTO> marksDTO = _mapper.Map<IEnumerable<MarkDTO>>(marks);

            return marksDTO;

        }

        public Mark GetMarkById(int id)
        {
            return _markDAL.GetMarkById(id);
        }

        public void AddMark(MarkDTO mark)
        {
            // Perform business logic validations or additional operations if needed
            Mark m = _mapper.Map<Mark>(mark);
            _markDAL.AddMark(m);
        }

        public void UpdateMark(Mark mark)
        {
            // Perform business logic validations or additional operations if needed
            _markDAL.UpdateMark(mark);
        }

        public void RemoveMark(int id)
        {
            // Perform business logic validations or additional operations if needed
            _markDAL.RemoveMark(id);
        }
    }

}

