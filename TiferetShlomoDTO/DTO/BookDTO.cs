using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDTO.DTO
{
    public class BookDTO
    {
        public int? BookId { get; set; }
        public string? BookName { get; set; }
        public string? Describe { get; set; }
        public int? Part { get; set; }
        public string? BookUrl { get; set; }
        public float? Cost { get; set; }
        public byte[]? PictureData { get; set; }
        public int? Stock { get; set; }

    }
}
