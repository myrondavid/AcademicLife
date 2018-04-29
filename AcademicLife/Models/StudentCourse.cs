using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }

        [Display(Name = "Matricula")]
        public string StudentRegistration { get; set; }

        public ApplicationUser Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public Semester CurrentSemester { get; set; }

        public List<Semester> PastSemesters { get; set; }
    }
}
