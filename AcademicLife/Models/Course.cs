using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Institute InstituteProvider { get; set; }
        public int StandardAmountSemesters { get; set; }
        public int MaximumAmountSemesters { get; set; }
        public int CourseRequiredWorkload { get; set; }
        public int ElectiveRequiredWorkload { get; set; }
        public int FlexibleRequiredWorkload { get; set; }
        public int TccRequiredWorkload { get; set; }
        public CurricularGrade OfficialCurricularGrade { get; set; }
    }
}
