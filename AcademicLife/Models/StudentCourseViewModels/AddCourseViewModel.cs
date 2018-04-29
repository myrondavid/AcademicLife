using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models.StudentCourseViewModels
{
    public class AddCourseViewModel
    {
        [Required]
        [Display(Name = "Matricula")]
        public string StudentRegistration { get; set; }

        [Required]
        [Display(Name = "Curso")]
        public int CourseId { get; set; }

        
        public List<Course> Courses { get; set; }

    }
}
