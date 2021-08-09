using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class AppSystemPortal
    {
        public int AppId { get; set; }
        public string AppName { get; set; }
        public bool? Active { get; set; }
    }
}
