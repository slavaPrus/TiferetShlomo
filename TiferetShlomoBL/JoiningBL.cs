using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomoBL
{
    public class JoiningBL : IJoiningBL
    {
        private readonly IJoiningDAL _joiningDAL;
        private readonly IMapper _mapper;

        public JoiningBL(IJoiningDAL joiningDAL, IMapper mapper)
        {
            _joiningDAL = joiningDAL;
            _mapper = mapper;
        }

        public async Task<List<JoiningDTO>> GetAllJoinings()
        {
            try
            {
                List<Joining> joinings = await _joiningDAL.GetAllJoinings();
                List<JoiningDTO> joiningDTOs = _mapper.Map<List<JoiningDTO>>(joinings);
                return joiningDTOs;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllJoinings BL");
                return null;
            }
        }

        public async Task<JoiningDTO> GetJoiningById(int id)
        {
            try
            {
                Joining joining = await _joiningDAL.GetJoiningById(id);
                JoiningDTO joiningDTO = _mapper.Map<JoiningDTO>(joining);
                return joiningDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetJoiningById BL");
                return null;
            }
        }

        public async Task<List<JoiningDTO>> AddJoining(JoiningDTO joining)
        {
            try
            {
                Joining j = _mapper.Map<Joining>(joining);
                List<Joining> joinings = await _joiningDAL.AddJoining(j);
                List<JoiningDTO> joiningDTOs = _mapper.Map<List<JoiningDTO>>(joinings);
                return joiningDTOs;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddJoining BL");
                return null;
            }
        }

        public async Task<JoiningDTO> UpdateJoining(JoiningDTO joining)
        {
            try
            {
                Joining j = _mapper.Map<Joining>(joining);
                Joining updatedJoining = await _joiningDAL.UpdateJoining(j);
                JoiningDTO updatedJoiningDTO = _mapper.Map<JoiningDTO>(updatedJoining);
                return updatedJoiningDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateJoining BL");
                return null;
            }
        }

        public async Task<bool> RemoveJoining(int id)
        {
            try
            {
                await _joiningDAL.RemoveJoining(id);
                return true; // Return true indicating successful deletion
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveJoining BL");
                return false; // Return false indicating deletion failure
            }
        }
    }
}
