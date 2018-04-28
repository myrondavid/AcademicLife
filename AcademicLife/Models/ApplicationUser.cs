using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AcademicLife.Models
{
    public enum Gender
    {
        MALE, FEMALE
    }

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Registration { get; set; }
        public int Cpf { get; set; }
        public DateTime BornDate { get; set; }
        public Gender Gender { get; set; }
    }
}
