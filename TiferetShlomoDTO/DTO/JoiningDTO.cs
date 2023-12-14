using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDTO.DTO
{
    public class JoiningDTO
    {
        public int JoinId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
