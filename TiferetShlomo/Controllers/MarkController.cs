using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkBL _markBL;

        public MarkController(IMarkBL markBL)
        {
            _markBL = markBL;
        }

        // GET: api/Mark
        [HttpGet]
        public IEnumerable<MarkDTO> GetAllMarks()
        {
            return _markBL.GetAllMarks();
        }

        // GET: api/Mark/5
        [HttpGet("{id}")]
        public ActionResult<MarkDTO> GetMarkById(int id)
        {
            var mark = _markBL.GetMarkById(id);
            if (mark == null)
            {
                return NotFound();
            }
            return mark;
        }

        // POST: api/Mark
        [HttpPost]
        public IActionResult AddMark(MarkDTO mark)
        {
            _markBL.AddMark(mark);
            return CreatedAtAction(nameof(GetMarkById), new { id = mark.MarkId }, mark);
        }

        // PUT: api/Mark/5
        [HttpPut("{id}")]
        public IActionResult UpdateMark(int id, MarkDTO mark)
        {
            if (id != mark.MarkId)
            {
                return BadRequest();
            }

            try
            {
                _markBL.UpdateMark(mark);
                return CreatedAtAction(nameof(GetMarkById), new { id = mark.MarkId }, mark);
            }
            catch (Exception)
            {
                if (_markBL.GetMarkById(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Mark/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMark(int id)
        {
            var existingMark = _markBL.GetMarkById(id);
            if (existingMark == null)
            {
                return NotFound();
            }

            _markBL.RemoveMark(id);

            return NoContent();
        }
    }
}
   