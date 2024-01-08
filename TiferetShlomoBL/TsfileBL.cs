using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;
using TiferetShlomoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiferetShlomoBL
{
    public class TsfileBL : ITsfileBL
    {
        private readonly ITsfileDAL _tsfileDAL;
        private readonly IMapper _mapper;

        public TsfileBL(ITsfileDAL tsfileDAL, IMapper mapper)
        {
            _tsfileDAL = tsfileDAL;
            _mapper = mapper;
        }

        public async Task<List<TsfileDTO>> GetAllTsfiles()
        {
            try
            {
                List<Tsfile> tsfiles = await _tsfileDAL.GetAllTsfiles();

                List<TsfileDTO> tsfilesDTO = _mapper.Map<List<TsfileDTO>>(tsfiles);

                return tsfilesDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllTsfiles BL");
                return null;
            }
        }

        public async Task<TsfileDTO> GetTsfileById(int id)
        {
            try
            {
                Tsfile tsfile = await _tsfileDAL.GetTsfileById(id);
                TsfileDTO tsfileDTO = _mapper.Map<TsfileDTO>(tsfile);
                return tsfileDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetTsfileById BL");
                return null;
            }
        }

        public async Task<List<TsfileDTO>> AddTsfile(TsfileDTO tsfile)
        {
            try
            {
                Tsfile tf = _mapper.Map<Tsfile>(tsfile);
                List<Tsfile> tsfiles = await _tsfileDAL.AddTsfile(tf);

                List<TsfileDTO> tsfilesDTO = _mapper.Map<List<TsfileDTO>>(tsfiles);

                return tsfilesDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddTsfile BL");
                return null;
            }
        }

        public async Task<TsfileDTO> UpdateTsfile(TsfileDTO tsfile)
        {
            try
            {
                Tsfile tf = _mapper.Map<Tsfile>(tsfile);
                Tsfile updatedTsfile = await _tsfileDAL.UpdateTsfile(tf);
                TsfileDTO updatedTsfileDTO = _mapper.Map<TsfileDTO>(updatedTsfile);
                return updatedTsfileDTO;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateTsfile BL");
                return null;
            }
        }

        public async Task RemoveTsfile(int id)
        {
            try
            {
                await _tsfileDAL.RemoveTsfile(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveTsfile BL");
            }
        }
    }
}
