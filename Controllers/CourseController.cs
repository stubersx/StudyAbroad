using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyAbroad.Models;
using StudyAbroad.ViewModel;

namespace StudyAbroad.Controllers
{
    public class CourseController : Controller
    {
        private readonly AbroadContext _context;

        public CourseController(AbroadContext context)
        {
            _context = context;
        }

        public IActionResult InstCount()
        {
            IQueryable<InstitutionGroup> data = (
                from query in _context.Courses.Include(e => e.Institution)
                group query by query.Institution.Name into instGroup
                select new InstitutionGroup()
                {
                    InstitutionID = instGroup.Key,
                    InstitutionCount = instGroup.Count()
                })
                .OrderBy(q => q.InstitutionID);
            return View(data.ToList());
        }

        // GET: Course
        public async Task<IActionResult> Index()
        {
            var abroadContext = _context.Courses.Include(c => c.Institution);
            return View(await abroadContext.ToListAsync());
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Institution)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Course/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,Name,ContactHours,Duration,Tuition,Prerequisites,Description,Note,InstitutionID")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country", course.InstitutionID);
            return View(course);
        }

        // GET: Course/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country", course.InstitutionID);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,Name,ContactHours,Duration,Tuition,Prerequisites,Description,Note,InstitutionID")] Course course)
        {
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseID))
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
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country", course.InstitutionID);
            return View(course);
        }

        // GET: Course/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Institution)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}
