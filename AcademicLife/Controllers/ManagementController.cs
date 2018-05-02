using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademicLife.Data;
using AcademicLife.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AcademicLife.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public ManagementController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }
        // GET: Management
        public ActionResult Index()
        {
            ViewData["qntUniversities"] = _context.Universities.Count();
            ViewData["qntTeachers"] = _context.Teachers.Count();
            ViewData["qntCourses"] = _context.Courses.Count();
            ViewData["qntInstitutes"] = _context.Institutes.Count();
            ViewData["qntSubjects"] = _context.Subjects.Count();
            ViewData["qntClassrooms"] = _context.Classrooms.Count();
            ViewData["qntCurricularGrades"] = _context.CurricularGrades.Count();
            return View();
        }

        // GET: Management/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Management/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Management/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Management/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Management/Edit/5
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

        // GET: Management/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Management/Delete/5
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