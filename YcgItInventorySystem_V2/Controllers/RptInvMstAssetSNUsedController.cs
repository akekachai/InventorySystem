using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using YcgItInventorySystem_V2.Models.Inventory;

namespace YcgItInventorySystem_V2.Controllers
{
    public class RptInvMstAssetSNUsedController : Controller
    {
        public YCGInventoryContext _YCGInventoryContext;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public RptInvMstAssetSNUsedController(YCGInventoryContext ycginventoryContext, IWebHostEnvironment webHostEnvironment)
        {
            _YCGInventoryContext = ycginventoryContext;
            _webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult printreport(string printtype)
        {
            var dt = new DataTable();


            dt = DT_ALLAsset();

            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\RptInvAllAsset.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            LocalReport localreport = new LocalReport(path);

            localreport.AddDataSource("AllAssets", dt); // datasetname of reporting
            if (printtype == "PDF")
            {
                var result = localreport.Execute(RenderType.Pdf, extension, parameters, mimtype);
                return File(result.MainStream, "application/pdf");
            }
            else 
            {
                var result = localreport.Execute(RenderType.Excel, extension, parameters, mimtype);
                return File(result.MainStream, "application/msexcel", "RptInvMstAssetItemSerialUsed.xls");
            }
        }

        public IActionResult Index()
        {

            return View();
        }

        public DataTable DT_ALLAsset()
        {
            var dt = new DataTable();
             
            dt.Columns.Add("TypeText");
            dt.Columns.Add("CatagoryText");
            dt.Columns.Add("ItemId");
            dt.Columns.Add("ItemText");
            dt.Columns.Add("ItemSerialNo");
            dt.Columns.Add("EmployeeId");
            dt.Columns.Add("EmployeeName");
            dt.Columns.Add("ItemAssetNo");
            dt.Columns.Add("ItemSerialNoUsedFlag");
            dt.Columns.Add("EmployeeIdUsedFlag");
            dt.Columns.Add("EmployeeIdNotUsedFlag");
            dt.Columns.Add("EmployeeIdUsedResignFlag");
         


        List<RptInvMstAssetItemSerialUsedSelect> RptInvMstAssetItemSerialUsedSelect = _YCGInventoryContext.RptInvMstAssetItemSerialUsedSelects.FromSqlRaw("RptInvMstAssetItemSerialUsedSelect").ToList();
            DataRow row;
            int i = 0;
            foreach (var x in RptInvMstAssetItemSerialUsedSelect)
            {
                row = dt.NewRow();
                row["EmployeeId"] = x.EmployeeId;
                row["EmployeeName"] = x.EmployeeName;
                row["ItemId"] = x.ItemId;
                row["ItemText"] = x.ItemText;
                row["ItemSerialNo"] = x.ItemSerialNo;
                row["ItemAssetNo"] = x.ItemAssetNo;
                row["TypeText"] = x.TypeText;
                row["CatagoryText"] = x.CatagoryText;



                row["ItemSerialNoUsedFlag"] = x.ItemSerialNoUsedFlag;
                row["EmployeeIdUsedFlag"] = x.EmployeeIdUsedFlag;
                row["EmployeeIdNotUsedFlag"] = x.EmployeeIdNotUsedFlag;
                row["EmployeeIdUsedResignFlag"] = x.EmployeeIdUsedResignFlag;

                i++;
                dt.Rows.Add(row);
            }

            return dt;
        }

    }
}
