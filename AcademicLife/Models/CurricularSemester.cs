using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class CurricularSemester
    {
        public int Id { get; set; }

        public int SemesterNumber { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
