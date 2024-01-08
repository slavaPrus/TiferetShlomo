using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IPictureDAL
    {
        Task<List<Picture>> AddPicture(Picture picture);
        Task<List<Picture>> GetAllPictures();
        Task<Picture> GetPictureById(int id);
        Task RemovePicture(int id);
        Task<Picture> UpdatePicture(Picture picture);
    }
}