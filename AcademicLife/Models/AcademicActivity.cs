﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class AcademicActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Pontuation { get; set; }

        public Mark Mark { get; set; }
        public int MarkId { get; set; }

        public StudentClassroom StudentClassroom { get; set; }
        public int StudentClassroomId { get; set; }
    }
}
