using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademicLife.Data;
using AcademicLife.Models;

namespace AcademicLife.Controllers
{
    public class StudentClassroomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentClassroomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentClassrooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentClassrooms.Include(s => s.Classroom);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentClassrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClassroom = await _context.StudentClassrooms
                .Include(s => s.Classroom)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (studentClassroom == null)
            {
                return NotFound();
            }

            return View(studentClassroom);
        }

        // GET: StudentClassrooms/Create
        public IActionResult Create()
        {
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Id");
            return View();
        }

        // POST: StudentClassrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,StudentId,ClassroomId")] StudentClassroom studentClassroom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentClassroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Id", studentClassroom.ClassroomId);
            return View(studentClassroom);
        }

        // GET: StudentClassrooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClassroom = await _context.StudentClassrooms.SingleOrDefaultAsync(m => m.Id == id);
            if (studentClassroom == null)
            {
                return NotFound();
            }
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Id", studentClassroom.ClassroomId);
            return View(studentClassroom);
        }

        // POST: StudentClassrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,StudentId,ClassroomId")] StudentClassroom studentClassroom)
        {
            if (id != studentClassroom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentClassroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentClassroomExists(studentClassroom.Id))
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
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Id", studentClassroom.ClassroomId);
            return View(studentClassroom);
        }

        // GET: StudentClassrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClassroom = await _context.StudentClassrooms
                .Include(s => s.Classroom)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (studentClassroom == null)
            {
                return NotFound();
            }

            return View(studentClassroom);
        }

        // POST: StudentClassrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentClassroom = await _context.StudentClassrooms.SingleOrDefaultAsync(m => m.Id == id);
            _context.StudentClassrooms.Remove(studentClassroom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentClassroomExists(int id)
        {
            return _context.StudentClassrooms.Any(e => e.Id == id);
        }
    }
}
