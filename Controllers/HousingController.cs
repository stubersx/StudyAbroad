using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyAbroad.Models;

namespace StudyAbroad.Controllers
{
    public class HousingController : Controller
    {
        private readonly AbroadContext _context;

        public HousingController(AbroadContext context)
        {
            _context = context;
        }

        // GET: Housing
        public async Task<IActionResult> Index()
        {
            return View(await _context.Housings.ToListAsync());
        }

        // GET: Housing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housing = await _context.Housings
                .FirstOrDefaultAsync(m => m.HousingID == id);
            if (housing == null)
            {
                return NotFound();
            }

            return View(housing);
        }

        // GET: Housing/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Housing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("HousingID,Semester,Year,HousingType,HousingCost,AdditionalCost,MoveInDate,Contact,HousingWebsite,AddressLine1,AddressLine2,City,Region,ZipCode,Country,MealPlan,MealCost,Note")] Housing housing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(housing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(housing);
        }

        // GET: Housing/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housing = await _context.Housings.FindAsync(id);
            if (housing == null)
            {
                return NotFound();
            }
            return View(housing);
        }

        // POST: Housing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("HousingID,Semester,Year,HousingType,HousingCost,AdditionalCost,MoveInDate,Contact,HousingWebsite,AddressLine1,AddressLine2,City,Region,ZipCode,Country,MealPlan,MealCost,Note")] Housing housing)
        {
            if (id != housing.HousingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(housing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HousingExists(housing.HousingID))
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
            return View(housing);
        }

        // GET: Housing/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housing = await _context.Housings
                .FirstOrDefaultAsync(m => m.HousingID == id);
            if (housing == null)
            {
                return NotFound();
            }

            return View(housing);
        }

        // POST: Housing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var housing = await _context.Housings.FindAsync(id);
            if (housing != null)
            {
                _context.Housings.Remove(housing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HousingExists(int id)
        {
            return _context.Housings.Any(e => e.HousingID == id);
        }
    }
}
