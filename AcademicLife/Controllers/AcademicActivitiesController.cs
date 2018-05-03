using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademicLife.Data;
using AcademicLife.Models;
using AcademicLife.Models.AcademicActivityViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AcademicLife.Controllers
{
    [Authorize]
    public class AcademicActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public AcademicActivitiesController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        // GET: AcademicActivities
        public async Task<IActionResult> Index()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var activities = _context.AcademicActivities
                .Include(s => s.StudentClassroom)
                .Include(s => s.StudentClassroom.Classroom)
                .Include(s => s.StudentClassroom.Classroom.InstituteProvider)
                .OrderBy(s => s.StudentClassroom.Id)
                .Where(s => s.StudentClassroom.Student.Id == currentUser.Id);

            var studentClassrooms = _context.StudentClassrooms
                .Include(s => s.Classroom)
                .Include(s => s.Classroom.ClassSubject)
                .Include(s => s.StudentDayOfClasses)
                .Include(s => s.StudentMarks)
                .Include(s => s.Classroom.InstituteProvider)
                .Where(s => s.Student.Id == currentUser.Id)
                .Where(s => s.Classroom.IsActive == true)
                .ToList();

            var model = new AcademicActivityViewModel()
            {
                AcademicActivities = activities,
                StudentClassrooms = studentClassrooms
            };
            return View(model);
        }

        // GET: AcademicActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicActivity = await _context.AcademicActivities
                .SingleOrDefaultAsync(m => m.Id == id);
            if (academicActivity == null)
            {
                return NotFound();
            }

            return View(academicActivity);
        }

        // GET: AcademicActivities/Create
        public IActionResult Create(int studentClassroomId)
        {
            var marks = _context.StudentClassrooms
                .Include(s => s.StudentMarks)
                .SingleOrDefault(s => s.Id == studentClassroomId).StudentMarks;

            var model = new AcademicActivityViewModel()
            {
                Marks = marks,
                StudentClassroomId = studentClassroomId
            };
            return View(model);
        }

        // POST: AcademicActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AcademicActivityViewModel model)
        {
            var academicActivity = new AcademicActivity()
            {
                Name = model.Name,
                Description = model.Description,
                MarkId = model.MarkId,
                Pontuation = model.Pontuation,
                StudentClassroomId = model.StudentClassroomId
            };

            var mark = _context.Grades
                .Include(s => s.Activities)
                .SingleOrDefault(s => s.Id == model.MarkId);
            mark.Activities.Add(academicActivity);

            if (ModelState.IsValid)
            {
                _context.Update(mark);
                _context.Add(academicActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: AcademicActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicActivity = await _context.AcademicActivities.SingleOrDefaultAsync(m => m.Id == id);
            if (academicActivity == null)
            {
                return NotFound();
            }
            return View(academicActivity);
        }

        // POST: AcademicActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Pontuation")] AcademicActivity academicActivity)
        {
            if (id != academicActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicActivityExists(academicActivity.Id))
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
            return View(academicActivity);
        }

        // GET: AcademicActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicActivity = await _context.AcademicActivities
                .SingleOrDefaultAsync(m => m.Id == id);
            if (academicActivity == null)
            {
                return NotFound();
            }

            return View(academicActivity);
        }

        // POST: AcademicActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicActivity = await _context.AcademicActivities.SingleOrDefaultAsync(m => m.Id == id);
            _context.AcademicActivities.Remove(academicActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicActivityExists(int id)
        {
            return _context.AcademicActivities.Any(e => e.Id == id);
        }
    }
}
