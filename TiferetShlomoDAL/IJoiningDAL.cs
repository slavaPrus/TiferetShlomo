using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IJoiningDAL
    {
        Task<List<Joining>> AddJoining(Joining joining);
        Task<List<Joining>> GetAllJoinings();
        Task<Joining> GetJoiningById(int id);
        Task RemoveJoining(int id);
        Task<Joining> UpdateJoining(Joining joining);
    }
}