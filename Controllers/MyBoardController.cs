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
    public class MyBoardController : Controller
    {
        private readonly AbroadContext _context;

        public MyBoardController(AbroadContext context)
        {
            _context = context;
        }

        // GET: MyBoard
        public async Task<IActionResult> Index()
        {
            var abroadContext = _context.MyBoards.Include(m => m.Institution);
            return View(await abroadContext.ToListAsync());
        }

        // GET: MyBoard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myBoard = await _context.MyBoards
                .Include(m => m.Institution)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myBoard == null)
            {
                return NotFound();
            }

            return View(myBoard);
        }

        // GET: MyBoard/Create
        public IActionResult Create()
        {
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country");
            return View();
        }

        // POST: MyBoard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,InstitutionID")] MyBoard myBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country", myBoard.InstitutionID);
            return View(myBoard);
        }

        // GET: MyBoard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myBoard = await _context.MyBoards.FindAsync(id);
            if (myBoard == null)
            {
                return NotFound();
            }
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country", myBoard.InstitutionID);
            return View(myBoard);
        }

        // POST: MyBoard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,InstitutionID")] MyBoard myBoard)
        {
            if (id != myBoard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyBoardExists(myBoard.ID))
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
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country", myBoard.InstitutionID);
            return View(myBoard);
        }

        // GET: MyBoard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myBoard = await _context.MyBoards
                .Include(m => m.Institution)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myBoard == null)
            {
                return NotFound();
            }

            return View(myBoard);
        }

        // POST: MyBoard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myBoard = await _context.MyBoards.FindAsync(id);
            if (myBoard != null)
            {
                _context.MyBoards.Remove(myBoard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyBoardExists(int id)
        {
            return _context.MyBoards.Any(e => e.ID == id);
        }
    }
}
