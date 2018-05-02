using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models.CurricularGradeViewModels
{
    public class CurricularGradeViewModel
    {
        public int CurricularGradeId { get; set; }
        public CurricularGrade CurricularGrade { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get; set; }

        public List<Subject> Subjects { get; set; }

    }
}
