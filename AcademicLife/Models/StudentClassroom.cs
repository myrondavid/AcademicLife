using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class StudentClassroom
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        public List<DayOfClass> StudentDayOfClasses { get; set; }

        public List<Mark> StudentMarks { get; set; }
    }
}
