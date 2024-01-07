using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomoBL
{
    public class FlyerBL : IFlyerBL
    {
        private readonly IFlyerDAL _flyerDAL;
        private readonly IMapper _mapper;

        public FlyerBL(IFlyerDAL flyerDAL, IMapper mapper)
        {
            _flyerDAL = flyerDAL;
            _mapper = mapper;
        }

        public async Task<List<FlyerDTO>> GetAllFlyers()
        {
            try
            {
                List<Flyer> flyers = await _flyerDAL.GetAllFlyers();
                List<FlyerDTO> flyersDTO = _mapper.Map<List<FlyerDTO>>(flyers);
                return flyersDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllFlyers BL");
                return null;
            }
        }

        public async Task<FlyerDTO> GetFlyerById(int id)
        {
            try
            {
                Flyer flyer = await _flyerDAL.GetFlyerById(id);
                FlyerDTO flyerDTO = _mapper.Map<FlyerDTO>(flyer);
                return flyerDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetFlyerById BL");
                return null;
            }
        }

        public async Task<List<FlyerDTO>> AddFlyer(FlyerDTO flyer)
        {
            try
            {
                Flyer f = _mapper.Map<Flyer>(flyer);
                List<Flyer> flyers = await _flyerDAL.AddFlyer(f);
                List<FlyerDTO> flyersDTO = _mapper.Map<List<FlyerDTO>>(flyers);
                return flyersDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddFlyer BL");
                return null;
            }
        }

        public async Task<FlyerDTO> UpdateFlyer(FlyerDTO flyer)
        {
            try
            {
                Flyer f = _mapper.Map<Flyer>(flyer);
                Flyer updatedFlyer = await _flyerDAL.UpdateFlyer(f);
                FlyerDTO updatedFlyerDTO = _mapper.Map<FlyerDTO>(updatedFlyer);
                return updatedFlyerDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateFlyer BL");
                return null;
            }
        }

        public async Task RemoveFlyer(int id)
        {
            try
            {
                await _flyerDAL.RemoveFlyer(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveFlyer BL");
            }
        }
    }
}
