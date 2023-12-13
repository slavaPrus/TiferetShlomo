using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDTO.DTO
{
    internal class FlyerDTO
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
