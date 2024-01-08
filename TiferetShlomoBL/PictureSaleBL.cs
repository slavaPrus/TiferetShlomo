using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomoBL
    {
    public class PictureSaleBL : IPictureSaleBL
    {
        private readonly IPictureSaleDAL _pictureSaleDAL;
        private readonly IMapper _mapper;

        public PictureSaleBL(IPictureSaleDAL pictureSaleDAL, IMapper mapper)
        {
            _pictureSaleDAL = pictureSaleDAL;
            _mapper = mapper;
        }

        public async Task<List<PictureSaleDTO>> GetAllPictureSales()
        {
            try
            {
                List<PictureSale> pictureSales = await _pictureSaleDAL.GetAllPictureSales();

                List<PictureSaleDTO> pictureSalesDTO = _mapper.Map<List<PictureSaleDTO>>(pictureSales);

                return pictureSalesDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllPictureSales BL");
                return null;
            }
        }

        public async Task<PictureSaleDTO> GetPictureSaleById(int id)
        {
            try
            {
                PictureSale pictureSale = await _pictureSaleDAL.GetPictureSaleById(id);
                PictureSaleDTO pictureSaleDTO = _mapper.Map<PictureSaleDTO>(pictureSale);
                return pictureSaleDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetPictureSaleById BL");
                return null;
            }
        }

        public async Task<List<PictureSaleDTO>> AddPictureSale(PictureSaleDTO pictureSale)
        {
            try
            {
                PictureSale ps = _mapper.Map<PictureSale>(pictureSale);
                List<PictureSale> pictureSales = await _pictureSaleDAL.AddPictureSale(ps);

                List<PictureSaleDTO> pictureSalesDTO = _mapper.Map<List<PictureSaleDTO>>(pictureSales);

                return pictureSalesDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddPictureSale BL");
                return null;
            }
        }

        public async Task<PictureSaleDTO> UpdatePictureSale(PictureSaleDTO pictureSale)
        {
            try
            {
                PictureSale ps = _mapper.Map<PictureSale>(pictureSale);
                PictureSale psUP = await _pictureSaleDAL.UpdatePictureSale(ps);
                PictureSaleDTO psDTO = _mapper.Map<PictureSaleDTO>(psUP);
                return psDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdatePictureSale BL");
                return null;
            }
        }

        public async Task RemovePictureSale(int id)
        {
            try
            {
                await _pictureSaleDAL.RemovePictureSale(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemovePictureSale BL");
            }
        }
    }
}


