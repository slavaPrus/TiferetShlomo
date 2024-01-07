using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiferetShlomoDAL;

namespace TiferetShlomo.Controllers
{
    [Route("api/flyers")]
    [ApiController]
    public class FlyerController : ControllerBase
    {
        private readonly IFlyerBL _flyerBL;

        public FlyerController(IFlyerBL flyerBL)
        {
            _flyerBL = flyerBL;
        }

        [HttpGet]
        public async Task<List<FlyerDTO>> GetAllFlyers()
        {
            try
            {
                List<FlyerDTO> flyers = await _flyerBL.GetAllFlyers();
                return flyers;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllFlyers Controller");
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<FlyerDTO> GetFlyerById(int id)
        {
            try
            {
                FlyerDTO flyer = await _flyerBL.GetFlyerById(id);
                return flyer;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetFlyerById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<FlyerDTO>> AddFlyer([FromBody] FlyerDTO flyer)
        {
            try
            {
                List<FlyerDTO> flyers = await _flyerBL.AddFlyer(flyer);
                return flyers;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddFlyer Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<FlyerDTO> UpdateFlyer(int id, [FromBody] FlyerDTO flyer)
        {
            try
            {
                FlyerDTO existingFlyer = await _flyerBL.UpdateFlyer(flyer);
                return existingFlyer;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateFlyer Controller");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task RemoveFlyer(int id)
        {
            try
            {
                await _flyerBL.RemoveFlyer(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveFlyer Controller");
            }
        }
    }
}
