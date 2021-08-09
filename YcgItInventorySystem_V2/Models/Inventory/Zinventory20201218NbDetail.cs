using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class Zinventory20201218NbDetail
    {
        public long? ItemId { get; set; }
        public string ItemText { get; set; }
        public string ItemDescription { get; set; }
        public string TypeId { get; set; }
        public string CatagoryId { get; set; }
        public string BrandId { get; set; }
        public string ModelId { get; set; }
        public string ItemExpireDateFlag { get; set; }
        public string ItemContractFlag { get; set; }
        public string ItemUnlimitFlag { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
        public string Nb { get; set; }
        public string ยหอ { get; set; }
        public string รน { get; set; }
        public string Sn { get; set; }
        public double? Asset { get; set; }
        public string เลขทสญญา { get; set; }
        public DateTime? เรมสญญา { get; set; }
        public DateTime? สนสดสญญา { get; set; }
        public string เรมสญญาคศ { get; set; }
        public string สนสดสญญาคศ { get; set; }
    }
}
