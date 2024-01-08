using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiferetShlomoDTO.DTO
{
    public class PictureSaleDTO
    {
        public int PictureSaleId { get; set; }
        public string? PictureSaleName { get; set; }
        public string? Describe { get; set; }
        public string? PictureUrl { get; set; }
        public int? PictureId { get; set; }
    }
}
