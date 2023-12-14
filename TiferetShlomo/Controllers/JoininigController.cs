using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using TiferetShlomoBL;

namespace TiferetShlomo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoiningController : ControllerBase
    {
        private readonly IJoiningBL _joiningBL; // Inject IJoiningBL interface here

        public JoiningController(IJoiningBL joiningBL)
        {
            _joiningBL = joiningBL;
        }

        [HttpGet]
        public IActionResult GetAllJoinings()
        {
            try
            {
                var joinings = _joiningBL.GetAllJoinings();
                return Ok(joinings);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetJoiningById(int id)
        {
            try
            {
                var joining = _joiningBL.GetJoiningById(id);
                if (joining == null)
                {
                    return NotFound();
                }

                return Ok(joining);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult AddJoining([FromBody] Joining joining)
        {
            try
            {
                _joiningBL.AddJoining(joining);
                return CreatedAtAction(nameof(GetJoiningById), new { id = joining.JoinId }, joining);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJoining(int id, [FromBody] Joining joining)
        {
            try
            {
                if (id != joining.JoinId)
                {
                    return BadRequest("Id mismatch");
                }

                _joiningBL.UpdateJoining(joining);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveJoining(int id)
        {
            try
            {
                _joiningBL.RemoveJoining(id);
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
