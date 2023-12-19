using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;

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

        public IEnumerable<Picture> GetAllPictures()
        {
            try
            {
                return _pictureDAL.GetAllPictures();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public Picture GetPictureById(int id)
        {
            try
            {
                return _pictureDAL.GetPictureById(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void AddPicture(Picture picture)
        {
            try
            {
                _pictureDAL.AddPicture(picture);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void UpdatePicture(Picture picture)
        {
            try
            {
                _pictureDAL.UpdatePicture(picture);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void RemovePicture(int id)
        {
            try
            {
                _pictureDAL.RemovePicture(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }
    }
}
