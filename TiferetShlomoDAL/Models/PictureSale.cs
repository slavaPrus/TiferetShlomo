using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class PictureSale
    {
        public int PictureSaleId { get; set; }
        public string? PictureSaleName { get; set; }
        public string? Describe { get; set; }
        public string? PictureUrl { get; set; }
        public int? PictureId { get; set; }

        public virtual Picture? Picture { get; set; }
    }
}
