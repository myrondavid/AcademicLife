using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademicLife.Models.StudentCourseViewModels
{
    public class StudentCourseViewModel
    {

        
        [Display(Name = "Matricula")]
        public string StudentRegistration { get; set; }

        
        [Display(Name = "Cursos")]
        public List<Course> Courses { get; set; }
    }
}
