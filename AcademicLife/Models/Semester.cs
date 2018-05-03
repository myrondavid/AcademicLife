using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SemesterWorkload { get; set; }
        public bool IsOfficial { get; set; }
        public bool IsActive { get; set; }
        public List<Classroom> Classes { get; set; }

        public int QntClasses => Classes.Count;
    }
}
