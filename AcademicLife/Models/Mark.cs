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
        public int StudentClassroomId { get; set; }

        private decimal markPontuation;
        public decimal MarkPontuation
        {
            get
            {
                if (Activities != null)
                {
                    decimal total = 0;
                    foreach (var a in Activities)
                    {
                        total += a.Pontuation;
                    }

                    var actCount = Activities.Count;
                    if (actCount == 0) markPontuation = total;
                    else markPontuation = total / Activities.Count;
                }             
                return Decimal.Round(markPontuation, 2);
            }
            set => markPontuation = value;
        }


    }
}
