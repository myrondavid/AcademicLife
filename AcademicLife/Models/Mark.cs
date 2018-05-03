using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AcademicActivity> Activities { get; set; }

        private decimal markPontuation;
        public decimal MarkPontuation
        {
            get { return Decimal.Round(markPontuation, 2); }
            set => markPontuation = value;
        }


    }
}
