using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    //turma
    public class Classroom
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Subject ClassSubject { get; set; }
        public string ClassLocation { get; set; }
        public Teacher ClassTeacher { get; set; }
        public Institute InstituteProvider { get; set; }
        public List<ClassDay> ClassDays { get; set; }
        public bool IsOfficial { get; set; }
        public bool IsActive { get; set; }


    }
}
