using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class Tsfile
    {
       

        public int FileId { get; set; }
        public string? NameFile { get; set; }
        public byte[]? FileData { get; set; }

    }
}
