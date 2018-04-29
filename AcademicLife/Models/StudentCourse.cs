using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudentRegistration { get; set; }
        public ApplicationUser Student { get; set; }
        public Course Course { get; set; }
        public Semester CurrentSemester { get; set; }
        public List<Semester> PastSemesters { get; set; }
    }
}
