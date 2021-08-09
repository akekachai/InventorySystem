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
    public class RptInvMstEmpAssetItemUsedController : Controller
    {
        public YCGInventoryContext _YCGInventoryContext;
        private readonly IWebHostEnvironment _webHostEnviroment;


        public RptInvMstEmpAssetItemUsedController(YCGInventoryContext ycginventoryContext, IWebHostEnvironment webHostEnvironment)
        {
            _YCGInventoryContext = ycginventoryContext;
            _webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            var dt = new DataTable();
        

            dt = DT_InvEmpAsset();
           
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\RptInvMstEmployeeAssetItemUsed.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
          
            LocalReport localreport = new LocalReport(path);

            localreport.AddDataSource("EmpAsset", dt); // datasetname of reporting

            //var result = localreport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            var result = localreport.Execute(RenderType.Excel, extension, parameters, mimtype);
        
            return File(result.MainStream, "application/msexcel", "RptInvMstEmployeeAssetItemUsed.xls");
            //return File(result.MainStream, "application/pdf");
        }

        public DataTable DT_InvEmpAsset()
        {
            var dt = new DataTable();
            dt.Columns.Add("EmployeeId");
            dt.Columns.Add("EmployeeName");
            dt.Columns.Add("ItemId");
            dt.Columns.Add("ItemText");
            dt.Columns.Add("ItemSerialNo");
            dt.Columns.Add("ItemAssetNo");
            dt.Columns.Add("ItemContractNo");
  


            List<RptInvMstEmployeeAssetItemUsed> RptInvMstEmployeeAssetItemUsed = _YCGInventoryContext.RptInvMstEmployeeAssetItemUsed.FromSqlRaw("RptInvMstEmployeeAssetItemUsedSelect").ToList();
            DataRow row;
            int i = 0;
            foreach (var x in RptInvMstEmployeeAssetItemUsed)
            {
                row = dt.NewRow();
                row["EmployeeId"] = x.EmployeeId;
                row["EmployeeName"] = x.EmployeeName;
                row["ItemId"] = x.ItemId;
                 row["ItemText"] = x.ItemText;
                row["ItemSerialNo"] = x.ItemSerialNo;
                row["ItemAssetNo"] = x.ItemAssetNo;
                row["ItemContractNo"] = x.ItemContractNo;

                i++;
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
