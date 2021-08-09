using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class SP_EmpHandleAsset_Detail
    {
        [Key]
        public int TransactionId { get; set; }
        public string EmployeeId { get; set; }
        public string EmpName { get; set; }
        public int ItemId { get; set; }
        public string ItemText { get; set; }
        [Key]
        public string ItemSerialNo { get; set; }
        public string ItemAssetNo { get; set; }
        public string ItemActualDate { get; set; }
        public string ItemReceiveDate  { get; set; }
        public string ActiveFlag { get; set; }

    }
}


