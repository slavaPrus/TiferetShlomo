using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class Flyer
    {
        public int FlyerId { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? ParashatShavuaId { get; set; }
        public string? FlyerUrl { get; set; }
        public byte[]? FlyerData { get; set; }
        public string? PictureUrl { get; set; }
        public int? PictureId { get; set; }

        public virtual ParashatShavua? ParashatShavua { get; set; }
        public virtual Picture? Picture { get; set; }
    }
}
