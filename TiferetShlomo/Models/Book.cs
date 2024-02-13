using System;
using System.Collections.Generic;

namespace TiferetShlomo.Models
{
    public partial class Book
    {
        public Book()
        {
            BookParts = new HashSet<BookPart>();
        }

        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? Describe { get; set; }
        public int? Part { get; set; }
        public string? BookUrl { get; set; }
        public int? PictureId { get; set; }
        public string? Category { get; set; }
        public double? Cost { get; set; }

        public virtual ICollection<BookPart> BookParts { get; set; }
    }
}
