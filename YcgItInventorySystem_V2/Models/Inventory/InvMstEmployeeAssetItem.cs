using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class InvMstEmployeeAssetItem
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string EmployeeId { get; set; }
        public int? ItemId { get; set; }
        public string ItemSerialNo { get; set; }
        public int? ItemQty { get; set; }
        public string ItemUserName { get; set; }
        public DateTime? ItemActualDate { get; set; }
        public DateTime? ItemReceiveDate { get; set; }
        public DateTime? ItemReturnDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
