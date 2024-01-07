using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IFlyerBL
    {
        Task<List<FlyerDTO>> AddFlyer(FlyerDTO flyer);
        Task<List<FlyerDTO>> GetAllFlyers();
        Task<FlyerDTO> GetFlyerById(int id);
        Task RemoveFlyer(int id);
        Task<FlyerDTO> UpdateFlyer(FlyerDTO flyer);
    }
}