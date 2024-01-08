using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomo.Controllers
{
    [Route("api/tsfile")]
    [ApiController]
    public class TsfileController : ControllerBase
    {
        private readonly ITsfileBL _tsfileBL;

        public TsfileController(ITsfileBL tsfileBL)
        {
            _tsfileBL = tsfileBL;
        }

        [HttpGet]
        public async Task<ActionResult<List<TsfileDTO>>> GetAllTsfiles()
        {
            try
            {
                var tsfiles = await _tsfileBL.GetAllTsfiles();
                if (tsfiles == null || tsfiles.Count == 0)
                {
                    return NotFound();
                }
                return Ok(tsfiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TsfileDTO>> GetTsfileById(int id)
        {
            try
            {
                var tsfile = await _tsfileBL.GetTsfileById(id);
                if (tsfile == null)
                {
                    return NotFound();
                }
                return Ok(tsfile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<TsfileDTO>>> AddTsfile(TsfileDTO tsfile)
        {
            try
            {
                var addedTsfile = await _tsfileBL.AddTsfile(tsfile);
                if (addedTsfile == null || addedTsfile.Count == 0)
                {
                    return BadRequest();
                }
                return Ok(addedTsfile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<TsfileDTO>> UpdateTsfile(TsfileDTO tsfile)
        {
            try
            {
                var updatedTsfile = await _tsfileBL.UpdateTsfile(tsfile);
                if (updatedTsfile == null)
                {
                    return NotFound();
                }
                return Ok(updatedTsfile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveTsfile(int id)
        {
            try
            {
                await _tsfileBL.RemoveTsfile(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
