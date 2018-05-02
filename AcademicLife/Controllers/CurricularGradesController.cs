using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademicLife.Data;
using AcademicLife.Models;
using AcademicLife.Models.CurricularGradeViewModels;

namespace AcademicLife.Controllers
{
    public class CurricularGradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurricularGradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CurricularGrades
        public async Task<IActionResult> Index()
        {
            return View(await _context.CurricularGrades.ToListAsync());
        }

        // GET: CurricularGrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curricularGrade = await _context.CurricularGrades
                .SingleOrDefaultAsync(m => m.Id == id);
            if (curricularGrade == null)
            {
                return NotFound();
            }

            return View(curricularGrade);
        }

        // GET: CurricularGrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CurricularGrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,IsOfficial")] CurricularGrade curricularGrade)
        {
            curricularGrade.Subjects = new List<Subject>();
            if (ModelState.IsValid)
            {
                _context.Add(curricularGrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curricularGrade);
        }

        //GET : CurricularGrades/AddSubjects/5
        public async Task<IActionResult> AddSubject(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subjectsList = _context.Subjects
                .Include(s => s.InstituteProvider)
                .ToList();
            
            
            var model = new CurricularGradeViewModel()
            {
                Subjects = subjectsList,
                CurricularGradeId = (int)id
            };

            return View(model);
        }

        //POST : CurricularGrades/AddSubjects/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubject(int id, CurricularGradeViewModel model)
        {
            var curricularGrade = _context.CurricularGrades
                .Include(c => c.Subjects)
                .SingleOrDefault(c => c.Id == id);

            if (curricularGrade == null)
                return NotFound();

            var subject = _context.Subjects.SingleOrDefault(s => s.Id == model.SubjectId);
            if (subject == null)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                try
                {
                    curricularGrade.Subjects.Add(subject);
                    _context.Update(curricularGrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurricularGradeExists(curricularGrade.Id))
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

        // GET: CurricularGrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var curricularGrade = await _context.CurricularGrades.SingleOrDefaultAsync(m => m.Id == id);
            if (curricularGrade == null)
            {
                return NotFound();
            }
            return View(curricularGrade);
        }

        // POST: CurricularGrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,IsOfficial")] CurricularGrade curricularGrade)
        {
            if (id != curricularGrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curricularGrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurricularGradeExists(curricularGrade.Id))
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
            return View(curricularGrade);
        }

        // GET: CurricularGrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curricularGrade = await _context.CurricularGrades
                .SingleOrDefaultAsync(m => m.Id == id);
            if (curricularGrade == null)
            {
                return NotFound();
            }

            return View(curricularGrade);
        }

        // POST: CurricularGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curricularGrade = await _context.CurricularGrades.SingleOrDefaultAsync(m => m.Id == id);
            _context.CurricularGrades.Remove(curricularGrade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurricularGradeExists(int id)
        {
            return _context.CurricularGrades.Any(e => e.Id == id);
        }
    }
}
