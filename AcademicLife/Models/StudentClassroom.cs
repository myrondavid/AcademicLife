using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class StudentClassroom
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ApplicationUser Student { get; set; }

        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        public List<DayOfClass> StudentDayOfClasses { get; set; }

        public List<Mark> StudentMarks { get; set; }

        public int QntAbsences
        {
            get { return StudentDayOfClasses.Count(s => s.wasPresent == false); }
        }

        public Decimal GeneralMark
        {
            get
            {
                decimal totalPontuation = 0;
                foreach (var m in StudentMarks)
                {
                    totalPontuation += m.MarkPontuation;
                }

                int qntMarks = StudentMarks.Count;
                if (qntMarks == 0)
                    return 0;

                return totalPontuation / StudentMarks.Count;
            }
        }

        
    }
}
