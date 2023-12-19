using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiferetShlomoDTO.DTO
{
    public class PictureDTO
    {
        public int PictureId { get; set; }
        public string? PictureName { get; set; }
        public byte[]? PictureData { get; set; }
    }
}
