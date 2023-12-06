using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class BookPart
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
