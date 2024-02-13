using System;
using System.Collections.Generic;

namespace TiferetShlomo.Models
{
    public partial class Joining
    {
        public int JoinId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
