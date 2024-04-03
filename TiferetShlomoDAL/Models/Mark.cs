using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class Mark
    {
        public int MarkId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int? MarkNumber { get; set; }

        public virtual Test? Test { get; set; }
        public virtual User? User { get; set; }
    }
}
