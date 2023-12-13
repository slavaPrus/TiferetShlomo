using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;

namespace TiferetShlomo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlyerController : ControllerBase
    {
        private readonly IFlyerBL _flyerBL; // Inject IFlyerBL interface here

        public FlyerController(IFlyerBL flyerBL)
        {
            _flyerBL = flyerBL;
        }

        [HttpGet]
        public IActionResult GetAllFlyers()
        {
            try
            {
                var flyers = _flyerBL.GetAllFlyers();
                return Ok(flyers);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFlyerById(int id)
        {
            try
            {
                var flyer = _flyerBL.GetFlyerById(id);
                if (flyer == null)
                {
                    return NotFound();
                }

                return Ok(flyer);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult AddFlyer([FromBody] Flyer flyer)
        {
            try
            {
                _flyerBL.AddFlyer(flyer);
                return CreatedAtAction(nameof(GetFlyerById), new { id = flyer.FlyerId }, flyer);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFlyer(int id, [FromBody] Flyer flyer)
        {
            try
            {
                if (id != flyer.FlyerId)
                {
                    return BadRequest("Id mismatch");
                }

                _flyerBL.UpdateFlyer(flyer);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveFlyer(int id)
        {
            try
            {
                _flyerBL.RemoveFlyer(id);
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
