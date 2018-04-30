using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models.InstituteViewModels
{
    public class InstituteViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int UniversityProviderId { get; set; }
        public University UniversityProvider { get; set; }

        public List<University> Universities { get; set; }
    }
}
