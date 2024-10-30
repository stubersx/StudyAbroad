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
            var abroadContext = _context.MyBoards.Include(m => m.Course).Include(m => m.Institution).Include(m => m.Member);
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
                .Include(m => m.Course)
                .Include(m => m.Institution)
                .Include(m => m.Member)
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name");
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country");
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Country");
            return View();
        }

        // POST: MyBoard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MemberID,InstitutionID,CourseID,Semester,Year,HousingType,HousingCost,AdditionalCost,MoveInDate,PropertyOwner,Contact,HousingWebsite,AddressLine1,AddressLine2,City,Region,ZipCode,Country,MealPlan,MealCost,Note")] MyBoard myBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", myBoard.CourseID);
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country", myBoard.InstitutionID);
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Country", myBoard.MemberID);
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", myBoard.CourseID);
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country", myBoard.InstitutionID);
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Country", myBoard.MemberID);
            return View(myBoard);
        }

        // POST: MyBoard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MemberID,InstitutionID,CourseID,Semester,Year,HousingType,HousingCost,AdditionalCost,MoveInDate,PropertyOwner,Contact,HousingWebsite,AddressLine1,AddressLine2,City,Region,ZipCode,Country,MealPlan,MealCost,Note")] MyBoard myBoard)
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", myBoard.CourseID);
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "InstitutionID", "Country", myBoard.InstitutionID);
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Country", myBoard.MemberID);
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
                .Include(m => m.Course)
                .Include(m => m.Institution)
                .Include(m => m.Member)
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
