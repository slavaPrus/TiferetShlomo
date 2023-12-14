using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;

namespace TiferetShlomo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonBL _lessonBL; // Inject ILessonBL interface here

        public LessonController(ILessonBL lessonBL)
        {
            _lessonBL = lessonBL;
        }

        [HttpGet]
        public IActionResult GetAllLessons()
        {
            try
            {
                var lessons = _lessonBL.GetAllLessons();
                return Ok(lessons);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLessonById(int id)
        {
            try
            {
                var lesson = _lessonBL.GetLessonById(id);
                if (lesson == null)
                {
                    return NotFound();
                }

                return Ok(lesson);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult AddLesson([FromBody] Lesson lesson)
        {
            try
            {
                _lessonBL.AddLesson(lesson);
                return CreatedAtAction(nameof(GetLessonById), new { id = lesson.LessonId }, lesson);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLesson(int id, [FromBody] Lesson lesson)
        {
            try
            {
                if (id != lesson.LessonId)
                {
                    return BadRequest("Id mismatch");
                }

                _lessonBL.UpdateLesson(lesson);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveLesson(int id)
        {
            try
            {
                _lessonBL.RemoveLesson(id);
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
