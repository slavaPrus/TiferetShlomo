using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class Picture
    {
        public Picture()
        {
            Books = new HashSet<Book>();
            Flyers = new HashSet<Flyer>();
            PictureSales = new HashSet<PictureSale>();
        }

        public int PictureId { get; set; }
        public string? PictureName { get; set; }
        public byte[]? PictureData { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Flyer> Flyers { get; set; }
        public virtual ICollection<PictureSale> PictureSales { get; set; }
    }
}
