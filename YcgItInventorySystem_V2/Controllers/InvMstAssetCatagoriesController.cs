using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YcgItInventorySystem_V2.Data;
using YcgItInventorySystem_V2.Models.Inventory;

namespace YcgItInventorySystem_V2.Controllers
{
    public class InvMstAssetCatagoriesController : Controller
    {
        private readonly YCGInventoryContext _context;
        public ApplicationDbContext _ApplicationDbContext;
        public string empid_get()
        {
            string createby = User.Identity.Name;

            string EmployeeId = (from e in _ApplicationDbContext.EmpMstEmployee
                                 where e.Username == createby
                                 select e.EmployeeId).FirstOrDefault();
            return EmployeeId;
        }
        public InvMstAssetCatagoriesController(YCGInventoryContext context, ApplicationDbContext applicationDbContext)
        {
            _context = context;
            _ApplicationDbContext = applicationDbContext;
        }

        // GET: InvMstAssetCatagories
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvMstAssetCatagories.ToListAsync());
        }

        // GET: InvMstAssetCatagories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetCatagory = await _context.InvMstAssetCatagories
                .FirstOrDefaultAsync(m => m.CatagoryId == id);
            if (invMstAssetCatagory == null)
            {
                return NotFound();
            }

            return View(invMstAssetCatagory);
        }

        // GET: InvMstAssetCatagories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvMstAssetCatagories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatagoryId,CatagoryText,CatagoryDescription,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetCatagory invMstAssetCatagory)
        {
            if (ModelState.IsValid)
            {

                invMstAssetCatagory.CreateDate = DateTime.Now;
                invMstAssetCatagory.CreateUserId = Int16.Parse(empid_get());

                invMstAssetCatagory.UpdateDate = DateTime.Now;
                invMstAssetCatagory.UpdateUserId = Int16.Parse(empid_get());

                _context.Add(invMstAssetCatagory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invMstAssetCatagory);
        }

        // GET: InvMstAssetCatagories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetCatagory = await _context.InvMstAssetCatagories.FindAsync(id);
            if (invMstAssetCatagory == null)
            {
                return NotFound();
            }
            return View(invMstAssetCatagory);
        }

        // POST: InvMstAssetCatagories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatagoryId,CatagoryText,CatagoryDescription,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetCatagory invMstAssetCatagory)
        {
            if (id != invMstAssetCatagory.CatagoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    invMstAssetCatagory.UpdateDate = DateTime.Now;
                    invMstAssetCatagory.UpdateUserId = Int16.Parse(empid_get());

                    _context.Update(invMstAssetCatagory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMstAssetCatagoryExists(invMstAssetCatagory.CatagoryId))
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
            return View(invMstAssetCatagory);
        }

        // GET: InvMstAssetCatagories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetCatagory = await _context.InvMstAssetCatagories
                .FirstOrDefaultAsync(m => m.CatagoryId == id);
            if (invMstAssetCatagory == null)
            {
                return NotFound();
            }

            return View(invMstAssetCatagory);
        }

        // POST: InvMstAssetCatagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invMstAssetCatagory = await _context.InvMstAssetCatagories.FindAsync(id);
            _context.InvMstAssetCatagories.Remove(invMstAssetCatagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMstAssetCatagoryExists(int id)
        {
            return _context.InvMstAssetCatagories.Any(e => e.CatagoryId == id);
        }
    }
}
