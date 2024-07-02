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
        public async Task<(List<FlyerDTO>, bool)> GetFlyersByPage(int page)
        {
            try
            {
                int pageSize = 18;
                int skipCount = (page - 1) * pageSize;
                // Retrieve flyers from the repository based on skipCount and pageSize
                (List<Flyer> flyers, bool hasNext) = await _flyerDAL.GetFlyersByPage(skipCount, pageSize);

                List<FlyerDTO> flyersDTO = _mapper.Map<List<FlyerDTO>>(flyers);

                return (flyersDTO, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetFlyersByPage in FlyerBL");
                return (null, false); 
                // Propagate the exception to the controller for centralized error handling
            }
        }
        public async Task<(List<FlyerDTO>, bool)> GetSearchFlyersByPage(int page, string str)
        {
            try
            {
                //int pageSize = 16;
                int pageSize = 18;
                int skipCount = (page - 1) * pageSize;
                // Retrieve books from the repository based on skipCount and pageSize
                (List<Flyer> flyers, bool hasNext) = await _flyerDAL.GetSearchFlyersByPage(skipCount, pageSize, str);

                List<FlyerDTO> flyersDTO = _mapper.Map<List<FlyerDTO>>(flyers);

                return (flyersDTO, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetSearchFlyersByPage in FlyerBL");
                return (null, false); // Propagate the exception to the controller for centralized error handling
            }
        }
        public async Task<(List<FlyerDTO>, bool)> GetFilterFlyersByPage(int page, string str)
        {
            try
            {
                int pageSize = 18;
                int skipCount = (page - 1) * pageSize;

                // Retrieve filtered books from the DAL layer along with the hasNext flag
                (List<Flyer> filteredFlyers, bool hasNext) = await _flyerDAL.GetFilterFlyersByPage(skipCount, pageSize, str);

                // Map filtered books to DTOs
                List<FlyerDTO> flyersDTO = _mapper.Map<List<FlyerDTO>>(filteredFlyers);

                return (flyersDTO, hasNext);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetFilterFlyersByPage in FlyerBL");
                return (null, false); // Propagate the exception to the controller for centralized error handling
            }
        }
      

    }
}
