using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models.ClassroomViewModels
{
    public class ClassroomViewModel
    {
        [Required]
        public string Code { get; set; }

        public string ClassLocation { get; set; }

        public Subject ClassSubject { get; set; }
        public int ClassSubjectId { get; set; }

        public Teacher ClassTeacher { get; set; }
        public int ClassTeacherId { get; set; }

        public Institute InstituteProvider { get; set; }
        public int InstituteProviderId { get; set; }

        public List<ClassDay> ClassDays { get; set; }

        public bool IsOfficial { get; set; }

        public bool IsActive { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Institute> Institutes { get; set; }
    }
}
