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
    public class InvMstAssetTypesController : Controller
    {
        private readonly YCGInventoryContext _context;
        public ApplicationDbContext _ApplicationDbContext;

        public InvMstAssetTypesController(YCGInventoryContext context, ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
            _context = context;
        }

        public string empid_get()
        {
            string createby = User.Identity.Name;

            string EmployeeId = (from e in _ApplicationDbContext.EmpMstEmployee
                                 where e.Username == createby
                                 select e.EmployeeId).FirstOrDefault();
            return EmployeeId;
        }


        // GET: InvMstAssetTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvMstAssetTypes.ToListAsync());
        }

        // GET: InvMstAssetTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetType = await _context.InvMstAssetTypes
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (invMstAssetType == null)
            {
                return NotFound();
            }

            return View(invMstAssetType);
        }

        // GET: InvMstAssetTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvMstAssetTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeText,TypeDescription,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetType invMstAssetType)
        {
            if (ModelState.IsValid)
            {
                invMstAssetType.CreateDate = DateTime.Now;
                invMstAssetType.CreateUserId = Int16.Parse(empid_get());

                invMstAssetType.UpdateDate = DateTime.Now;
                invMstAssetType.UpdateUserId = Int16.Parse(empid_get());

                _context.Add(invMstAssetType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invMstAssetType);
        }

        // GET: InvMstAssetTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetType = await _context.InvMstAssetTypes.FindAsync(id);
            if (invMstAssetType == null)
            {
                return NotFound();
            }
            return View(invMstAssetType);
        }

        // POST: InvMstAssetTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeText,TypeDescription,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetType invMstAssetType)
        {
            if (id != invMstAssetType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    invMstAssetType.UpdateDate = DateTime.Now;
                    invMstAssetType.UpdateUserId = Int16.Parse(empid_get());

                    _context.Update(invMstAssetType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMstAssetTypeExists(invMstAssetType.TypeId))
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
            return View(invMstAssetType);
        }

        // GET: InvMstAssetTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetType = await _context.InvMstAssetTypes
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (invMstAssetType == null)
            {
                return NotFound();
            }

            return View(invMstAssetType);
        }

        // POST: InvMstAssetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invMstAssetType = await _context.InvMstAssetTypes.FindAsync(id);
            _context.InvMstAssetTypes.Remove(invMstAssetType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMstAssetTypeExists(int id)
        {
            return _context.InvMstAssetTypes.Any(e => e.TypeId == id);
        }
    }
}
