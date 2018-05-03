using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class Absence
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ApplicationUser Student { get; set; }
        public Classroom Classroom { get; set; }
        public DateTime AbsenceDate { get; set; }
        public List<Lesson> LostLessons { get; set; }

    }
}
