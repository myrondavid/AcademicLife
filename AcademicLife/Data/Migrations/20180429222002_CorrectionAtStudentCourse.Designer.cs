﻿// <auto-generated />
using AcademicLife.Data;
using AcademicLife.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AcademicLife.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180429222002_CorrectionAtStudentCourse")]
    partial class CorrectionAtStudentCourse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("AcademicLife.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("BornDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Cpf");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("Gender");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AcademicLife.Models.ClassDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClassroomId");

                    b.Property<int>("Day");

                    b.Property<TimeSpan>("FinalTime");

                    b.Property<TimeSpan>("InitialTime");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.ToTable("ClassDays");
                });

            modelBuilder.Entity("AcademicLife.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassLocation");

                    b.Property<int?>("ClassSubjectId");

                    b.Property<int?>("ClassTeacherId");

                    b.Property<string>("Code");

                    b.Property<int?>("InstituteProviderId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsOfficial");

                    b.Property<int?>("SemesterId");

                    b.HasKey("Id");

                    b.HasIndex("ClassSubjectId");

                    b.HasIndex("ClassTeacherId");

                    b.HasIndex("InstituteProviderId");

                    b.HasIndex("SemesterId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("AcademicLife.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Code");

                    b.Property<int>("CourseRequiredWorkload");

                    b.Property<string>("Description");

                    b.Property<int>("ElectiveRequiredWorkload");

                    b.Property<int>("FlexibleRequiredWorkload");

                    b.Property<int?>("InstituteProviderId");

                    b.Property<int>("MaximumAmountSemesters");

                    b.Property<string>("Name");

                    b.Property<int?>("OfficialCurricularGradeId");

                    b.Property<int>("StandardAmountSemesters");

                    b.Property<int>("TccRequiredWorkload");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("InstituteProviderId");

                    b.HasIndex("OfficialCurricularGradeId")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AcademicLife.Models.CurricularGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsOfficial");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CurricularGrades");
                });

            modelBuilder.Entity("AcademicLife.Models.DayOfClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfLessons");

                    b.Property<int?>("StudentClassroomId");

                    b.Property<string>("StudentId");

                    b.Property<bool>("wasPresent");

                    b.HasKey("Id");

                    b.HasIndex("StudentClassroomId");

                    b.HasIndex("StudentId");

                    b.ToTable("DayOfClasses");
                });

            modelBuilder.Entity("AcademicLife.Models.Institute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<int?>("UniversityProviderId");

                    b.HasKey("Id");

                    b.HasIndex("UniversityProviderId");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("AcademicLife.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int?>("DayOfClassId");

                    b.HasKey("Id");

                    b.HasIndex("DayOfClassId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("AcademicLife.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CurricularGradeId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsOfficial");

                    b.Property<int>("SemesterWorkload");

                    b.Property<int?>("StudentCourseId");

                    b.HasKey("Id");

                    b.HasIndex("CurricularGradeId");

                    b.HasIndex("StudentCourseId");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("AcademicLife.Models.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<int?>("CurrentSemesterId");

                    b.Property<string>("StudentId");

                    b.Property<string>("StudentRegistration");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CurrentSemesterId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("AcademicLife.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<bool>("IsRequired");

                    b.Property<string>("Name");

                    b.Property<int>("Workload");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("AcademicLife.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("AcademicLife.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AcademicLife.Models.ClassDay", b =>
                {
                    b.HasOne("AcademicLife.Models.Classroom")
                        .WithMany("ClassDays")
                        .HasForeignKey("ClassroomId");
                });

            modelBuilder.Entity("AcademicLife.Models.Classroom", b =>
                {
                    b.HasOne("AcademicLife.Models.Subject", "ClassSubject")
                        .WithMany()
                        .HasForeignKey("ClassSubjectId");

                    b.HasOne("AcademicLife.Models.Teacher", "ClassTeacher")
                        .WithMany()
                        .HasForeignKey("ClassTeacherId");

                    b.HasOne("AcademicLife.Models.Institute", "InstituteProvider")
                        .WithMany()
                        .HasForeignKey("InstituteProviderId");

                    b.HasOne("AcademicLife.Models.Semester")
                        .WithMany("Classes")
                        .HasForeignKey("SemesterId");
                });

            modelBuilder.Entity("AcademicLife.Models.Course", b =>
                {
                    b.HasOne("AcademicLife.Models.ApplicationUser")
                        .WithMany("Courses")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("AcademicLife.Models.Institute", "InstituteProvider")
                        .WithMany()
                        .HasForeignKey("InstituteProviderId");

                    b.HasOne("AcademicLife.Models.CurricularGrade", "OfficialCurricularGrade")
                        .WithOne("Course")
                        .HasForeignKey("AcademicLife.Models.Course", "OfficialCurricularGradeId");
                });

            modelBuilder.Entity("AcademicLife.Models.DayOfClass", b =>
                {
                    b.HasOne("AcademicLife.Models.Classroom", "StudentClassroom")
                        .WithMany()
                        .HasForeignKey("StudentClassroomId");

                    b.HasOne("AcademicLife.Models.ApplicationUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("AcademicLife.Models.Institute", b =>
                {
                    b.HasOne("AcademicLife.Models.University", "UniversityProvider")
                        .WithMany()
                        .HasForeignKey("UniversityProviderId");
                });

            modelBuilder.Entity("AcademicLife.Models.Lesson", b =>
                {
                    b.HasOne("AcademicLife.Models.DayOfClass")
                        .WithMany("Lessons")
                        .HasForeignKey("DayOfClassId");
                });

            modelBuilder.Entity("AcademicLife.Models.Semester", b =>
                {
                    b.HasOne("AcademicLife.Models.CurricularGrade")
                        .WithMany("Semesters")
                        .HasForeignKey("CurricularGradeId");

                    b.HasOne("AcademicLife.Models.StudentCourse")
                        .WithMany("PastSemesters")
                        .HasForeignKey("StudentCourseId");
                });

            modelBuilder.Entity("AcademicLife.Models.StudentCourse", b =>
                {
                    b.HasOne("AcademicLife.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AcademicLife.Models.Semester", "CurrentSemester")
                        .WithMany()
                        .HasForeignKey("CurrentSemesterId");

                    b.HasOne("AcademicLife.Models.ApplicationUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AcademicLife.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AcademicLife.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AcademicLife.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AcademicLife.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
