using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDTO.DTO
{
    public class LessonDTO
    {
        public int LessonId { get; set; }
        public string? LessonName { get; set; }
        public string? LessonUrl { get; set; }
        public byte[]? LessonData { get; set; }
        public virtual LessonSubject? LessonSubject { get; set; }
        public virtual LessonType? LessonType { get; set; }
    }
}
