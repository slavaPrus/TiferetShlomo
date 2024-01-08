using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface ITsfileDAL
    {
        Task<List<Tsfile>> AddTsfile(Tsfile tsfile);
        Task<List<Tsfile>> GetAllTsfiles();
        Task<Tsfile> GetTsfileById(int id);
        Task RemoveTsfile(int id);
        Task<Tsfile> UpdateTsfile(Tsfile tsfile);
    }
}