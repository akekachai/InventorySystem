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
    public class InvMstAssetBrandsController : Controller
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
        public InvMstAssetBrandsController(YCGInventoryContext context , ApplicationDbContext applicationDbContext)
        {
            _context = context;
            _ApplicationDbContext = applicationDbContext;
        }

        // GET: InvMstAssetBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvMstAssetBrands.ToListAsync());
        }

        // GET: InvMstAssetBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetBrand = await _context.InvMstAssetBrands
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (invMstAssetBrand == null)
            {
                return NotFound();
            }

            return View(invMstAssetBrand);
        }

        // GET: InvMstAssetBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvMstAssetBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,BrandText,BrandDescription,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetBrand invMstAssetBrand)
        {
            if (ModelState.IsValid)
            {
                invMstAssetBrand.CreateDate = DateTime.Now;
                invMstAssetBrand.CreateUserId = Int16.Parse(empid_get());

                invMstAssetBrand.UpdateDate = DateTime.Now;
                invMstAssetBrand.UpdateUserId = Int16.Parse(empid_get());


                _context.Add(invMstAssetBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invMstAssetBrand);
        }

        // GET: InvMstAssetBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetBrand = await _context.InvMstAssetBrands.FindAsync(id);
            if (invMstAssetBrand == null)
            {
                return NotFound();
            }
            return View(invMstAssetBrand);
        }

        // POST: InvMstAssetBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,BrandText,BrandDescription,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetBrand invMstAssetBrand)
        {
            if (id != invMstAssetBrand.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    invMstAssetBrand.UpdateDate = DateTime.Now;
                    invMstAssetBrand.UpdateUserId = Int16.Parse(empid_get());

                    _context.Update(invMstAssetBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMstAssetBrandExists(invMstAssetBrand.BrandId))
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
            return View(invMstAssetBrand);
        }

        // GET: InvMstAssetBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetBrand = await _context.InvMstAssetBrands
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (invMstAssetBrand == null)
            {
                return NotFound();
            }

            return View(invMstAssetBrand);
        }

        // POST: InvMstAssetBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invMstAssetBrand = await _context.InvMstAssetBrands.FindAsync(id);
            _context.InvMstAssetBrands.Remove(invMstAssetBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMstAssetBrandExists(int id)
        {
            return _context.InvMstAssetBrands.Any(e => e.BrandId == id);
        }
    }
}
