using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class ZtempItemsHdr
    {
        public long? ItemId { get; set; }
        public string ItemText { get; set; }
        public int? ItemDescription { get; set; }
        public string TypeId { get; set; }
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
    }
}
