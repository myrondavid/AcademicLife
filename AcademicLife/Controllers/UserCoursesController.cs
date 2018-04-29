using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademicLife.Data;
using AcademicLife.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademicLife.Controllers
{
    [Authorize]
    public class UserCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public UserCoursesController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        // GET: UserCourses
        public ActionResult Index()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var userCourses = _context.StudentCourses.Where(u => u.Student.UserName == currentUser.UserName);
            return View(userCourses);
        }

        // GET: UserCourses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserCourses/Create
        public ActionResult Create()
        {

            return View("AddCourse", _context.Courses);
        }

        // POST: UserCourses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int courseId)
        {
            try
            {
                var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                var course = _context.Courses.Find(courseId);
                if (course != null && currentUser != null)
                {
                    var newUserCourse = new StudentCourse()
                    {
                        Course = course,
                        Student = currentUser
                    };
                    _context.StudentCourses.Add(newUserCourse);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserCourses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserCourses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserCourses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserCourses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}