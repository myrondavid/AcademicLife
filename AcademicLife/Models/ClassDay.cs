using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class ClassDay
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan InitialTime { get; set; }
        public TimeSpan FinalTime { get; set; }

    }
}
