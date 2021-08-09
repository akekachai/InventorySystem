using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class InvMstEmployeeAssetComment
    {
        public DateTime TransactionDate { get; set; }
        public string EmployeeId { get; set; }
        public string CommentText { get; set; }
    }
}
