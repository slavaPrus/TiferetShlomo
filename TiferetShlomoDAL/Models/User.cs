using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class User
    {
        public User()
        {
            Marks = new HashSet<Mark>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public int? UserType { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
