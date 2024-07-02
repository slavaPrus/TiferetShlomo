using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class Book
    {

        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? Describe { get; set; }
        public int? Part { get; set; }
        public string? BookUrl { get; set; }
        public string? Category { get; set; }
        public float? Cost { get; set; }
        public byte[]? PictureData { get; set; }
        
        public int? Stock { get; set; }
    }
}
