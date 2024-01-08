using TiferetShlomoDTO.DTO;

namespace TiferetShlomoBL
{
    public interface IPictureSaleBL
    {
        Task<List<PictureSaleDTO>> AddPictureSale(PictureSaleDTO pictureSale);
        Task<List<PictureSaleDTO>> GetAllPictureSales();
        Task<PictureSaleDTO> GetPictureSaleById(int id);
        Task RemovePictureSale(int id);
        Task<PictureSaleDTO> UpdatePictureSale(PictureSaleDTO pictureSale);
    }
}