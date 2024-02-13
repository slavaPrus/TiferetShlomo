using System;
using System.Collections.Generic;

namespace TiferetShlomo.Models
{
    public partial class LessonType
    {
        public LessonType()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int LessonTypeId { get; set; }
        public string? Describe { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
