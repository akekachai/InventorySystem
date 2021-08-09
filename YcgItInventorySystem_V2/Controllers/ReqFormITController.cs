using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using YcgItInventorySystem_V2.Data;
using YcgItInventorySystem_V2.Models;
using YcgItInventorySystem_V2.Models.Inventory;


namespace YcgItInventorySystem_V2.Controllers
{
    public class ReqFormITController : Controller
    {
        // GET: ReqFormITController
        public YCGInventoryContext _YCGInventoryContext;

        public ApplicationDbContext _ApplicationDbContext;

        public ReqFormITController(YCGInventoryContext ycginventoryContext, ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
            _YCGInventoryContext = ycginventoryContext;
        }
        public string empid_get()
        {
            string createby = User.Identity.Name;

            string EmployeeId = (from e in _ApplicationDbContext.EmpMstEmployee
                                 where e.Username == createby
                                 select e.EmployeeId).FirstOrDefault();
            return EmployeeId;
        }

        public int empLocation_get()
        {
            string createby = User.Identity.Name;

            string LocationId = (from e in _ApplicationDbContext.EmpMstEmployee
                                 where e.Username == createby
                                 select e.LocationId).FirstOrDefault();
            return Int32.Parse(LocationId);
        }

      

        [HttpGet]
        public IActionResult empDept(string empcode)
        {
            string dept = "0";
            dept = (from e in _ApplicationDbContext.EmpMstEmployee
                    where e.EmployeeId == empcode
                    select e.DepartmentId).FirstOrDefault();

            return Ok(dept);
        }

        [HttpGet]
        public IActionResult empsection(string empcode)
        {
            string section = "0";
            section = (from e in _ApplicationDbContext.EmpMstEmployee
                    where e.EmployeeId == empcode
                    select e.SectionId).FirstOrDefault();
            return Ok(section);
        }

        [HttpGet]
        public JsonResult empInfologin(string empcode)
        {
            
           var empinfo = (from e in _ApplicationDbContext.EmpMstEmployee
                       where e.EmployeeId == empcode
                       select e).ToList();
            return Json(empinfo.ToList());
        }

        public ActionResult Index()
        {
            //var ReqItList = _YCGInventoryContext.SP_ReqFormItList.FromSqlRaw("SP_ReqFormItList").ToList();   
            string EmployeeId = empid_get();

            List<SP_ReqFormItList> ReqFormIt = _YCGInventoryContext.SP_ReqFormItList.FromSqlRaw("SP_ReqFormItList "+ EmployeeId +",'1-0','0' ").ToList();
            return View(ReqFormIt);
        }

