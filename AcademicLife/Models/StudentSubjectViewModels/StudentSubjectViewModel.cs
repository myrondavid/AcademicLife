using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models.StudentSubjectViewModels
{
    public class StudentSubjectViewModel
    {
        public string Description { get; set; }

        public int SubjectId { get; set; }

        public Difficult SubjectDifficult { get; set; }

        public bool IsConcluded { get; set; }



        public List<Subject> Subjects { get; set; }
    }
}
