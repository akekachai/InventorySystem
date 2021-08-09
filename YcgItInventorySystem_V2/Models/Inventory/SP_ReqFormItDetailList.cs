using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class SP_ReqFormItDetailList
    {
        [Key]
        public string ReqNo { get; set; }
        [Key]
        public int ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int? Sequence { get; set; }
        public bool? Active { get; set; }
    
    
        public string Actions { get; set; }
        public bool? ActionsUp { get; set; }
        public string Remarks { get; set; }
        public string IMEINo { get; set; }
        public string AssetCode { get; set; }
        public string Brand { get; set; }
        public string HowToCheck { get; set; }

        public string CatagoryId { get; set; }
        public string mouse { get; set; }

        public string Enddate { get; set; }
        public string ItemSerialNo { get; set; }

        public string ItemAssetNo { get; set; }
        
        public bool? CheckListByIT { get; set; }

       // public string ItemText { get; set; }

        public string ITremark { get; set; }

        public string ItemActualDate { get; set; }

        public string ItemReceiveDate { get; set; }
    }
}
