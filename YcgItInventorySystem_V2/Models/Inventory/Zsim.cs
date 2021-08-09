using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class Zsim
    {
        public double? รหสพนกงาน { get; set; }
        public string ชอ { get; set; }
        public string เบอร { get; set; }
        public DateTime? เรมสญญา { get; set; }
        public DateTime? หมดสญญา { get; set; }
    }
}
