using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyAbroad.Models;

namespace StudyAbroad.Controllers
{
    public class InstitutionController : Controller
    {
        private readonly AbroadContext _context;

        public InstitutionController(AbroadContext context)
        {
            _context = context;
        }

        // GET: Institution
        public async Task<IActionResult> Index()
        {
            return View(await _context.Institutions.ToListAsync());
        }

        // GET: Institution/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institution = await _context.Institutions
                .FirstOrDefaultAsync(m => m.InstitutionID == id);
            if (institution == null)
            {
                return NotFound();
            }

            return View(institution);
        }

        // GET: Institution/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institution/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutionID,Name,Education,Type,Country,Region,URL,Note")] Institution institution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institution);
        }

        // GET: Institution/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institution = await _context.Institutions.FindAsync(id);
            if (institution == null)
            {
                return NotFound();
            }
            return View(institution);
        }

        // POST: Institution/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstitutionID,Name,Education,Type,Country,Region,URL,Note")] Institution institution)
        {
            if (id != institution.InstitutionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionExists(institution.InstitutionID))
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
            return View(institution);
        }

        // GET: Institution/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institution = await _context.Institutions
                .FirstOrDefaultAsync(m => m.InstitutionID == id);
            if (institution == null)
            {
                return NotFound();
            }

            return View(institution);
        }

        // POST: Institution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institution = await _context.Institutions.FindAsync(id);
            if (institution != null)
            {
                _context.Institutions.Remove(institution);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionExists(int id)
        {
            return _context.Institutions.Any(e => e.InstitutionID == id);
        }
    }
}
