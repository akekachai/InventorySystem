using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class InvMstAssetCatagory
    {
        public int CatagoryId { get; set; }
        public string CatagoryText { get; set; }
        public string CatagoryDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
