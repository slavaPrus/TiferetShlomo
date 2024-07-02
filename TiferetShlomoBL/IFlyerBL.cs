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
        Task<(List<FlyerDTO>, bool)> GetFlyersByPage(int page);
        Task<(List<FlyerDTO>, bool)> GetSearchFlyersByPage(int page, string str);
        Task<(List<FlyerDTO>, bool)> GetFilterFlyersByPage(int page, string str);
    }
}