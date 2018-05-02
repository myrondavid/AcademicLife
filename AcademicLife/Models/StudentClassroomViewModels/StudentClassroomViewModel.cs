using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models.StudentClassroomViewModels
{
    public class StudentClassroomViewModel
    {

        public string Description { get; set; }

        public int ClassroomId { get; set; }

        public Classroom Classroom { get; set; }

        public List<Classroom> Classrooms { get; set; }
    }
}
