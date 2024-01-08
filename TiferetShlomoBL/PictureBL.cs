using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public class PictureBL : IPictureBL

    {
        private readonly IPictureDAL _pictureDAL;
        private readonly IMapper _mapper;


        public PictureBL(IPictureDAL pictureDAL, IMapper mapper)
        {
            _pictureDAL = pictureDAL;
            _mapper = mapper;
        }

        public async Task<List<PictureDTO>> GetAllPictures()
        {
            try
            {
                List<Picture> pictures = await _pictureDAL.GetAllPictures();
                List<PictureDTO> pictureDTOs = _mapper.Map<List<PictureDTO>>(pictures);
                return pictureDTOs;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllPictures BL");
                return null;
            }
        }

        public async Task<PictureDTO> GetPictureById(int id)
        {
            try
            {
                Picture picture = await _pictureDAL.GetPictureById(id);
                PictureDTO pictureDTO = _mapper.Map<PictureDTO>(picture);
                return pictureDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetPictureById BL");
                return null;
            }
        }

        public async Task<List<PictureDTO>> AddPicture(PictureDTO picture)
        {
            try
            {
                Picture p = _mapper.Map<Picture>(picture);
                List<Picture> pictures = await _pictureDAL.AddPicture(p);
                List<PictureDTO> pictureDTOs = _mapper.Map<List<PictureDTO>>(pictures);
                return pictureDTOs;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddPicture BL");
                return null;
            }
        }

        public async Task<PictureDTO> UpdatePicture(PictureDTO picture)
        {
            try
            {
                Picture p = _mapper.Map<Picture>(picture);
                Picture updatedPicture = await _pictureDAL.UpdatePicture(p);
                PictureDTO updatedPictureDTO = _mapper.Map<PictureDTO>(updatedPicture);
                return updatedPictureDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdatePicture BL");
                return null;
            }
        }

        public async Task RemovePicture(int id)
        {
            try
            {
                await _pictureDAL.RemovePicture(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemovePicture BL");
            }
        }
    }
}