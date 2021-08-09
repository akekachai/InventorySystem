using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YcgItInventorySystem_V2.Data;
using YcgItInventorySystem_V2.Models;
using YcgItInventorySystem_V2.Models.Inventory;

namespace YcgItInventorySystem_V2.Controllers
{
    public class InvMstAssetItemsController : Controller
    {
        private readonly YCGInventoryContext _context;
        public ApplicationDbContext _ApplicationDbContext;

        public InvMstAssetItemsController(YCGInventoryContext context, ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;

            _context = context;
        }

        // GET: InvMstAssetItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.sp_InvMstAssetItem_List.FromSqlRaw("SP_InvMstAssetItem_List").ToListAsync());
        }

        // GET: InvMstAssetItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetItem = await _context.InvMstAssetItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (invMstAssetItem == null)
            {
                return NotFound();
            }

            return View(invMstAssetItem);
        }
        public string empid_get()
        {
            string createby = User.Identity.Name;

            string EmployeeId = (from e in _ApplicationDbContext.EmpMstEmployee
                                 where e.Username == createby
                                 select e.EmployeeId).FirstOrDefault();
            return EmployeeId;
        }

        void get_list()
        {
            List<InvMstAssetType> invMstAssetType = new List<InvMstAssetType>();

            invMstAssetType = _context.InvMstAssetTypes.ToList();
            invMstAssetType.Insert(0, new InvMstAssetType { TypeText = " โปรดเลือก ประเภท ", TypeId = 0 });
            ViewBag.ListinvMstAssetType = invMstAssetType;

            List<InvMstAssetCatagory> invMstAssetCatagory = new List<InvMstAssetCatagory>();
            invMstAssetCatagory = _context.InvMstAssetCatagories.ToList();
            invMstAssetCatagory.Insert(0, new InvMstAssetCatagory { CatagoryText = " โปรดเลือก กลุ่ม ", CatagoryId = 0 });
            ViewBag.ListinvMstAssetCatagory = invMstAssetCatagory;


            List<InvMstAssetBrand> invMstAssetBrand = new List<InvMstAssetBrand>();
            invMstAssetBrand = _context.InvMstAssetBrands.ToList();
            invMstAssetBrand.Insert(0, new InvMstAssetBrand { BrandText = " โปรดเลือก ยี่ห้อ ", BrandId = 0 });
            ViewBag.ListinvMstAssetBrand = invMstAssetBrand;


            List<InvMstAssetModel> invMstAssetModel = new List<InvMstAssetModel>();
            invMstAssetModel = _context.InvMstAssetModels.ToList();
            invMstAssetModel.Insert(0, new InvMstAssetModel { ModelText = " โปรดเลือก รุ่น ", ModelId = 0 });
            ViewBag.ListinvMstAssetModel = invMstAssetModel;

            List<EmpMstCompany> empMstCompanies = new List<EmpMstCompany>();
            empMstCompanies = _ApplicationDbContext.EmpMstCompany.ToList();

            ViewBag.ListempMstCompanies = empMstCompanies;

            List<EmpMstLocation> empMstLocation = new List<EmpMstLocation>();
            empMstLocation = _ApplicationDbContext.EmpMstLocation.ToList();
            ViewBag.ListempMstLocation = empMstLocation;
        }
        public class employeeList
        {
            public string empcode { get; set; }

            public string empname { get; set; }
        }
        // GET: InvMstAssetItems/Create
        public IActionResult Create()
        {
            get_list();

            return View();
        }

        // POST: InvMstAssetItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemText,ItemDescription,TypeId,CatagoryId,BrandId,ModelId,ItemExpireDateFlag,ItemContractFlag,ItemUnlimitFlag,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetItem invMstAssetItem)
        {
            if (ModelState.IsValid)
            {
                int maxItemId = _context.InvMstAssetItems.Max(p => p.ItemId);

                invMstAssetItem.ItemId = maxItemId + 1;

                invMstAssetItem.CreateDate = DateTime.Now;
                invMstAssetItem.CreateUserId = Int16.Parse(empid_get());

                invMstAssetItem.UpdateDate = DateTime.Now;
                invMstAssetItem.UpdateUserId = Int16.Parse(empid_get());

                _context.Add(invMstAssetItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { id = invMstAssetItem.ItemId });
            }
            return View(invMstAssetItem);
        }

        [HttpPost]
        public string Add_Serial(string Company, string Location, string ItemId, string SerialNo, string AssetNo, string ContractNo, string ContractStartDate, string ContractExpireDate, string SerialCost, string AvailableQty)
        {
            
            var status = "";
            try
            {
                var chkSerial = (from x in _context.InvMstAssetItemSerials
                                 where x.ItemId == int.Parse(ItemId) && x.ItemSerialNo == SerialNo
                                 select x).ToList();

                if (chkSerial.Count != 0)
                {
                    InvMstAssetItemSerial invMstAssetItemSerials = new InvMstAssetItemSerial();
                    invMstAssetItemSerials.ItemId = int.Parse(ItemId);
                    invMstAssetItemSerials.ItemSerialNo = SerialNo;
                    invMstAssetItemSerials.ItemAssetNo = AssetNo;
                    invMstAssetItemSerials.ItemContractNo = ContractNo;
                    invMstAssetItemSerials.ItemContractStartDate = ContractStartDate;
                    invMstAssetItemSerials.ItemContractExpireDate = ContractExpireDate;
                    invMstAssetItemSerials.ItemSerialCost = decimal.Parse(SerialCost);
                    invMstAssetItemSerials.ItemAvailableQty = int.Parse(AvailableQty);
                    invMstAssetItemSerials.CompCode = int.Parse(Company);
                    invMstAssetItemSerials.LocationId = int.Parse(Location);

                    invMstAssetItemSerials.ActiveFlag = "Y";

                    invMstAssetItemSerials.CreateDate = DateTime.Now;
                    invMstAssetItemSerials.CreateUserId = Int16.Parse(empid_get());

                    invMstAssetItemSerials.UpdateDate = DateTime.Now;
                    invMstAssetItemSerials.UpdateUserId = Int16.Parse(empid_get());

                    _context.Add(invMstAssetItemSerials);
                    _context.SaveChanges();
                    status = "success";
                }
                else
                {
                    InvMstAssetItemSerial _invMstAssetItemSerial = _context.InvMstAssetItemSerials.Find(ItemId, SerialNo);
                    _invMstAssetItemSerial.ItemAssetNo = AssetNo;
                    _invMstAssetItemSerial.ItemContractNo = ContractNo;
                    _invMstAssetItemSerial.ItemContractStartDate = ContractStartDate;
                    _invMstAssetItemSerial.ItemContractExpireDate = ContractExpireDate;
                    _invMstAssetItemSerial.ItemSerialCost = decimal.Parse(SerialCost);
                    _invMstAssetItemSerial.ItemAvailableQty = int.Parse(AvailableQty);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return (status);
        }

        public class itemserial 
            {
            public string serialno { get; set; }
            public string assetno { get; set; }
            public string contractno { get; set; }

            public string ctstart { get; set; }
            public string ctend { get; set; }

            public string cost { get; set; }
            public string qty { get; set; }
        }

        [HttpGet]
        public JsonResult Get_Serial(int Itemid)
        {

          List<InvMstAssetItemSerial> invmstassetitemserial =   _context.InvMstAssetItemSerials.Where(x => x.ItemId == Itemid).OrderByDescending(x => x.UpdateDate).ToList();
           
            List<itemserial> _itemserial = new List<itemserial>();

         

            foreach (var x in invmstassetitemserial)
            {
                 
                _itemserial.Insert(0, new itemserial { serialno = x.ItemSerialNo, assetno = x.ItemAssetNo , contractno = x.ItemContractNo , ctstart = x.ItemContractStartDate , ctend = x.ItemContractExpireDate, cost = x.ItemSerialCost.ToString() , qty = x.ItemAvailableQty.ToString() });
            }
                return Json(_itemserial.ToList());
        }

        // GET: InvMstAssetItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetItem = await _context.InvMstAssetItems.FindAsync(id);
            if (invMstAssetItem == null)
            {
            
                return NotFound();
            }
                    get_list();

            List<InvMstAssetItemSerial> invMstAssetItemSerial = new List<InvMstAssetItemSerial>();
            invMstAssetItemSerial = _context.InvMstAssetItemSerials.Where(x => x.ItemId == id).ToList();
            ViewBag.AssetItemSerial = invMstAssetItemSerial;

            return View(invMstAssetItem);
        }

        // POST: InvMstAssetItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemText,ItemDescription,TypeId,CatagoryId,BrandId,ModelId,ItemExpireDateFlag,ItemContractFlag,ItemUnlimitFlag,CreateDate,CreateUserId,UpdateDate,UpdateUserId,ActiveFlag")] InvMstAssetItem invMstAssetItem)
        {
            if (id != invMstAssetItem.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    invMstAssetItem.UpdateDate = DateTime.Now;
                    invMstAssetItem.UpdateUserId = Int16.Parse(empid_get());

                    _context.Update(invMstAssetItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMstAssetItemExists(invMstAssetItem.ItemId))
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
            return View(invMstAssetItem);
        }

        // GET: InvMstAssetItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMstAssetItem = await _context.InvMstAssetItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (invMstAssetItem == null)
            {
                return NotFound();
            }

            return View(invMstAssetItem);
        }

        // POST: InvMstAssetItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invMstAssetItem = await _context.InvMstAssetItems.FindAsync(id);
            _context.InvMstAssetItems.Remove(invMstAssetItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMstAssetItemExists(int id)
        {
            return _context.InvMstAssetItems.Any(e => e.ItemId == id);
        }
    }
}
