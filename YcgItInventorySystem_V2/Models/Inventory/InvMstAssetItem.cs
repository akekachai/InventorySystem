using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class InvMstAssetItem
    {
        public int ItemId { get; set; }
        public string ItemText { get; set; }
        public string ItemDescription { get; set; }
        public string TypeId { get; set; }
        public string CatagoryId { get; set; }
        public string BrandId { get; set; }
        public string ModelId { get; set; }
        public string ItemExpireDateFlag { get; set; }
        public string ItemContractFlag { get; set; }
        public string ItemUnlimitFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
