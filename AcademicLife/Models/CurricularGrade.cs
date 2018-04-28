using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class CurricularGrade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public List<Semester> Semesters { get; set; }
        public bool IsOfficial { get; set; }


    }
}
