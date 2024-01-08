using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomo.Controllers
{
    [Route("api/mark")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkBL _markBL;


        public MarkController(IMarkBL markBL)
        {
            _markBL = markBL;
        }

        [HttpGet]
        public async Task<List<MarkDTO>> GetAllMarks()
        {
            try
            {
                List<MarkDTO> marks = await _markBL.GetAllMarks();
                return marks;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllMarks Controller");
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<MarkDTO> GetMarkById(int id)
        {
            try
            {
                MarkDTO mark = await _markBL.GetMarkById(id);
                return mark;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetMarkById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<MarkDTO>> AddMark([FromBody] MarkDTO mark)
        {
            try
            {
                List<MarkDTO> marks = await _markBL.AddMark(mark);
                return marks;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddMark Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<MarkDTO> UpdateMark(int id, [FromBody] MarkDTO mark)
        {
            try
            {
                MarkDTO existingMark = await _markBL.UpdateMark( mark);
                return existingMark;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateMark Controller");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task RemoveMark(int id)
        {
            try
            {
                await _markBL.RemoveMark(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveMark Controller");
            }
        }
    }
}