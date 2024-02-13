using System;
using System.Collections.Generic;

namespace TiferetShlomo.Models
{
    public partial class ParashatShavua
    {
        public ParashatShavua()
        {
            Flyers = new HashSet<Flyer>();
        }

        public int ParashatShavuaId { get; set; }
        public string? Describe { get; set; }

        public virtual ICollection<Flyer> Flyers { get; set; }
    }
}
