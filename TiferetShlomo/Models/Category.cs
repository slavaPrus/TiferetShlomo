using System;
using System.Collections.Generic;

namespace TiferetShlomo.Models
{
    public partial class Category
    {
        public Category()
        {
            Joinings = new HashSet<Joining>();
        }

        public int CategoryId { get; set; }
        public string? Describe { get; set; }

        public virtual ICollection<Joining> Joinings { get; set; }
    }
}
