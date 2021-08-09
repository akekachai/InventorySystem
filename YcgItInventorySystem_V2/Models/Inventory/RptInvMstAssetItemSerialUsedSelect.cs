using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class RptInvMstAssetItemSerialUsedSelect
    {

        public string TypeText { get; set; }
        public string CatagoryText { get; set; }
        public int ItemId { get; set; }
        public string ItemText { get; set; }

        [Key]
        public string ItemSerialNo { get; set; }
        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        public string ItemAssetNo { get; set; }

        public int ItemSerialNoUsedFlag { get; set; }

        public int EmployeeIdUsedFlag { get; set; }

        public int EmployeeIdNotUsedFlag { get; set; }

        public int EmployeeIdUsedResignFlag { get; set; }
    }
}
