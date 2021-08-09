using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class ReqServiceType
    {
        public int ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int? Sequence { get; set; }
        public bool? Active { get; set; }

        public string HowToCheck { get; set; }

        public string CatagoryId { get; set; }

        public int ItemId { get; set; }
    }
}
