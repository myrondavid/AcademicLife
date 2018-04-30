using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademicLife.Data;
using AcademicLife.Models;
using AcademicLife.Models.ClassroomViewModels;

namespace AcademicLife.Controllers
{
    public class ClassroomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassroomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Classrooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Classrooms.Include(c => c.ClassSubject).Include(c => c.ClassTeacher).Include(c => c.InstituteProvider);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Classrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .Include(c => c.ClassSubject)
                .Include(c => c.ClassTeacher)
                .Include(c => c.InstituteProvider)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // GET: Classrooms/Create
        public IActionResult Create()
        {

            var model = new ClassroomViewModel()
            {
                Subjects = _context.Subjects.ToList(),
                Teachers = _context.Teachers.ToList(),
                Institutes = _context.Institutes.Include(c => c.UniversityProvider).ToList()
            };
            return View(model);
        }

        // POST: Classrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassroomViewModel model)
        {
            var classroom = new Classroom()
            {
                Code = model.Code,
                ClassLocation = model.ClassLocation,
                ClassSubject = _context.Subjects.Find(model.ClassSubjectId),
                ClassTeacher = _context.Teachers.Find(model.ClassTeacherId),
                InstituteProvider = _context.Institutes.Find(model.InstituteProviderId),
                IsActive = model.IsActive,
                IsOfficial = model.IsOfficial,
                ClassDays = new List<ClassDay>()
            };
            if (ModelState.IsValid)
            {
                _context.Add(classroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Classrooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms.SingleOrDefaultAsync(m => m.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }
            ViewData["ClassSubjectId"] = new SelectList(_context.Subjects, "Id", "Id", classroom.ClassSubjectId);
            ViewData["ClassTeacherId"] = new SelectList(_context.Teachers, "Id", "Id", classroom.ClassTeacherId);
            ViewData["InstituteProviderId"] = new SelectList(_context.Institutes, "Id", "Id", classroom.InstituteProviderId);
            return View(classroom);
        }

        // POST: Classrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,ClassLocation,ClassSubjectId,ClassTeacherId,InstituteProviderId,IsOfficial,IsActive")] Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassroomExists(classroom.Id))
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
            ViewData["ClassSubjectId"] = new SelectList(_context.Subjects, "Id", "Id", classroom.ClassSubjectId);
            ViewData["ClassTeacherId"] = new SelectList(_context.Teachers, "Id", "Id", classroom.ClassTeacherId);
            ViewData["InstituteProviderId"] = new SelectList(_context.Institutes, "Id", "Id", classroom.InstituteProviderId);
            return View(classroom);
        }

        // GET: Classrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .Include(c => c.ClassSubject)
                .Include(c => c.ClassTeacher)
                .Include(c => c.InstituteProvider)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // POST: Classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classroom = await _context.Classrooms.SingleOrDefaultAsync(m => m.Id == id);
            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(e => e.Id == id);
        }
    }
}
