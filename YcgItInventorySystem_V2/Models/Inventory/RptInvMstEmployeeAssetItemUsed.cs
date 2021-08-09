using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class RptInvMstEmployeeAssetItemUsed
    {

        public string EmployeeId { get; set; }
       public string EmployeeName { get; set; }
    
        public int? ItemId { get; set; }
   public string ItemText { get; set; }
       [Key]
   public string ItemSerialNo { get; set; }

    public string ItemAssetNo { get; set; }

    public string ItemContractNo { get; set; }
    }
}
