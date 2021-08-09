using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YcgItInventorySystem_V2.Data;
using YcgItInventorySystem_V2.Models.Inventory;
using YcgItInventorySystem_V2.Services;
using YcgItInventorySystem_V2.Models;
using Microsoft.AspNetCore.Hosting;
using AspNetCore.Reporting;
using System.Data;

namespace YcgItInventorySystem_V2.Controllers
{
    public class ITProcessController : Controller
    {
        public YCGInventoryContext _YCGInventoryContext;

        public ApplicationDbContext _ApplicationDbContext;

        private readonly IEmpservice _IEmpservice;
        private readonly IAssetInfo _IassetInfo;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public ITProcessController(YCGInventoryContext ycginventoryContext, ApplicationDbContext applicationDbContext ,IEmpservice iempservice,IAssetInfo iassetinfo ,IWebHostEnvironment webHostEnvironment)
        {
            _ApplicationDbContext = applicationDbContext;
            _YCGInventoryContext = ycginventoryContext;
            _IEmpservice = iempservice;
            _IassetInfo = iassetinfo;
            _webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
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
        public IActionResult Index()
        {
            string Location = _IEmpservice.EmpLocation_get(User.Identity.Name);
            string EmployeeId = empid_get();

            List<SP_ReqFormItList> ReqFormIt = _YCGInventoryContext.SP_ReqFormItList.FromSqlRaw("SP_ReqFormItList " + EmployeeId + ",'1-3',"+ Location).ToList();
            return View(ReqFormIt);
            
        }

        public IActionResult CreateEmpAsset(int id, string pageid,string ControlNo)
        {
            string ReqNo = id.ToString();
            string Location = _IEmpservice.EmpLocation_get(User.Identity.Name);
            List<SP_AssetsRemaining> SP_AssetsRemaining = _YCGInventoryContext.SP_AssetsRemaining.FromSqlRaw("SP_AssetsRemaining " + Location + ",'0'").ToList();


            List<SP_ReqFormIt_Id> SP_ReqFormIt_Id = _YCGInventoryContext.SP_ReqFormIt_Id.FromSqlRaw("SP_ReqFormIt_Id " + ReqNo ).ToList();
            List<SP_ReqFormItDetailList> SP_ReqFormItDetailList = _YCGInventoryContext.SP_ReqFormItDetailList.FromSqlRaw("SP_ReqFormItDetailList " + ReqNo).ToList();
         

            ViewBag.ListSP_ReqFormItDetailList = SP_ReqFormItDetailList;
            ViewBag.ListSP_AssetsRemaining = SP_AssetsRemaining;
            return View(SP_ReqFormIt_Id);

        }

        [HttpPost]
        public String CreateEmpAsset(string ReqNo,string controlNo,string _empStatus, string statusClose)
        {
            string EmpStatus = _empStatus ;
            Req_FormIt req_FormIt = _YCGInventoryContext.Req_FormIt.Find(ReqNo);
            req_FormIt.ITProcessBy = int.Parse( empid_get());
            req_FormIt.ITProcessByDate = DateTime.Now;
            if (statusClose == "true")
            {
                req_FormIt.ReqStatus = "3-0";
                _YCGInventoryContext.SaveChanges();
            }
            if (controlNo != "")
            {
            
                 req_FormIt.ControlNo = controlNo;
               
                _YCGInventoryContext.SaveChanges();
                               
            }

            if (EmpStatus == "1") 
            {
                var chkemp = (from emp in _ApplicationDbContext.EmpMstEmployee
                              where emp.EmployeeId == req_FormIt.UsersEmpCode
                              select emp).ToList();

                if (chkemp.Count == 0)
                {
                    EmpMstEmployee empMstEmployee = new EmpMstEmployee() ;

                    empMstEmployee.EmployeeId = req_FormIt.UsersEmpCode;
                    empMstEmployee.EmployeeNameTitle =  req_FormIt.UsersNameTitle.ToString();
                    empMstEmployee.EmployeeNameFirst = req_FormIt.UsersFirstName_TH;
                    empMstEmployee.EmployeeNameLast = req_FormIt.UsersLastName_TH;
                    empMstEmployee.LevelId = req_FormIt.UserLevelId.ToString();
                    empMstEmployee.CompanyId = req_FormIt.UserCompCode.ToString();
                    empMstEmployee.LocationId = req_FormIt.UserLocationId.ToString();
                    empMstEmployee.DepartmentId = req_FormIt.UserDeptCode.ToString();
                    empMstEmployee.SectionId = req_FormIt.UserSectionId.ToString();
                    empMstEmployee.EmployeeResignFlag = "N";
                    empMstEmployee.CreateDate = DateTime.Now;
                    var itcreate = empid_get() ;
                    empMstEmployee.CreateUserId = Int16.Parse(itcreate) ;
                    empMstEmployee.UpdateDate = DateTime.Now;
                    empMstEmployee.UpdateUserId = Int16.Parse(itcreate);
                    empMstEmployee.ActiveFlag = "Y";

                    _ApplicationDbContext.EmpMstEmployee.Add(empMstEmployee);
                    _ApplicationDbContext.SaveChanges();
                }
            }
            else if (EmpStatus == "2")
            {
             
                var chkemp = (from emp in _ApplicationDbContext.EmpMstEmployee
                              where emp.EmployeeId == req_FormIt.UsersEmpCode
                              select emp).ToList();

                if (chkemp.Count != 0)
                { 
                EmpMstEmployee _empMstEmployee = _ApplicationDbContext.EmpMstEmployee.Find(req_FormIt.UsersEmpCode);

                    _empMstEmployee.EmployeeResignFlag = "Y";
                    _empMstEmployee.EmployeeResignDate = DateTime.Now;

                    _ApplicationDbContext.SaveChanges();
                }
                    

            }

            return "Success";
         
        }

        public class EmpItemasset
        {
            public string itemid { get; set; }

            public string userEmp { get; set; }
            public string servicecode { get; set; }

            public string SaveDates { get; set; }

            public string ReceiptDate { get; set; }

        }

            [HttpPost]
        public async Task<String>CreateEmpAssetDetail(List<ReqFormItdetail> reqFormItdetail,string ControlNo, List<EmpItemasset> empItemasset)
        {
            var status = "";
            var Transactionid = "";
            var rowindex = 0;
            foreach (var x in reqFormItdetail)
            {
                try
                {
                    ReqFormItdetail _reqFormItdetail = _YCGInventoryContext.ReqFormItdetail.Find(x.ReqNo, x.ServiceCode);
              
                if (_reqFormItdetail != null)
                {
                    _reqFormItdetail.ITRemark = x.Remarks;
                    _reqFormItdetail.ItemAssetNo = x.ItemAssetNo;
                    if (x.ItemSerialNo == null && x.CheckListByIT == true)
                    {
                        _reqFormItdetail.ItemSerialNo = x.Remarks;
                    }
                    else if ( (x.ServiceCode == 4 || x.ServiceCode == 5 || x.ServiceCode == 16 ) && x.ItemSerialNo != "-" )
                    {
                        List<InvMstAssetItemSerial> ItemInfo = _IassetInfo.AssetitemInfo_get(x.ItemSerialNo); 
                        // _reqFormItdetail.AssetCode = ItemInfo[0].ItemAssetNo;
                        _reqFormItdetail.ItemAssetNo = ItemInfo[0].ItemAssetNo;
                        _reqFormItdetail.ITRemark = _IassetInfo.AssetitemText_get(ItemInfo[0].ItemId);
                        _reqFormItdetail.Brand = x.Brand;

                        _reqFormItdetail.Mouse = x.Mouse;
                        var sdate = empItemasset[rowindex].SaveDates;
                        var rdate = empItemasset[rowindex].ReceiptDate;
                        if (_reqFormItdetail.ItemSerialNo == null && _reqFormItdetail.ItemSerialNo != x.ItemSerialNo)
                        {
                            Transactionid = CreateEmpAssets(empItemasset[rowindex].userEmp, ItemInfo[0].ItemId.ToString(), x.ItemSerialNo, DateTime.Parse(sdate), DateTime.Parse(rdate));
                            _reqFormItdetail.TransactionId = Int16.Parse(Transactionid);
                        }
                        else if (_reqFormItdetail.ItemSerialNo != null && _reqFormItdetail.ItemSerialNo != x.ItemSerialNo && _reqFormItdetail.TransactionId != 0)
                        {
                            //cancel
                            cancelEmpAsset(_reqFormItdetail.TransactionId);
                            //createlist
                            Transactionid = CreateEmpAssets(empItemasset[rowindex].userEmp, ItemInfo[0].ItemId.ToString(), x.ItemSerialNo, DateTime.Parse(sdate), DateTime.Parse(rdate));
                            _reqFormItdetail.TransactionId = Int16.Parse(Transactionid);
                        }
                        else
                        {
                            UpdateEmpAsset(_reqFormItdetail.TransactionId, DateTime.Parse(sdate), DateTime.Parse(rdate));
                        }
                        _reqFormItdetail.ItemSerialNo = x.ItemSerialNo;

                    }
                    else if (x.ServiceCode == 6 || x.ServiceCode == 9 || x.ServiceCode == 10 || x.ServiceCode == 11 || x.ServiceCode == 12 || x.ServiceCode == 13)
                    {
                        var sdate = empItemasset[rowindex].SaveDates;
                        var rdate = empItemasset[rowindex].ReceiptDate;

                        var Getitems = (from y in _YCGInventoryContext.ReqServiceType
                                        where y.ServiceCode == x.ServiceCode
                                        select y ).ToList();

                        if (_reqFormItdetail.TransactionId == 0)
                        {
                            Transactionid = CreateEmpAssets(empItemasset[rowindex].userEmp, Getitems[0].ItemId.ToString(), _reqFormItdetail.ITRemark, DateTime.Parse(sdate), DateTime.Parse(rdate));
                            _reqFormItdetail.TransactionId = int.Parse(Transactionid);
                        }
                        else 
                        { 
                        
                        }
                    }
                    else
                    {
                        _reqFormItdetail.ItemSerialNo = x.ItemSerialNo;

                    }
                    

                    if (x.Actions == "0")
                    {
                        //_reqFormItdetail.Actions = "1";
                        _reqFormItdetail.ActionsUp = true;
                    }
                    else
                    {
                        //_reqFormItdetail.Actions = "0";
                        _reqFormItdetail.ActionsUp = false;
                    }

                    if (x.CheckListByIT == true)
                    {
                        _reqFormItdetail.CheckListByIT = true;
                        _reqFormItdetail.CheckListByITDate = DateTime.Now;
                    }
                    else
                    {
                        _reqFormItdetail.CheckListByIT = false;
                        _reqFormItdetail.CheckListByITDate = DateTime.Now;
                    }

                    _YCGInventoryContext.SaveChanges();
                   
                }

                 rowindex = rowindex + 1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            return "Detail";
        }

        void UpdateEmpAsset(int TransactionId,DateTime SaveDate, DateTime ReceiptDate)
        {

            InvMstEmployeeAssetItem _invMstEmployeeAssetItems = _YCGInventoryContext.InvMstEmployeeAssetItems.Find(TransactionId);


            _invMstEmployeeAssetItems.ItemActualDate = SaveDate.AddYears(543);

            _invMstEmployeeAssetItems.ItemReceiveDate = ReceiptDate.AddYears(543);

            _invMstEmployeeAssetItems.UpdateDate = DateTime.Now;

            _invMstEmployeeAssetItems.UpdateUserId = Int16.Parse(empid_get());

            _YCGInventoryContext.SaveChanges();

        }
        void cancelEmpAsset( int TransactionId)
        {

            InvMstEmployeeAssetItem _invMstEmployeeAssetItems = _YCGInventoryContext.InvMstEmployeeAssetItems.Find(TransactionId);

            _invMstEmployeeAssetItems.ActiveFlag = "N";

            _invMstEmployeeAssetItems.UpdateDate = DateTime.Now;

            _invMstEmployeeAssetItems.UpdateUserId = Int16.Parse(empid_get());

            _YCGInventoryContext.SaveChanges();

        }

        private string CreateEmpAssets(string employee,string itemid,string itemserial,DateTime saveDate, DateTime receiptDate)
        {
            var Asset =  (from x in _YCGInventoryContext.runningInfo
                             where x.Type == "Asset" && x.InfoId == 1
                             select x).ToList();

           var NewNumber = Asset[0].Running + 1;
            List<RunningInfo> _runningInfo = _YCGInventoryContext.runningInfo.Where(x => x.Type == "Asset" &&  x.InfoId == 1).ToList();
            _runningInfo[0].Running = NewNumber;
            _YCGInventoryContext.SaveChanges();

            InvMstEmployeeAssetItem _invMstEmployeeAssetItems = new InvMstEmployeeAssetItem();
                _invMstEmployeeAssetItems.TransactionId = NewNumber;
                _invMstEmployeeAssetItems.TransactionType = "IV";

                _invMstEmployeeAssetItems.TransactionDate = DateTime.Now;

                _invMstEmployeeAssetItems.EmployeeId = employee;

                _invMstEmployeeAssetItems.ItemId = int.Parse( itemid);

                _invMstEmployeeAssetItems.ItemSerialNo = itemserial;

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

            return NewNumber.ToString();
        }

        [HttpGet]
        public string GetCtrlNo()
        {
            String CortlFormat = "";
            int NewNumber = 0;
            var LocationId = empLocation_get();
            var ControlNo = (from x in _YCGInventoryContext.runningInfo
                             where x.Type == "Contr" && x.InfoId == LocationId
                             select x).ToList();
            NewNumber = ControlNo[0].Running + 1;
            CortlFormat = DateTime.Now.ToString("yyyy") + "/" + ControlNo[0].InfoDesc + NewNumber.ToString().PadLeft(3, '0');
          
            return CortlFormat;
        }

        [HttpGet]
        public JsonResult GetAssetRemain(string category)
        {
            string Location = _IEmpservice.EmpLocation_get(User.Identity.Name);
            List<SP_AssetsRemaining> SP_AssetsRemaining = _YCGInventoryContext.SP_AssetsRemaining.FromSqlRaw("SP_AssetsRemaining " + Location +"," + category).ToList();
         
            return Json(SP_AssetsRemaining.ToList());
        }

        [HttpGet]
        public string GetitemText(int itemid)
        {
            
            return _IassetInfo.AssetitemText_get(itemid) ; 
        }


        public List<InvMstAssetItemSerial> AssetitemInfo_get( String itemSerialNo)
        {

            return _IassetInfo.AssetitemInfo_get(itemSerialNo);
        }

        public IActionResult PrintReqForm(string ReqNo)
        {
            var dt = new DataTable();
            var dt_detail = new DataTable();

            dt = DT_ReqFormIt_Id(ReqNo);
            dt_detail = DT_ReqFormItDetailList(ReqNo);
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReqFormIT.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReqNo", ReqNo);
            LocalReport localreport = new LocalReport(path);
             
            localreport.AddDataSource("dsInventorys", dt); // datasetname of reporting
            localreport.AddDataSource("detail", dt_detail); // datasetname of reporting
            var result = localreport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public DataTable DT_ReqFormIt_Id(string ReqNo)
        {
            var dt = new DataTable();
            dt.Columns.Add("ReqNo");
            dt.Columns.Add("UserName_Th");
            dt.Columns.Add("UserName_EN");
            dt.Columns.Add("UserPositionName");
            dt.Columns.Add("UserDeptSection");
            dt.Columns.Add("UserStatus");
            dt.Columns.Add("UserEmpCode");

            dt.Columns.Add("EffStartDate");
            dt.Columns.Add("EffEndDate");
            dt.Columns.Add("Reason");
            dt.Columns.Add("FilingName");
            dt.Columns.Add("FilingDeptSection");
            dt.Columns.Add("FilingDate");
            dt.Columns.Add("ContractNumber");
            dt.Columns.Add("ITBy");
            dt.Columns.Add("ITByDate");
            dt.Columns.Add("ITPosition");
            dt.Columns.Add("UserCompCode");
            dt.Columns.Add("UserLocation");
            dt.Columns.Add("ControlNo");
            dt.Columns.Add("LocationText");

            List <SP_ReqFormIt_Id> SP_ReqFormIt_Id = _YCGInventoryContext.SP_ReqFormIt_Id.FromSqlRaw("SP_ReqFormIt_Id " + ReqNo).ToList();


            DataRow row;

            row = NewMethod(ReqNo, dt, SP_ReqFormIt_Id);

            dt.Rows.Add(row);


            return dt;

            static DataRow NewMethod(string ReqNo, DataTable dt, List<SP_ReqFormIt_Id> SP_ReqFormIt_Id)
            {
                DataRow row = dt.NewRow();
                row["ReqNo"] = ReqNo;
                row["UserName_TH"] = SP_ReqFormIt_Id[0].UsersName_TH;
                row["UserName_EN"] = SP_ReqFormIt_Id[0].UsersFirstName_EN + ' ' + SP_ReqFormIt_Id[0].UsersLastName_EN;
                row["UserPositionName"] = SP_ReqFormIt_Id[0].Positiontext;
                row["UserDeptSection"] = SP_ReqFormIt_Id[0].UserDepartmentText + " - " + SP_ReqFormIt_Id[0].Usersectiontext;
                row["UserStatus"] = SP_ReqFormIt_Id[0].UserStatus;
                row["UserEmpCode"] = SP_ReqFormIt_Id[0].UsersEmpCode;
                row["EffStartDate"] = SP_ReqFormIt_Id[0].EffectStartDate;
                row["EffEndDate"] = SP_ReqFormIt_Id[0].EffectEndDate;
                row["Reason"] = SP_ReqFormIt_Id[0].Reason;
                row["FilingName"] = SP_ReqFormIt_Id[0].FilingEmpName;
                row["FilingDeptSection"] = SP_ReqFormIt_Id[0].FilingDepttext + '-' + SP_ReqFormIt_Id[0].FilingSectiontext;
                row["FilingDate"] = SP_ReqFormIt_Id[0].FilingAceptDate;
                row["ContractNumber"] = SP_ReqFormIt_Id[0].ContactNumber;
                row["ITBy"] = SP_ReqFormIt_Id[0].ITByEmpName;
                row["ITByDate"] = SP_ReqFormIt_Id[0].ITByDate;
                row["UserCompCode"] = SP_ReqFormIt_Id[0].UserCompCode ;
                row["UserLocation"] = SP_ReqFormIt_Id[0].UserLocationId ;
                row["ControlNo"] = SP_ReqFormIt_Id[0].ControlNo;
                row["LocationText"] = SP_ReqFormIt_Id[0].LocationText;
                return row;
            }
        }

        public DataTable DT_ReqFormItDetailList(string ReqNo)
        {
            var dt = new DataTable();
            dt.Columns.Add("ReqNo");
            dt.Columns.Add("ServiceCode");
            dt.Columns.Add("ServiceName");
            dt.Columns.Add("HowToCheck");
            dt.Columns.Add("Actions");
            dt.Columns.Add("ActionsUp");
            dt.Columns.Add("Remark");
            dt.Columns.Add("ImeiNo");
            dt.Columns.Add("AssetCode");
            dt.Columns.Add("Brand");
            dt.Columns.Add("Mouse");
            dt.Columns.Add("SerialNo");
            dt.Columns.Add("ItemAsset");
            dt.Columns.Add("ITRemark");

            List<SP_ReqFormItDetailList> SP_ReqFormItDetailList = _YCGInventoryContext.SP_ReqFormItDetailList.FromSqlRaw("SP_ReqFormItDetailList " + ReqNo).ToList();
            DataRow row;
            int i = 0;
            foreach(var x in SP_ReqFormItDetailList )
            { 
            row = dt.NewRow();
            row["ReqNo"] = ReqNo;
            row["ServiceCode"] = SP_ReqFormItDetailList[i].ServiceCode;
            row["ServiceName"] = SP_ReqFormItDetailList[i].ServiceName;
            row["HowToCheck"] = SP_ReqFormItDetailList[i].HowToCheck;
            row["Actions"] = SP_ReqFormItDetailList[i].Actions;
                if(SP_ReqFormItDetailList[i].ActionsUp == true)
                {  row["ActionsUp"] = "1";}
                else if (SP_ReqFormItDetailList[i].ActionsUp == false)
                { row["ActionsUp"] = "0"; }
           
            row["Remark"] = SP_ReqFormItDetailList[i].Remarks;
            row["ImeiNo"] = SP_ReqFormItDetailList[i].IMEINo;
            row["AssetCode"] = SP_ReqFormItDetailList[i].AssetCode;
            row["Brand"] = SP_ReqFormItDetailList[i].Brand;
            row["Mouse"] = SP_ReqFormItDetailList[i].mouse;
            row["SerialNo"] = SP_ReqFormItDetailList[i].ItemSerialNo;
            row["ItemAsset"] = SP_ReqFormItDetailList[i].ItemAssetNo;
            row["ITRemark"] = SP_ReqFormItDetailList[i].ITremark;

                i++;
            dt.Rows.Add(row);
            }
        
            return dt;
        }
    }
}
