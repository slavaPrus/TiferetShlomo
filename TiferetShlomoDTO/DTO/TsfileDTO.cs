using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class TsfileDTO
    {
        public int FileIdDTO { get; set; }
        public string? NameFileDTO { get; set; }
        public byte[]? FileDataDTO { get; set; }
    }
}
