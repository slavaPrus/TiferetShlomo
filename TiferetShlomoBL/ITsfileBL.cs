using TiferetShlomoDAL.Models;

namespace TiferetShlomoBL
{
    public interface ITsfileBL
    {
        Task<List<TsfileDTO>> AddTsfile(TsfileDTO tsfile);
        Task<List<TsfileDTO>> GetAllTsfiles();
        Task<TsfileDTO> GetTsfileById(int id);
        Task RemoveTsfile(int id);
        Task<TsfileDTO> UpdateTsfile(TsfileDTO tsfile);
    }
}