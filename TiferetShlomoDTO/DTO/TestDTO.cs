using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDTO.DTO
{
    public class TestDTO
    {
        public int TestId { get; set; }
        public DateTime? TestDate { get; set; }
        public string? Describe { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
