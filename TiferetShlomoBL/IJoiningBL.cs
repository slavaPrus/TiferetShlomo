using TiferetShlomoDAL.Models;

namespace TiferetShlomoBL
{
    public interface IJoiningBL
    {
        void AddJoining(Joining joining);
        IEnumerable<Joining> GetAllJoinings();
        Joining GetJoiningById(int id);
        void RemoveJoining(int id);
        void UpdateJoining(Joining joining);
    }
}