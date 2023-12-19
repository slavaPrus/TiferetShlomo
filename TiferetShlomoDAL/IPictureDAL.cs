using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IPictureDAL
    {
        void AddPicture(Picture picture);
        IEnumerable<Picture> GetAllPictures();
        Picture GetPictureById(int id);
        void RemovePicture(int id);
        void UpdatePicture(Picture picture);
    }
}