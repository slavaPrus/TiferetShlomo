using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public interface IPictureSaleDAL
    {
        Task<List<PictureSale>> AddPictureSale(PictureSale pictureSale);
        Task<List<PictureSale>> GetAllPictureSales();
        Task<PictureSale> GetPictureSaleById(int id);
        Task RemovePictureSale(int id);
        Task<PictureSale> UpdatePictureSale(PictureSale pictureSale);
    }
}