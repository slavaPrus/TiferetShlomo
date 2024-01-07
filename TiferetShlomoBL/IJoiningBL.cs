using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IJoiningBL
    {
        Task<List<JoiningDTO>> AddJoining(JoiningDTO joining);
        Task<List<JoiningDTO>> GetAllJoinings();
        Task<JoiningDTO> GetJoiningById(int id);
        Task<bool> RemoveJoining(int id);
        Task<JoiningDTO> UpdateJoining(JoiningDTO joining);
    }
}