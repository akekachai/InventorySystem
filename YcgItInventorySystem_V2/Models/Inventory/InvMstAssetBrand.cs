using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class InvMstAssetBrand
    {
        public int BrandId { get; set; }
        public string BrandText { get; set; }
        public string BrandDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
