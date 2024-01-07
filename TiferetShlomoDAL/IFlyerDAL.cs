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
    }
}