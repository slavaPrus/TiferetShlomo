using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiferetShlomoDTO.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public int? UserType { get; set; }
    }
}
