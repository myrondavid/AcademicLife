using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class MarkCalculatorViewModel
    {
        public decimal Ab1 { get; set; }
        public decimal Ab2 { get; set; }
        public decimal DesiredFinalMark { get; set; }
        public decimal? FinalMark { get; set; }
    }
}
