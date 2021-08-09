using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class SP_Control_Report
    {
        [Key]
        public string ControlNo { get; set; }  
        public string EmpName { get; set; }
        public bool ActionsUp { get; set; }
        public string BrandText { get; set; }
        public string ItemText { get; set; }
        public string ItemSerialNo { get; set; }
        public string ItemAssetNo { get; set; }
        public string ReqNo { get; set; }

    }
}
