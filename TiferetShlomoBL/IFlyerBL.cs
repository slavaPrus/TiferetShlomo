using TiferetShlomoDAL.Models;

namespace TiferetShlomoBL
{
    public interface IFlyerBL
    {
        void AddFlyer(Flyer flyer);
        IEnumerable<Flyer> GetAllFlyers();
        Flyer GetFlyerById(int id);
        void RemoveFlyer(int id);
        void UpdateFlyer(Flyer flyer);
    }
}