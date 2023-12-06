using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class Contact
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
