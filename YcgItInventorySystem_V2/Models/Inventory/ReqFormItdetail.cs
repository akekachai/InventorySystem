using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class ReqFormItdetail
    {
        [Key]
        public string ReqNo { get; set; }
        [Key]
        public int ServiceCode { get; set; }
        public string Actions { get; set; }
        public bool? ActionsUp { get; set; }
        public string Remarks { get; set; }
        public string IMEINo { get; set; }
        public string AssetCode { get; set; }
        public string Brand { get; set; }

        [DefaultValue("")]
        public string ItemAssetNo { get; set; }
        [DefaultValue("")]
        public string ItemSerialNo { get; set; }
        [DefaultValue("")]
        public string TelNumber { get; set; }

        public Boolean CheckListByIT { get; set; }

        public DateTime? CheckListByITDate { get; set; }
        public string Mouse { get; set; }

        public DateTime? Enddate { get; set; }
        [DefaultValue("")]
        public string ITRemark { get; set; }

         public int TransactionId { get; set; }
   
    }
}
