using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class Institute
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public University UniversityProvider { get; set; }
    }
}
