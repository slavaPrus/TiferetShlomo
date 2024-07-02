using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IFlyerDAL
    {
        Task<List<Flyer>> AddFlyer(Flyer flyer);
        Task<List<Flyer>> GetAllFlyers();
        Task<Flyer> GetFlyerById(int id);
        Task RemoveFlyer(int id);
        Task<Flyer> UpdateFlyer(Flyer flyer);
        Task<(List<Flyer>, bool)> GetFlyersByPage(int skipCount, int pageSize);
        Task<(List<Flyer>, bool)> GetSearchFlyersByPage(int skipCount, int pageSize, string str);
        Task<(List<Flyer>, bool)> GetFilterFlyersByPage(int skipCount, int pageSize, string str);
    }
}