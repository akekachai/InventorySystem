using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YcgItInventorySystem_V2.Models.Inventory;

namespace YcgItInventorySystem_V2.Controllers
{
    public class RunningInfoesController : Controller
    {
        private readonly YCGInventoryContext _context;

        public RunningInfoesController(YCGInventoryContext context)
        {
            _context = context;
        }

        // GET: RunningInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.runningInfo.ToListAsync());
        }

        // GET: RunningInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runningInfo = await _context.runningInfo
                .FirstOrDefaultAsync(m => m.InfoDesc == id);
            if (runningInfo == null)
            {
                return NotFound();
            }

            return View(runningInfo);
        }

        // GET: RunningInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RunningInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InfoDesc,Running,InfoId,Type")] RunningInfo runningInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(runningInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(runningInfo);
        }

        // GET: RunningInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runningInfo = await _context.runningInfo.FindAsync(id);
            if (runningInfo == null)
            {
                return NotFound();
            }
            return View(runningInfo);
        }

        // POST: RunningInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("InfoDesc,Running,InfoId,Type")] RunningInfo runningInfo)
        {
            if (id != runningInfo.InfoDesc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runningInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunningInfoExists(runningInfo.InfoDesc))
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
            return View(runningInfo);
        }

        // GET: RunningInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runningInfo = await _context.runningInfo
                .FirstOrDefaultAsync(m => m.InfoDesc == id);
            if (runningInfo == null)
            {
                return NotFound();
            }

            return View(runningInfo);
        }

        // POST: RunningInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var runningInfo = await _context.runningInfo.FindAsync(id);
            _context.runningInfo.Remove(runningInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunningInfoExists(string id)
        {
            return _context.runningInfo.Any(e => e.InfoDesc == id);
        }
    }
}