        // GET: ReqFormITController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        public class employeeList
            { 
            public string empcode { get; set; }
        
            public string empname { get; set; }
        }
        // GET: ReqFormITController/Create
        public ActionResult Create()
        {

            List<EmpMstCompany> mstCompanies = new List<EmpMstCompany>();
            List<EmpMstLocation> mstLocations = new List<EmpMstLocation>();

            List<EmpNamePrefix> NamePrefixList = new List<EmpNamePrefix>();
            List<EmpMstDepartment> departmentList = new List<EmpMstDepartment>();
            List<ReqServiceType> ServiceTypeList = new List<ReqServiceType>();
            List<EmpMstPosition> mstPositionsList = new List<EmpMstPosition>();
            List<EmpMstSection> mstSection = new List<EmpMstSection>();
            List<EmpMstLevel> mstLevel = new List<EmpMstLevel>();
            List<SP_EmpMstEmployeeActive> sp_EmpMstEmployeeActives = new List<SP_EmpMstEmployeeActive>();
            //List<EmpMstEmployee> empMstEmployeeList = new List<EmpMstEmployee>();

            mstCompanies = _ApplicationDbContext.EmpMstCompany.ToList();
            mstLocations = _ApplicationDbContext.EmpMstLocation.ToList();

            departmentList = _ApplicationDbContext.EmpMstDepartment.ToList();
            departmentList.Insert(0, new EmpMstDepartment { DepartmentText = "--- โปรดเลือก ฝ่าย --- " , DepartmentId = 0});
            mstSection = _ApplicationDbContext.EmpMstSection.ToList(); 
            mstSection.Insert(0, new EmpMstSection { SectionText = "--- โปรดเลือก แผนก --- ", SectionId = 0 });

            mstLevel = _ApplicationDbContext.EmpMstLevel.ToList();
            mstLevel.Insert(0, new EmpMstLevel { LevelText = "โปรดเลือก ระดับ", LevelId = 0 });

            NamePrefixList = _ApplicationDbContext.EmpNamePrefix.ToList();
         
            ServiceTypeList = _YCGInventoryContext.ReqServiceType.OrderBy(x => x.Sequence).ToList();
            mstPositionsList = _ApplicationDbContext.EmpMstPosition.Where(x => x.ActiveFlag == "Y").ToList();
            mstPositionsList.Insert(0, new EmpMstPosition { PositionText = "--- โปรดเลือก ตำแหน่ง --- ", PositionId = 0 });

            sp_EmpMstEmployeeActives = _ApplicationDbContext.SP_EmpMstEmployeeActive.FromSqlRaw("SP_EmpMstEmployeeActive").ToList();


            List<employeeList> employeeList = (from e in _ApplicationDbContext.EmpMstEmployee
                                  where e.EmployeeResignFlag == "N"
                                  select  new employeeList
                                  { empcode = e.EmployeeId ,
                                      empname = e.EmployeeNameFirst + ' ' +e.EmployeeNameLast
                                   }).ToList();
            //  empMstEmployeeList = _ApplicationDbContext.EmpMstEmployee.Where(x=> x.EmployeeResignFlag=="N").ToList();
            employeeList.Insert(0, new employeeList { empname = "--- โปรดเลือก ผู้ยื่นคำขอ --- ", empcode = "0" });

            ViewBag.ListDept = departmentList;
            ViewBag.ListNamePrefix = NamePrefixList;
            ViewBag.ListServiceType = ServiceTypeList;
            ViewBag.ListmstPosition = mstPositionsList;
            ViewBag.ListempMstEmployee = employeeList;
            ViewBag.ListSection = mstSection;
            ViewBag.ListLevel = mstLevel;
            ViewBag.emplogin = empid_get();
            ViewBag.ListComp = mstCompanies;
            ViewBag.ListLocation = mstLocations;
            ViewBag.Listsp_EmpMstEmployeeActives = sp_EmpMstEmployeeActives;
            return View();
        }

        // POST: ReqFormITController/Create
        [HttpPost]
        public ActionResult Create(Req_FormIt reqFormIt)
        {
            string pagesuccess = "Index";
            string EmployeeId = empid_get();
                 int LocationId = empLocation_get();

            if (reqFormIt.EffectStartDate != null)
            {
                DateTime convertEffectStartDate = DateTime.Parse(reqFormIt.EffectStartDate.ToString()).AddYears(543);
          reqFormIt.EffectStartDate = convertEffectStartDate;
            }
            if (reqFormIt.EffectEndDate != null)
            { 
               DateTime convertEffectEndtDate = DateTime.Parse(reqFormIt.EffectEndDate.ToString()).AddYears(543);
                reqFormIt.EffectEndDate = convertEffectEndtDate;
            }


            reqFormIt.ReqStatus = "1-1";
            reqFormIt.LocationId = LocationId;
            reqFormIt.CreateBy = EmployeeId;
            reqFormIt.CreateDate = DateTime.Now;

            if (EmployeeId == reqFormIt.FilingEmpCode)
            {
                reqFormIt.ReqStatus = "1-2";
                reqFormIt.FilingAceptDate = DateTime.Now;
                pagesuccess = "Index";
            }

            _YCGInventoryContext.Req_FormIt.Add(reqFormIt);
            _YCGInventoryContext.SaveChanges();

            //return RedirectToAction(nameof(Index));

            return RedirectToAction(pagesuccess, new { ReqNo = reqFormIt.ReqNo });

             }

