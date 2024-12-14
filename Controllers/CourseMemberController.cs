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
    [Authorize]
    public class CourseMemberController : Controller
    {
        private readonly AbroadContext _context;

        public CourseMemberController(AbroadContext context)
        {
            _context = context;
        }

        // GET: CourseMember
        public async Task<IActionResult> Index()
        {
            var abroadContext = _context.CourseMembers.Include(c => c.Course).Include(c => c.Member);
            return View(await abroadContext.ToListAsync());
        }

        // GET: CourseMember/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseMember = await _context.CourseMembers
                .Include(c => c.Course)
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (courseMember == null)
            {
                return NotFound();
            }

            return View(courseMember);
        }

        // GET: CourseMember/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name");
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Country");
            return View();
        }

        // POST: CourseMember/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,MemberID")] CourseMember courseMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", courseMember.CourseID);
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Country", courseMember.MemberID);
            return View(courseMember);
        }

        // GET: CourseMember/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseMember = await _context.CourseMembers.FirstOrDefaultAsync(m => m.CourseID == id);
            if (courseMember == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", courseMember.CourseID);
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Country", courseMember.MemberID);
            return View(courseMember);
        }

        // POST: CourseMember/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,MemberID")] CourseMember courseMember)
        {
            if (id != courseMember.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseMemberExists(courseMember.CourseID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", courseMember.CourseID);
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Country", courseMember.MemberID);
            return View(courseMember);
        }

        // GET: CourseMember/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseMember = await _context.CourseMembers
                .Include(c => c.Course)
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (courseMember == null)
            {
                return NotFound();
            }

            return View(courseMember);
        }

        // POST: CourseMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseMember = await _context.CourseMembers.FirstOrDefaultAsync(m => m.CourseID == id);
            if (courseMember != null)
            {
                _context.CourseMembers.Remove(courseMember);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseMemberExists(int id)
        {
            return _context.CourseMembers.Any(e => e.CourseID == id);
        }
    }
}
