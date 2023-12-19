using TiferetShlomoDAL.Models;

namespace TiferetShlomoBL
{
    public interface IPictureBL
    {
        void AddPicture(Picture picture);
        IEnumerable<Picture> GetAllPictures();
        Picture GetPictureById(int id);
        void RemovePicture(int id);
        void UpdatePicture(Picture picture);
    }
}