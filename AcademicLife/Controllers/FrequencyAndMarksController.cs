using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademicLife.Data;
using AcademicLife.Models;
using AcademicLife.Models.StudentClassroomViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.WebEncoders.Testing;

namespace AcademicLife.Controllers
{
    public class FrequencyAndMarksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public FrequencyAndMarksController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        // GET: FrequencyAndMarks
        public async Task<IActionResult> Index()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            var applicationDbContext = _context.StudentClassrooms
                .Include(s => s.Classroom)
                .Include(s => s.Classroom.ClassSubject)
                .Include(s => s.StudentDayOfClasses)
                .Include(s => s.StudentMarks)
                .Where(s => s.Student.Id == currentUser.Id)
                .Where(s => s.Classroom.IsActive == true);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FrequencyAndMarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClassroom = await _context.StudentClassrooms
                .Include(s => s.Classroom)
                .Include(s => s.Classroom.ClassSubject)
                .Include(s => s.StudentDayOfClasses)
                .Include(s => s.StudentMarks)
                .Include(s => s.Classroom.InstituteProvider)
                .SingleOrDefaultAsync(m => m.Id == id);
            
            if (studentClassroom == null)
            {
                return NotFound();
            }

            return View(studentClassroom);
        }

        // GET: FrequencyAndMarks/Create
        public IActionResult Create()
        {
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Id");
            return View();
        }

        // POST: FrequencyAndMarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ClassroomId")] StudentClassroom studentClassroom)
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

        //GET: FrequencyAndMarks/AddMark/5
        public async Task<IActionResult> AddMark(int? id)
        {
            var studentClassroom = await _context.StudentClassrooms.SingleOrDefaultAsync(m => m.Id == id);
            if (studentClassroom == null)
            {
                return NotFound();
            }
            
            var model = new AddMarkViewModel()
            {
                StudentClassroomId = (int)id
            };
            
            return View(model);
        }
        //POST: FrequencyAndMarks/AddMark/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMark(int id, AddMarkViewModel model)
        {
            if (id != model.StudentClassroomId)
                return NotFound();

            var studentClassroom = _context.StudentClassrooms
                .Include(s => s.StudentMarks)
                .SingleOrDefault(s => s.Id == id);

            if (studentClassroom == null)
                return NotFound();

            var mark = new Mark()
            {
                Description = model.MarkDescription,
                Name = model.MarkName,
                Activities = new List<AcademicActivity>(),
                MarkPontuation = 0
            };

            if (ModelState.IsValid)
            {
                try
                {
                    studentClassroom.StudentMarks.Add(mark);
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
            return View(model);
        }

        //GET: FrequencyAndMarks/AddDayOfClass/5
        //POST: FrequencyAndMarks/AddDayOfClass/5

        // GET: FrequencyAndMarks/Edit/5
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

        // POST: FrequencyAndMarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,ClassroomId")] StudentClassroom studentClassroom)
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

        // GET: FrequencyAndMarks/Delete/5
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

        // POST: FrequencyAndMarks/Delete/5
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
