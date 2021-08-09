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
    public class SP_Control_ReportController : Controller
    {
        private readonly YCGInventoryContext _context;

        public SP_Control_ReportController(YCGInventoryContext context)
        {
            _context = context;
        }

        // GET: SP_Control_Report
        public IActionResult Index()
        {
            List<SP_Control_Report> sp_Control_Report =  _context.SP_Control_Report.FromSqlRaw("SP_Control_Report").ToList();
            //select rfi.ControlNo , emp.EmployeeNameFirst + ' ' + emp.EmployeeNameLast as EmpName, rfd.ActionsUp,br.BrandText, ai.ItemText, rfd.ItemSerialNo, rfd.ItemAssetNo, rfi.ReqNo from Req_FormIT rfi inner join Req_FormITDetails rfd on rfi.ReqNo = rfd.ReqNo inner join InvMstAssetItemSerial ais on rfd.ItemSerialNo = ais.ItemSerialNo inner join InvMstAssetItem ai on ais.ItemId = ai.ItemId inner join InvMstAssetBrand br on ai.BrandId = br.BrandId inner join[YCGEmployee].[dbo].[EmpMstEmployee] emp on rfi.ITProcessBy = emp.EmployeeId  where ControlNo is not null ").ToList();

            ViewBag.SP_Control_Report_List = sp_Control_Report;
           return View();
        }

        // GET: SP_Control_Report/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sP_Control_Report = await _context.SP_Control_Report
                .FirstOrDefaultAsync(m => m.ControlNo == id);
            if (sP_Control_Report == null)
            {
                return NotFound();
            }

            return View(sP_Control_Report);
        }

        // GET: SP_Control_Report/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SP_Control_Report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ControlNo,EmpName,ActionsUp,BrandText,ItemText,ItemSerialNo,ItemAssetNo,ReqNo")] SP_Control_Report sP_Control_Report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sP_Control_Report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sP_Control_Report);
        }

        // GET: SP_Control_Report/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sP_Control_Report = await _context.SP_Control_Report.FindAsync(id);
            if (sP_Control_Report == null)
            {
                return NotFound();
            }
            return View(sP_Control_Report);
        }

        // POST: SP_Control_Report/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ControlNo,EmpName,ActionsUp,BrandText,ItemText,ItemSerialNo,ItemAssetNo,ReqNo")] SP_Control_Report sP_Control_Report)
        {
            if (id != sP_Control_Report.ControlNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sP_Control_Report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SP_Control_ReportExists(sP_Control_Report.ControlNo))
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
            return View(sP_Control_Report);
        }

        // GET: SP_Control_Report/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sP_Control_Report = await _context.SP_Control_Report
                .FirstOrDefaultAsync(m => m.ControlNo == id);
            if (sP_Control_Report == null)
            {
                return NotFound();
            }

            return View(sP_Control_Report);
        }

        // POST: SP_Control_Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sP_Control_Report = await _context.SP_Control_Report.FindAsync(id);
            _context.SP_Control_Report.Remove(sP_Control_Report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SP_Control_ReportExists(string id)
        {
            return _context.SP_Control_Report.Any(e => e.ControlNo == id);
        }
    }
}
