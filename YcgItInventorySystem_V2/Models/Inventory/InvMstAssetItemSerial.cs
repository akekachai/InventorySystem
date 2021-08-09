using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class InvMstAssetItemSerial
    {
        public int ItemId { get; set; }
        public string ItemSerialNo { get; set; }
        public string ItemAssetNo { get; set; }
        public string ItemContractNo { get; set; }
        public string ItemContractStartDate { get; set; }
        public string ItemContractExpireDate { get; set; }
        public int? ItemAvailableQty { get; set; }
        public decimal? ItemSerialCost { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
        public int CompCode { get; set; }
        public int LocationId { get; set; }
    }
}
