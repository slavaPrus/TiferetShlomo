using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IFlyerDAL
    {
        void AddFlyer(Flyer flyer);
        IEnumerable<Flyer> GetAllFlyers();
        Flyer GetFlyerById(int id);
        void RemoveFlyer(int id);
        void UpdateFlyer(Flyer flyer);
    }
}