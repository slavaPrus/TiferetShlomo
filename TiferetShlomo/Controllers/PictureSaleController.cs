using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomo.Controllers
{
    [Route("api/picture-sales")]
    [ApiController]
    public class PictureSaleController : ControllerBase
    {
        private readonly IPictureSaleBL _pictureSaleBL;

        public PictureSaleController(IPictureSaleBL pictureSaleBL)
        {
            _pictureSaleBL = pictureSaleBL;
        }

        [HttpGet]
        public async Task<List<PictureSaleDTO>> GetAllPictureSales()
        {
            try
            {
                List<PictureSaleDTO> pictureSales = await _pictureSaleBL.GetAllPictureSales();
                return pictureSales;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllPictureSales Controller");
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<PictureSaleDTO> GetPictureSaleById(int id)
        {
            try
            {
                PictureSaleDTO pictureSale = await _pictureSaleBL.GetPictureSaleById(id);
                return pictureSale;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetPictureSaleById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<PictureSaleDTO>> AddPictureSale([FromBody] PictureSaleDTO pictureSale)
        {
            try
            {
                List<PictureSaleDTO> pictureSales = await _pictureSaleBL.AddPictureSale(pictureSale);
                return pictureSales;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddPictureSale Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<PictureSaleDTO> UpdatePictureSale(int id, [FromBody] PictureSaleDTO pictureSale)
        {
            try
            {
                PictureSaleDTO existingPictureSale = await _pictureSaleBL.UpdatePictureSale(pictureSale);
                return existingPictureSale;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdatePictureSale Controller");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task RemovePictureSale(int id)
        {
            try
            {
                await _pictureSaleBL.RemovePictureSale(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemovePictureSale Controller");
            }
        }
    }
}