        [HttpPost]
        public string EditDetail(List<ReqFormItdetail> reqFormItdetail)
        {

           

            foreach (var x in reqFormItdetail)
            {
                ReqFormItdetail _reqFormItdetail = _YCGInventoryContext.ReqFormItdetail.Find(x.ReqNo,x.ServiceCode);

                if (_reqFormItdetail != null)
                {
                    _reqFormItdetail.Remarks = x.Remarks;
                    if (x.Actions == "0")
                    {
                        _reqFormItdetail.Actions = "1";
                        _reqFormItdetail.ActionsUp = true;
                    }
                    else
                    {
                        _reqFormItdetail.Actions = "0";
                        _reqFormItdetail.ActionsUp = false;
                    }

                    _reqFormItdetail.AssetCode = x.AssetCode;
                    _reqFormItdetail.IMEINo = x.IMEINo;
                    _reqFormItdetail.Brand = x.Brand;
                    if (x.ServiceCode == 7 || x.ServiceCode == 17)
                    {
                        var checkyear = x.Enddate.ToString();
                        try
                        {
                            _reqFormItdetail.Enddate = DateTime.Parse(x.Enddate.ToString()).AddYears(543);
                        }
                        catch
                        {
                            _reqFormItdetail.Enddate = DateTime.Parse(x.Enddate.ToString());
                        }
                        
                    }
                    else
                    {
                        _reqFormItdetail.Enddate = null;
                    }

                    _YCGInventoryContext.SaveChanges();
                }
                else {


                    ReqFormItdetail _reqFormItdetails = new ReqFormItdetail();


                        _reqFormItdetails.ReqNo = x.ReqNo;
                        _reqFormItdetails.ServiceCode = x.ServiceCode;
                        _reqFormItdetails.Remarks = x.Remarks;
                        if (x.Actions == "0")
                        {
                            _reqFormItdetails.Actions = "1";
                            _reqFormItdetails.ActionsUp = true;
                        }
                        else
                        {
                            _reqFormItdetails.Actions = "0";
                            _reqFormItdetails.ActionsUp = false;
                        }


                        _reqFormItdetails.AssetCode = x.AssetCode;
                        _reqFormItdetails.IMEINo = x.IMEINo;
                        _reqFormItdetails.Brand = x.Brand;
                    if (x.ServiceCode == 7 || x.ServiceCode == 17)
                    {
                        _reqFormItdetails.Enddate = DateTime.Parse(x.Enddate.ToString()).AddYears(543);
                    }
                    else
                    {
                        _reqFormItdetails.Enddate = null;
                    }

                    _YCGInventoryContext.ReqFormItdetail.Add(_reqFormItdetails);
                        _YCGInventoryContext.SaveChanges();
                    }

                             
            }
            return "Sucess";
        }
        // POST: ReqFormITController/Create
        public int CreateDetail(List<ReqFormItdetail> reqFormItdetail)
        {
            if (reqFormItdetail.Count != 0)
            {
                int rowreq = (from r in _YCGInventoryContext.runningInfo where r.InfoDesc == "Running" select r.Running ).FirstOrDefault();
                RunningInfo runningInfo = _YCGInventoryContext.runningInfo.SingleOrDefault(x => x.InfoDesc == "Running");

                int newnumber = rowreq + 1;
                runningInfo.Running = newnumber;
                _YCGInventoryContext.SaveChanges();

                int listcount = reqFormItdetail.Count;
                ReqFormItdetail _reqFormItdetail = new ReqFormItdetail();

                foreach (var x in reqFormItdetail)
                {
                    _reqFormItdetail.ReqNo = (newnumber).ToString();
                    _reqFormItdetail.ServiceCode = x.ServiceCode;
                    _reqFormItdetail.Remarks = x.Remarks;
                    if (x.Actions == "0")
                    {
                        _reqFormItdetail.Actions = "1";
                        _reqFormItdetail.ActionsUp = true;
                    }
                    else
                    {
                        _reqFormItdetail.Actions = "0";
                        _reqFormItdetail.ActionsUp = false;
                    }


                    _reqFormItdetail.AssetCode = x.AssetCode;
                    _reqFormItdetail.IMEINo = x.IMEINo;
                    _reqFormItdetail.Brand = x.Brand;

                    if (x.ServiceCode == 7 || x.ServiceCode == 17)
                    {
                        _reqFormItdetail.Enddate = DateTime.Parse(x.Enddate.ToString()).AddYears(543);
                    }
                    else {
                        _reqFormItdetail.Enddate = null;
                    }

                    _YCGInventoryContext.ReqFormItdetail.Add(_reqFormItdetail);
                    _YCGInventoryContext.SaveChanges();
                }
                return newnumber;
            }
            else
            {
                return 0;
            }
                 
        }

