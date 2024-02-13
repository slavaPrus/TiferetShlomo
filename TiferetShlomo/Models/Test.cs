using System;
using System.Collections.Generic;

namespace TiferetShlomo.Models
{
    public partial class Test
    {
        public Test()
        {
            Marks = new HashSet<Mark>();
        }

        public int TestId { get; set; }
        public DateTime? TestDate { get; set; }
        public string? Describe { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
