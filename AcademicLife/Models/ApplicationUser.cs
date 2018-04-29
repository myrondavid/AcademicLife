using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Cpf { get; set; }
        public DateTime BornDate { get; set; }
        public Gender Gender { get; set; }

        public List<Course> Courses { get; set; }

        public ApplicationUser()
        {
            Courses = new List<Course>();
        }

        public static implicit operator ApplicationUser(UserManager<ApplicationUser> v)
        {
            throw new NotImplementedException();
        }
    }
}