        public ActionResult AcceptRequest(string id)
        {//รายการรับเรื่อง IT
            //var ReqItList = _YCGInventoryContext.SP_ReqFormItList.FromSqlRaw("SP_ReqFormItList").ToList();   
            string EmployeeId = empid_get();
            int LocationId = empLocation_get();
            List<SP_ReqFormItList> ReqFormIt = _YCGInventoryContext.SP_ReqFormItList.FromSqlRaw("SP_ReqFormItList " + EmployeeId + ",'1-2'," + LocationId).ToList();
            return View(ReqFormIt);

        }

        public ActionResult Confrim_List(string id)
        {   //ยืนยันรายการ
            //var ReqItList = _YCGInventoryContext.SP_ReqFormItList.FromSqlRaw("SP_ReqFormItList").ToList();   
            string EmployeeId = empid_get();

            List<SP_ReqFormItList> ReqFormIt = _YCGInventoryContext.SP_ReqFormItList.FromSqlRaw("SP_ReqFormItList " + EmployeeId + ",'1-1','0'").ToList();
            return View(ReqFormIt);

        }
        
        // GET: ReqFormITController/Edit/5
        public ActionResult Edit(int id , string pageid)
        {
            string ReqNo = id.ToString();
            Req_FormIt Req_FormIt = _YCGInventoryContext.Req_FormIt.Find(ReqNo);
            List<ReqFormItdetail> ReqForm_Itdetail = _YCGInventoryContext.ReqFormItdetail.Where(x => x.ReqNo == ReqNo).ToList();

            List<EmpMstCompany> mstCompanies = new List<EmpMstCompany>();
            List<EmpMstLocation> mstLocations = new List<EmpMstLocation>();

            List<EmpNamePrefix> NamePrefixList = new List<EmpNamePrefix>();
            List<EmpMstDepartment> departmentList = new List<EmpMstDepartment>();
            List<SP_ReqFormItDetailList> SP_ReqFormItDetailList = _YCGInventoryContext.SP_ReqFormItDetailList.FromSqlRaw("SP_ReqFormItDetailList " + ReqNo).ToList();
            List<EmpMstPosition> mstPositionsList = new List<EmpMstPosition>();
            List<EmpMstEmployee> empMstEmployeeList = new List<EmpMstEmployee>();
            List<EmpMstSection> mstSection = new List<EmpMstSection>();
            List<EmpMstLevel> mstLevel = new List<EmpMstLevel>();
            List<SP_EmpMstEmployeeActive> sp_EmpMstEmployeeActives = new List<SP_EmpMstEmployeeActive>();

            mstCompanies = _ApplicationDbContext.EmpMstCompany.ToList();
            mstLocations = _ApplicationDbContext.EmpMstLocation.ToList();

            departmentList = _ApplicationDbContext.EmpMstDepartment.ToList();
            departmentList.Insert(0, new EmpMstDepartment { DepartmentText = "--- โปรดเลือก ฝ่าย/แผนก --- ", DepartmentId = 0 });
            NamePrefixList = _ApplicationDbContext.EmpNamePrefix.ToList();

           
            mstPositionsList = _ApplicationDbContext.EmpMstPosition.Where(x => x.ActiveFlag == "Y").ToList();
            mstPositionsList.Insert(0, new EmpMstPosition { PositionText = "--- โปรดเลือก ตำแหน่ง --- ", PositionId = 0 });
            mstSection = _ApplicationDbContext.EmpMstSection.ToList();
            mstSection.Insert(0, new EmpMstSection { SectionText = "--- โปรดเลือก แผนก --- ", SectionId = 0 });

            mstLevel = _ApplicationDbContext.EmpMstLevel.ToList();
            mstLevel.Insert(0, new EmpMstLevel { LevelText = "โปรดเลือก ระดับ", LevelId = 0 });
            List<employeeList> employeeList = (from e in _ApplicationDbContext.EmpMstEmployee
                                               where e.EmployeeResignFlag == "N"
                                               select new employeeList
                                               {
                                                   empcode = e.EmployeeId,
                                                   empname = e.EmployeeNameFirst + ' ' + e.EmployeeNameLast
                                               }).ToList();
            
            employeeList.Insert(0, new employeeList { empname = "--- โปรดเลือก ผู้ยื่นคำขอ --- ", empcode = "0" });
            sp_EmpMstEmployeeActives = _ApplicationDbContext.SP_EmpMstEmployeeActive.FromSqlRaw("SP_EmpMstEmployeeActive").ToList();

            ViewBag.ListDept = departmentList;
            ViewBag.ListNamePrefix = NamePrefixList;
            ViewBag.ListSP_ReqFormItDetailList = SP_ReqFormItDetailList;
    
            ViewBag.ListmstPosition = mstPositionsList;
            ViewBag.ListempMstEmployee = employeeList;
            ViewBag.ListReqForm_Itdetail = ReqForm_Itdetail;
            ViewBag.ListSection = mstSection;
            ViewBag.ListLevel = mstLevel;
            ViewBag.ListComp = mstCompanies;
            ViewBag.ListLocation = mstLocations;
            ViewBag.Listsp_EmpMstEmployeeActives = sp_EmpMstEmployeeActives;
            ViewData["UserStatus"] = Req_FormIt.UserStatus;
            return View(Req_FormIt);
        }

