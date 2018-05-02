﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicLife.Models
{
    public class CurricularGrade
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool IsOfficial { get; set; }

        public List<Subject> Subjects { get; set; }


    }
}
