using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models.StudentClassroomViewModels
{
    public class AddAbsenceViewModel
    {
        public string Description { get; set; }

        public int StudentClassroomId { get; set; }

        public DateTime AbsenceDate { get; set; }

        public List<Lesson> LostLessons { get; set; }
    }
}
