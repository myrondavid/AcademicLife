using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class DayOfClass
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        public int ClassroomStudentId { get; set; }
        public Classroom ClassroomStudent { get; set; }

        public bool wasPresent { get; set; }

        public DateTime DateOfLessons { get; set; }

        public int ClassDayId { get; set; }
        public ClassDay DayOfClassDay { get; set; }

        public List<Lesson> Lessons { get; set; }

        public int DayWorkload
        {
            get
            {
                return Lessons.Sum(item => item.LessonWorkload);
            }
        }
    }
}
