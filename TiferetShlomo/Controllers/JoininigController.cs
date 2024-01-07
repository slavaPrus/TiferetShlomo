using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomo.Controllers
{
    [Route("api/joinings")]
    [ApiController]
    public class JoiningController : ControllerBase
    {
        private readonly IJoiningBL _joiningBL;

        public JoiningController(IJoiningBL joiningBL)
        {
            _joiningBL = joiningBL;
        }

        [HttpGet]
        public async Task<List<JoiningDTO>> GetAllJoinings()
        {
            try
            {
                return await _joiningBL.GetAllJoinings();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetAllJoinings controller");
                // You can handle exceptions according to your application's needs.
                return null; // For simplicity, returning null on exception.
            }
        }

        [HttpGet("{id}")]
        public async Task<JoiningDTO> GetJoiningById(int id)
        {
            try
            {
                return await _joiningBL.GetJoiningById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "GetJoiningById controller");
                return null; // For simplicity, returning null on exception.
            }
        }

        [HttpPost]
        public async Task<List<JoiningDTO>> AddJoining([FromBody] JoiningDTO joining)
        {
            try
            {
                return await _joiningBL.AddJoining(joining);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "AddJoining controller");
                return null; // For simplicity, returning null on exception.
            }
        }

        [HttpPut("{id}")]
        public async Task<JoiningDTO> UpdateJoining(int id, [FromBody] JoiningDTO joining)
        {
            try
            {
                return await _joiningBL.UpdateJoining(joining);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "UpdateJoining controller");
                return null; // For simplicity, returning null on exception.
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> RemoveJoining(int id)
        {
            try
            {
                return await _joiningBL.RemoveJoining(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "RemoveJoining controller");
                return false; // For simplicity, returning false on exception.
            }
        }
    }
}
