using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademicLife.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademicLife.Controllers
{
    [AllowAnonymous]
    public class MarkCalculatorController : Controller
    {
        // GET: MarkCalculator
        public ActionResult Index()
        {
            var model = new MarkCalculatorViewModel()
            {
                
            };
            return View();
        }

        [HttpPost]
        public ActionResult Index(MarkCalculatorViewModel model)
        {
            var mAb = (model.Ab1 + model.Ab2) / 2;
            var desiredM = model.DesiredFinalMark * 10;
            var notaFinal = (desiredM - (6 * mAb)) / 4;
            model.FinalMark = notaFinal;
            return View(model);
        }

        // GET: MarkCalculator/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarkCalculator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarkCalculator/Create
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

        // GET: MarkCalculator/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MarkCalculator/Edit/5
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

        // GET: MarkCalculator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MarkCalculator/Delete/5
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