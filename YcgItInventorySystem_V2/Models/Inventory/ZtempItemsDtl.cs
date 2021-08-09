using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class ZtempItemsDtl
    {
        public long? ItemId { get; set; }
        public string DtlItemSerialNo { get; set; }
        public string DtlItemAssetNo { get; set; }
        public string DtlItemContractNo { get; set; }
        public DateTime? DtlItemContractStartDate { get; set; }
        public DateTime? DtlItemContractExpireDate { get; set; }
        public int? DtlItemAvailableQty { get; set; }
        public int? DtlItemSerialCost { get; set; }
        public DateTime? DtlCreateDate { get; set; }
        public int? DtlCreateUserId { get; set; }
        public DateTime? DtlUpdateDate { get; set; }
        public int? DtlUpdateUserId { get; set; }
        public string DtlActiveFlag { get; set; }
    }
}
