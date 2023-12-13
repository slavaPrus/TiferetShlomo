using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiferetShlomoDTO.DTO
{
    public class ContactDTO
    {
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Describe { get; set; }
        public string? Title { get; set; }
        public DateTime? ContactDate { get; set; }
    }
}
