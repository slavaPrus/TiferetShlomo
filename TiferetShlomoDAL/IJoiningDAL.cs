using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IJoiningDAL
    {
        void AddJoining(Joining joining);
        IEnumerable<Joining> GetAllJoinings();
        Joining GetJoiningById(int id);
        void RemoveJoining(int id);
        void UpdateJoining(Joining joining);
    }
}