        // POST: ReqFormITController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string pageid,string actionstatus, Req_FormIt req_FormIt)
        {   
            string ReqNo = id.ToString();
            try
            {
               

                Req_FormIt req_FormIt_e  = _YCGInventoryContext.Req_FormIt.Find(ReqNo);

                if (pageid == "0")
                {
                     req_FormIt_e.UsersNameTitle = req_FormIt.UsersNameTitle;
                    req_FormIt_e.UsersFirstName_TH = req_FormIt.UsersFirstName_TH;
                    req_FormIt_e.UsersLastName_TH = req_FormIt.UsersLastName_TH;
                    req_FormIt_e.UsersFirstName_EN = req_FormIt.UsersFirstName_EN;
                    req_FormIt_e.UsersLastName_EN = req_FormIt.UsersLastName_EN;
                    req_FormIt_e.FilingEmpCode = req_FormIt.FilingEmpCode;
                    req_FormIt_e.UserLevelId = req_FormIt.UserLevelId;
                    req_FormIt_e.UserCompCode = req_FormIt_e.UserCompCode;
                    req_FormIt_e.UserLocationId = req_FormIt_e.UserLocationId;
                    req_FormIt_e.UserDeptCode = req_FormIt.UserDeptCode;
                    req_FormIt_e.UserSectionId= req_FormIt.UserSectionId;
                    req_FormIt_e.UsersEmpCode= req_FormIt.UsersEmpCode;
                    req_FormIt_e.FilingEmpCode= req_FormIt.FilingEmpCode;
                    req_FormIt_e.EffectEndDate= req_FormIt.EffectEndDate;
                    req_FormIt_e.EffectStartDate= req_FormIt.EffectStartDate;
                    req_FormIt_e.Reason= req_FormIt.Reason;
                    req_FormIt_e.ContactNumber = req_FormIt.ContactNumber;
                    req_FormIt_e.FilingEmpCode= req_FormIt.FilingEmpCode;
                    req_FormIt_e.FilingDept = req_FormIt.FilingDept;
                    req_FormIt_e.FilingSection = req_FormIt.FilingSection;

                    _YCGInventoryContext.SaveChanges();

                    return RedirectToAction("Index", new { ReqNo = ReqNo });

                }
                else if (pageid == "1")
                {
                    if (actionstatus == "1")
                    {
                        req_FormIt_e.ReqStatus = "1-2";
                        req_FormIt_e.FilingDept = req_FormIt.FilingDept;
                        req_FormIt_e.FilingSection = req_FormIt.FilingSection;
                    }
                    else if (actionstatus == "0")
                    {
                        req_FormIt_e.ReqStatus = "1-1-0";
                    }
                    req_FormIt_e.FilingAceptDate = DateTime.Now;
                    _YCGInventoryContext.SaveChanges();

                    return RedirectToAction("Confrim_List", new { ReqNo = ReqNo });
                }
                else if (pageid == "2")
                {
                    string EmployeeId = empid_get();
                    req_FormIt_e.ReqStatus = "1-3";
                    req_FormIt_e.ITBy = EmployeeId;
                    req_FormIt_e.ITByDate = DateTime.Now;
                    _YCGInventoryContext.SaveChanges();

                    return RedirectToAction("AcceptRequest", new { ReqNo = ReqNo });
                }
                 
            }
            catch
            {
                return View();
            }

            return RedirectToAction("Index", new { ReqNo = ReqNo });
        }

        // GET: ReqFormITController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReqFormITController/Delete/5
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
