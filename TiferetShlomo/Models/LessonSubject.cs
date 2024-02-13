using System;
using System.Collections.Generic;

namespace TiferetShlomo.Models
{
    public partial class LessonSubject
    {
        public LessonSubject()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int LessonSubjectId { get; set; }
        public string? Describe { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
