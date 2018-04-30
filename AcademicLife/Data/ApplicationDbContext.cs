using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AcademicLife.Models;

namespace AcademicLife.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<University> Universities { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<DayOfClass> DayOfClasses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CurricularGrade> CurricularGrades { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<ClassDay> ClassDays { get; set; }
        public DbSet<AcademicActivity> AcademicActivities { get; set; }
        public DbSet<Mark> Grades { get; set; }
        public DbSet<StudentClassroom> StudentClassrooms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasMany(c => c.Courses);
            builder.Entity<Course>().HasMany(c => c.Users);
            builder.Entity<Mark>().HasMany(a => a.Activities);

        }
    }
}
