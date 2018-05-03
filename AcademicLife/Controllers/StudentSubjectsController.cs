using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademicLife.Data;
using AcademicLife.Models;
using AcademicLife.Models.StudentSubjectViewModels;
using Microsoft.AspNetCore.Identity;

namespace AcademicLife.Controllers
{
    public class StudentSubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public StudentSubjectsController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        // GET: StudentSubjects
        public async Task<IActionResult> Index()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var applicationDbContext = _context.StudentSubject
                .Include(s => s.Subject)
                .Where(s => s.Student.Id == currentUser.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubject
                .Include(s => s.Subject)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (studentSubject == null)
            {
                return NotFound();
            }

            return View(studentSubject);
        }

        // GET: StudentSubjects/Create
        public IActionResult Create()
        {
            var model = new StudentSubjectViewModel()
            {
                Subjects = _context.Subjects.Include(s => s.InstituteProvider).ToList()
            };
            return View(model);
        }

        // POST: StudentSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentSubjectViewModel model)
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var studentSubject = new StudentSubject()
            {
                Description = model.Description,
                SubjectDifficult = model.SubjectDifficult,
                IsConcluded = model.IsConcluded,
                SubjectId = model.SubjectId,
                Student = currentUser
            };
            if (ModelState.IsValid)
            {
                _context.Add(studentSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: StudentSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubject.SingleOrDefaultAsync(m => m.Id == id);
            if (studentSubject == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", studentSubject.SubjectId);
            return View(studentSubject);
        }

        // POST: StudentSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,SubjectId,Dificult,IsConcluded")] StudentSubject studentSubject)
        {
            if (id != studentSubject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentSubjectExists(studentSubject.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", studentSubject.SubjectId);
            return View(studentSubject);
        }

        // GET: StudentSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubject
                .Include(s => s.Subject)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (studentSubject == null)
            {
                return NotFound();
            }

            return View(studentSubject);
        }

        // POST: StudentSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentSubject = await _context.StudentSubject.SingleOrDefaultAsync(m => m.Id == id);
            _context.StudentSubject.Remove(studentSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentSubjectExists(int id)
        {
            return _context.StudentSubject.Any(e => e.Id == id);
        }
    }
}
