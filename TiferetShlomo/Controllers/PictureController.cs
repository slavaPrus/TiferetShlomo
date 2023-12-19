using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;

namespace TiferetShlomo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureBL _pictureBL;

        public PictureController(IPictureBL pictureBL)
        {
            _pictureBL = pictureBL;
        }

        [HttpGet]
        public IActionResult GetAllPictures()
        {
            try
            {
                var pictures = _pictureBL.GetAllPictures();
                return Ok(pictures);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPictureById(int id)
        {
            try
            {
                var picture = _pictureBL.GetPictureById(id);
                if (picture == null)
                {
                    return NotFound();
                }

                return Ok(picture);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult AddPicture([FromBody] Picture picture)
        {
            try
            {
                _pictureBL.AddPicture(picture);
                return CreatedAtAction(nameof(GetPictureById), new { id = picture.PictureId }, picture);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePicture(int id, [FromBody] Picture picture)
        {
            try
            {
                if (id != picture.PictureId)
                {
                    return BadRequest("Id mismatch");
                }

                _pictureBL.UpdatePicture(picture);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePicture(int id)
        {
            try
            {
                _pictureBL.RemovePicture(id);
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
