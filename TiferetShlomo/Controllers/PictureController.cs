using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiferetShlomoBL;
using TiferetShlomoDAL.Models;
using TiferetShlomoDTO.DTO;

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
        public async Task<List<PictureDTO>> GetAllPictures()
        {
            try
            {
                List<PictureDTO> pictures = await _pictureBL.GetAllPictures();
                return pictures;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllPictures Controller");
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<PictureDTO> GetPictureById(int id)
        {
            try
            {
                PictureDTO picture = await _pictureBL.GetPictureById(id);
                return picture;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetPictureById Controller");
                return null;
            }
        }

        [HttpPost]
        public async Task<List<PictureDTO>> AddPicture([FromBody] PictureDTO picture)
        {
            try
            {
                List<PictureDTO> pictures = await _pictureBL.AddPicture(picture);
                return pictures;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddPicture Controller");
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<PictureDTO> UpdatePicture(int id, [FromBody] PictureDTO picture)
        {
            try
            {
                PictureDTO existingPicture = await _pictureBL.UpdatePicture( picture);
                return existingPicture;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdatePicture Controller");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task RemovePicture(int id)
        {
            try
            {
                await _pictureBL.RemovePicture(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemovePicture Controller");
            }
        }
    }
}