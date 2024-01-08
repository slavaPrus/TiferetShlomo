using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IPictureBL
    {
        Task<List<PictureDTO>> AddPicture(PictureDTO picture);
        Task<List<PictureDTO>> GetAllPictures();
        Task<PictureDTO> GetPictureById(int id);
        Task RemovePicture(int id);
        Task<PictureDTO> UpdatePicture(PictureDTO picture);
    }
}