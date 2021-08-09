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
    public class InvMstAssetModelsController : Controller
    {
        private readonly YCGInventoryContext _context;
        public ApplicationDbContext _ApplicationDbContext;
        public InvMstAssetModelsController(YCGInventoryContext context, ApplicationDbContext applicationDbContext)
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
        // GET: InvMstAssetModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvMstAssetModels.ToListAsync());
        }

        // GET: InvMstAssetModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetModel = await _context.InvMstAssetModels
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (invMstAssetModel == null)
            {
                return NotFound();
            }

            return View(invMstAssetModel);
        }

        // GET: InvMstAssetModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvMstAssetModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelId,ModelText,ModelDescription,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetModel invMstAssetModel)
        {
            if (ModelState.IsValid)
            {
                invMstAssetModel.CreateDate = DateTime.Now;
                invMstAssetModel.CreateUserId = Int16.Parse(empid_get());

                invMstAssetModel.UpdateDate = DateTime.Now;
                invMstAssetModel.UpdateUserId = Int16.Parse(empid_get());

                _context.Add(invMstAssetModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invMstAssetModel);
        }

        // GET: InvMstAssetModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetModel = await _context.InvMstAssetModels.FindAsync(id);
            if (invMstAssetModel == null)
            {
                return NotFound();
            }
            return View(invMstAssetModel);
        }

        // POST: InvMstAssetModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModelId,ModelText,ModelDescription,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetModel invMstAssetModel)
        {
            if (id != invMstAssetModel.ModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    invMstAssetModel.UpdateDate = DateTime.Now;
                    invMstAssetModel.UpdateUserId = Int16.Parse(empid_get());

                    _context.Update(invMstAssetModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMstAssetModelExists(invMstAssetModel.ModelId))
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
            return View(invMstAssetModel);
        }

        // GET: InvMstAssetModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetModel = await _context.InvMstAssetModels
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (invMstAssetModel == null)
            {
                return NotFound();
            }

            return View(invMstAssetModel);
        }

        // POST: InvMstAssetModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invMstAssetModel = await _context.InvMstAssetModels.FindAsync(id);
            _context.InvMstAssetModels.Remove(invMstAssetModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMstAssetModelExists(int id)
        {
            return _context.InvMstAssetModels.Any(e => e.ModelId == id);
        }
    }
}
