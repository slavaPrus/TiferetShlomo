using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDTO.DTO
{
    public class BookPartDTO
    {
        public int PartId { get; set; }
        public int BookId { get; set; }
        public string? Describe { get; set; }
        public string? FilePartUrl { get; set; }
        public double? Cost { get; set; }
        public int? FileId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Tsfile? File { get; set; }
    }
}
