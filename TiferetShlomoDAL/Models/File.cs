using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class File_
    {
        public File_()
        {
            BookParts = new HashSet<BookPart>();
        }

        public int FileId { get; set; }
        public string? NameFile { get; set; }
        public byte[]? FileData { get; set; }

        public virtual ICollection<BookPart> BookParts { get; set; }
    }
}
