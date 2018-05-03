using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AcademicLife.Data;
using Microsoft.AspNetCore.Mvc;
using AcademicLife.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace AcademicLife.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        public IActionResult Index()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            ViewData["qntCourses"] = _context.StudentCourses.Count(u => u.Student.Id == currentUser.Id);
            ViewData["qntClassrooms"] = _context.StudentClassrooms.Count(u => u.Student.Id == currentUser.Id);
            ViewData["qntSubjects"] = _context.StudentSubject.Count(s => s.Student.Id == currentUser.Id);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
