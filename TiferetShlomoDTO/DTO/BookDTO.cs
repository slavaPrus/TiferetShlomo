using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDTO.DTO
{
    internal class BookDTO
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? Describe { get; set; }
        public int? Part { get; set; }
        public string? BookUrl { get; set; }
        public int? PictureId { get; set; }

        public virtual Picture? Picture { get; set; }
    }
}
