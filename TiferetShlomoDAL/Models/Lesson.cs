using System;
using System.Collections.Generic;

namespace TiferetShlomoDAL.Models
{
    public partial class Lesson
    {
        public int LessonId { get; set; }
        public string? LessonName { get; set; }
        public int? LessonSubjectId { get; set; }
        public string? LessonUrl { get; set; }
        public byte[]? LessonData { get; set; }
        public int? LessonTypeId { get; set; }

        public virtual LessonSubject? LessonSubject { get; set; }
        public virtual LessonType? LessonType { get; set; }
    }
}
