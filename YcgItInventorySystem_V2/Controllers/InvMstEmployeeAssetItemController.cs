using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YcgItInventorySystem_V2.Data;
using YcgItInventorySystem_V2.Models;
using YcgItInventorySystem_V2.Models.Inventory;
using YcgItInventorySystem_V2.Services;
namespace YcgItInventorySystem_V2.Controllers
{
    public class InvMstEmployeeAssetItemController : Controller
    {
        public YCGInventoryContext _YCGInventoryContext;
        public ApplicationDbContext _ApplicationDbContext;
        private readonly IEmpservice _IEmpservice;
        public InvMstEmployeeAssetItemController(YCGInventoryContext ycginventoryContext, ApplicationDbContext applicationDbContext, IEmpservice iempservice)
        {
            _ApplicationDbContext = applicationDbContext;
            _YCGInventoryContext = ycginventoryContext;
            _IEmpservice = iempservice;
        }
        public string empid_get()
        {
            string createby = User.Identity.Name;

            string EmployeeId = (from e in _ApplicationDbContext.EmpMstEmployee
                                 where e.Username == createby
                                 select e.EmployeeId).FirstOrDefault();
            return EmployeeId;
        }
        public IActionResult Index()
        {
            //List<InvMstEmployeeAssetItem> InvMstEmployeeAssetItem = _YCGInventoryContext.InvMstEmployeeAssetItems.Take(100).ToList();
            //return View(InvMstEmployeeAssetItem);
            List<SP_EmpHandleAsset> sp_EmpHandleAsset = _YCGInventoryContext.SP_EmpHandleAsset.FromSqlRaw("SP_EmpHandleAsset").ToList();
            return View(sp_EmpHandleAsset);
        }


        [HttpGet]
        public string get_comment(string empid)
        {
            string comment = "";
            List<InvMstEmployeeAssetComment> invMstEmployeeAssetComment = new List<InvMstEmployeeAssetComment>();
            invMstEmployeeAssetComment = _YCGInventoryContext.InvMstEmployeeAssetComments.Where(x => x.EmployeeId ==  empid).OrderByDescending(x => x.TransactionDate).Take(1).ToList();

            foreach (var x in invMstEmployeeAssetComment)
            {
                comment = comment + x.CommentText;
            }

            return comment;
        }

        // GET: InvMstEmployeeAssetItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvMstEmployeeAssetItemController/Create
        public ActionResult Create()
        {
            List<SP_EmpMstEmployeeActive> sp_EmpMstEmployeeActives = new List<SP_EmpMstEmployeeActive>();
            sp_EmpMstEmployeeActives = _ApplicationDbContext.SP_EmpMstEmployeeActive.FromSqlRaw("SP_EmpMstEmployeeActive").ToList();
            ViewBag.Listsp_EmpMstEmployeeActives = sp_EmpMstEmployeeActives;

            //List<InvMstEmployeeAssetItem> invMstEmployeeAssetItem = _YCGInventoryContext.InvMstEmployeeAssetItems.Where(x => x.EmployeeId == id.ToString()).Take(1).ToList();

            List<SP_EmpHandleAsset_Detail> sp_EmpHandleAsset_Detail = new List<SP_EmpHandleAsset_Detail>();
            //sp_EmpHandleAsset_Detail = _YCGInventoryContext.SP_EmpHandleAsset_Detail.FromSqlRaw("SP_EmpHandleAsset_Detail " + id).ToList();
            //var handcount = sp_EmpHandleAsset_Detail.Count;
            string Location = _IEmpservice.EmpLocation_get(User.Identity.Name);
            List<SP_AssetsRemaining> SP_AssetsRemaining = _YCGInventoryContext.SP_AssetsRemaining.FromSqlRaw("SP_AssetsRemaining_All " + Location).ToList();

            foreach (var x in SP_AssetsRemaining)
            {

                sp_EmpHandleAsset_Detail.Insert(0, new SP_EmpHandleAsset_Detail { EmployeeId = "", EmpName = "", ItemId = x.ItemId, ItemText = x.itemtext, ItemSerialNo = x.ItemSerialNo, ItemAssetNo = x.ItemAssetNo });

            }

         

            //    ViewData["Comment"] = "test \n test2";

            ViewBag.ListEmpHandleAsset_Detail = sp_EmpHandleAsset_Detail;


            return View();
        }

        // POST: InvMstEmployeeAssetItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvMstEmployeeAssetItemController/Edit/5
        public ActionResult Edit(int id)
        {
            List<InvMstEmployeeAssetItem> invMstEmployeeAssetItem =  _YCGInventoryContext.InvMstEmployeeAssetItems.Where(x => x.EmployeeId == id.ToString()).Take(1).ToList();

            List<SP_EmpHandleAsset_Detail> sp_EmpHandleAsset_Detail = new List<SP_EmpHandleAsset_Detail>();
            sp_EmpHandleAsset_Detail = _YCGInventoryContext.SP_EmpHandleAsset_Detail.FromSqlRaw("SP_EmpHandleAsset_Detail "+ id).ToList();
            var handcount = sp_EmpHandleAsset_Detail.Count;
            string Location = _IEmpservice.EmpLocation_get(User.Identity.Name);
            List<SP_AssetsRemaining> SP_AssetsRemaining = _YCGInventoryContext.SP_AssetsRemaining.FromSqlRaw("SP_AssetsRemaining_All " + Location ).ToList();
            
            foreach (var x in SP_AssetsRemaining)
            {
 
                sp_EmpHandleAsset_Detail.Insert(handcount, new SP_EmpHandleAsset_Detail {   EmployeeId ="",EmpName="",ItemId = x.ItemId , ItemText = x.itemtext , ItemSerialNo = x.ItemSerialNo ,ItemAssetNo = x.ItemAssetNo   });

            }

            List<InvMstEmployeeAssetComment> invMstEmployeeAssetComment = new List<InvMstEmployeeAssetComment>();
            invMstEmployeeAssetComment = _YCGInventoryContext.InvMstEmployeeAssetComments.Where(x => x.EmployeeId == id.ToString()).OrderByDescending(x => x.TransactionDate).Take(1).ToList();
            var comment = "";
            foreach (var x in invMstEmployeeAssetComment)
            {
                comment = comment + x.CommentText;
            }

            ViewBag.comment = comment;

            //    ViewData["Comment"] = "test \n test2";

            ViewBag.ListEmpHandleAsset_Detail = sp_EmpHandleAsset_Detail;
            return View();
        }
        [HttpPost]
        public string savecomment(string empId, string Comment)
        {
            InvMstEmployeeAssetComment invMstEmployeeAssetComment = new InvMstEmployeeAssetComment();
            invMstEmployeeAssetComment.EmployeeId = empId;
            invMstEmployeeAssetComment.TransactionDate = DateTime.Now;
            invMstEmployeeAssetComment.CommentText = Comment;

            _YCGInventoryContext.InvMstEmployeeAssetComments.Add(invMstEmployeeAssetComment);
            _YCGInventoryContext.SaveChanges();

            return "success";
        }
        // POST: InvMstEmployeeAssetItemController/Edit/5
        [HttpPost]
        public string Edit(string TransactionId,string employee, string itemid, string itemserial, DateTime saveDate, DateTime receiptDate,string activeflag)
        {
            try
            {
                 
                List<InvMstEmployeeAssetItem> invMstEmployeeAssetItem = new List<InvMstEmployeeAssetItem>();
                invMstEmployeeAssetItem = _YCGInventoryContext.InvMstEmployeeAssetItems.Where(x => x.TransactionId == Int32.Parse(TransactionId)).ToList();

                    if (invMstEmployeeAssetItem.Count != 0 && Int32.Parse(TransactionId) != 0 )
                    {
                        InvMstEmployeeAssetItem _tbdetail = _YCGInventoryContext.InvMstEmployeeAssetItems.Find(Int32.Parse(TransactionId));
                        _tbdetail.ItemActualDate = saveDate.AddYears(543);
                        _tbdetail.ItemReceiveDate = receiptDate.AddYears(543);
                    if (activeflag == "true")
                    {
                        _tbdetail.ActiveFlag = "Y";
                    } else
                    {
                        _tbdetail.ActiveFlag = "N";
                    }
                        

                        _YCGInventoryContext.SaveChanges();

            
                    }
                    else 
                    {
                        var Asset = (from x in _YCGInventoryContext.runningInfo
                                     where x.Type == "Asset" && x.InfoId == 1
                                     select x).ToList();

                        var NewNumber = Asset[0].Running + 1;
                        List<RunningInfo> _runningInfo = _YCGInventoryContext.runningInfo.Where(x => x.Type == "Asset" && x.InfoId == 1).ToList();
                        _runningInfo[0].Running = NewNumber;
                        _YCGInventoryContext.SaveChanges();

                        InvMstEmployeeAssetItem _invMstEmployeeAssetItems = new InvMstEmployeeAssetItem();
                        _invMstEmployeeAssetItems.TransactionId = NewNumber;
                        _invMstEmployeeAssetItems.TransactionType = "IV";

                        _invMstEmployeeAssetItems.TransactionDate = DateTime.Now;

                        _invMstEmployeeAssetItems.EmployeeId = employee;

                        _invMstEmployeeAssetItems.ItemId = int.Parse(itemid);

                        _invMstEmployeeAssetItems.ItemSerialNo =  itemserial;

                        _invMstEmployeeAssetItems.ItemQty = 1;

                        _invMstEmployeeAssetItems.ItemUserName = "";

                        _invMstEmployeeAssetItems.ItemActualDate = saveDate.AddYears(543);

                         _invMstEmployeeAssetItems.ItemReceiveDate = receiptDate.AddYears(543);

                    //    _invMstEmployeeAssetItems.ItemReturnDate = "";

                         _invMstEmployeeAssetItems.CreateDate = DateTime.Now;

                        _invMstEmployeeAssetItems.CreateUserId = Int16.Parse(empid_get());

                        _invMstEmployeeAssetItems.UpdateDate = DateTime.Now;

                        _invMstEmployeeAssetItems.UpdateUserId = Int16.Parse(empid_get());

                        _invMstEmployeeAssetItems.ActiveFlag = "Y";

                        _YCGInventoryContext.InvMstEmployeeAssetItems.Add(_invMstEmployeeAssetItems);
                        _YCGInventoryContext.SaveChanges();

                    }

                return "success";
            }
            catch
            {
                return "error";
            }
        }

        // GET: InvMstEmployeeAssetItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvMstEmployeeAssetItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
