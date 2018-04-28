using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public const int lessonWorkload = 1;
        public int LessonWorkload { get { return lessonWorkload; } }
    }
}
