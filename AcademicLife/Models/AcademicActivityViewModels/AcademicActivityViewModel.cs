using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AcademicLife.Models.AcademicActivityViewModels
{
    public class AcademicActivityViewModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Pontuation { get; set; }

        public Mark Mark { get; set; }
        [Display(Name = "Nota que atividade irá compor")]
        public int MarkId { get; set; }

        public StudentClassroom StudentClassroom { get; set; }
        public int StudentClassroomId { get; set; }

        public IEnumerable<AcademicActivity> AcademicActivities { get; set; }

        public List<StudentClassroom> StudentClassrooms { get; set; }
        public List<Mark> Marks { get; set; }

    }
}
