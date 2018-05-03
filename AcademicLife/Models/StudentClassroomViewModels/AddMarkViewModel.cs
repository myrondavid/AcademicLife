using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models.StudentClassroomViewModels
{
    public class AddMarkViewModel
    {
        //StudentClassroom
        public int StudentClassroomId { get; set; }

        public string StudentClassroomDescription { get; set; }

        public int ClassroomId { get; set; }

        public List<DayOfClass> StudentDayOfClasses { get; set; }

        public List<Mark> StudentMarks { get; set; }

        //Marks
        public string MarkName { get; set; }
        public string MarkDescription { get; set; }

        //DayOfClass
        public int ClassroomStudentId { get; set; }
        public Classroom ClassroomStudent { get; set; }

        public bool wasPresent { get; set; }

        public DateTime DateOfLessons { get; set; }

        public int ClassDayId { get; set; }
        public ClassDay DayOfClassDay { get; set; }

        public List<Lesson> Lessons { get; set; }


    }
}
