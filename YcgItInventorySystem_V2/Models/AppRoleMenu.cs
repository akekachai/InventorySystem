using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class AppRoleMenu
    {
        public string AppRoleId { get; set; }
        public string AppMenuId { get; set; }
        public bool? Views { get; set; }
        public bool? Adds { get; set; }
        public bool? Edits { get; set; }
        public bool? Deletes { get; set; }
        public bool? Prints { get; set; }
        public bool? Active { get; set; }
    }
}
