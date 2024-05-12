using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDTO.DTO
{
    public class MarkDTO
    {
        public int MarkId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int MarkNumber { get; set; }
        public virtual TestDTO? Test { get; set; }
        public virtual UserDTO? User { get; set; }
    }
}
