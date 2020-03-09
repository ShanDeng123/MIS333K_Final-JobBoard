using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;

namespace sp19team23finalproject.Controllers
{
 
    public class PositionMajorsController : Controller
    {
        private readonly AppDbContext _context;

        public PositionMajorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PositionMajors
        public async Task<IActionResult> Index()
        {
            return View(await _context.PositionMajors.ToListAsync());
        }

        // GET: PositionMajors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionMajor = await _context.PositionMajors
                .FirstOrDefaultAsync(m => m.PositionMajorID == id);
            if (positionMajor == null)
            {
                return NotFound();
            }

            return View(positionMajor);
        }

        // GET: PositionMajors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PositionMajors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionMajorID")] PositionMajor positionMajor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(positionMajor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(positionMajor);
        }

        // GET: PositionMajors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionMajor = await _context.PositionMajors.FindAsync(id);
            if (positionMajor == null)
            {
                return NotFound();
            }
            return View(positionMajor);
        }

        // POST: PositionMajors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionMajorID")] PositionMajor positionMajor)
        {
            if (id != positionMajor.PositionMajorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(positionMajor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionMajorExists(positionMajor.PositionMajorID))
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
            return View(positionMajor);
        }

        // GET: PositionMajors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionMajor = await _context.PositionMajors
                .FirstOrDefaultAsync(m => m.PositionMajorID == id);
            if (positionMajor == null)
            {
                return NotFound();
            }

            return View(positionMajor);
        }

        // POST: PositionMajors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var positionMajor = await _context.PositionMajors.FindAsync(id);
            _context.PositionMajors.Remove(positionMajor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionMajorExists(int id)
        {
            return _context.PositionMajors.Any(e => e.PositionMajorID == id);
        }
    }
}
