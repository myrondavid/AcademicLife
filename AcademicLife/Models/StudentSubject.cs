using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public enum Difficult
    {
        VERYEASY, EASY, MEDIUM, HARD, VERYHARD
    }

    public class StudentSubject
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ApplicationUser Student { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get; set; }

        public Difficult SubjectDifficult { get; set; }

        public bool IsConcluded { get; set; }  
    }
}
