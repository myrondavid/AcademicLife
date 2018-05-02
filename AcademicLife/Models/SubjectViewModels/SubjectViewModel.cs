using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models.SubjectViewModels
{
    public class SubjectViewModel
    {
        public List<Institute> Institutes { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Workload { get; set; }

        public bool IsRequired { get; set; }

        public int InstituteProviderId { get; set; }

        public Institute InstituteProvider { get; set; }

        public int SemesterNumber { get; set; }
    }
}
