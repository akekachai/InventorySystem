using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class ZtempItem
    {
        public long? ItemId { get; set; }
        public string ItemText { get; set; }
        public int? ItemDescription { get; set; }
        public int? CatagoryId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public string ItemExpireDateFlag { get; set; }
        public string ItemContractFlag { get; set; }
        public string ItemUnlimitFlag { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
        public string Div { get; set; }
        public long? DtlItemId { get; set; }
        public string DtlItemSerialNo { get; set; }
        public string DtlItemAssetNo { get; set; }
        public string DtlItemContractNo { get; set; }
        public DateTime? DtlItemContractStartDate { get; set; }
        public DateTime? DtlItemContractExpireDate { get; set; }
        public int DtlItemAvailableQty { get; set; }
        public int DtlItemSerialCost { get; set; }
        public DateTime DtlCreateDate { get; set; }
        public int DtlCreateUserId { get; set; }
        public DateTime DtlUpdateDate { get; set; }
        public int DtlUpdateUserId { get; set; }
        public string DtlActiveFlag { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }
        public string Col5 { get; set; }
        public string Col6 { get; set; }
        public DateTime? Col7 { get; set; }
        public DateTime? Col8 { get; set; }
    }
}
