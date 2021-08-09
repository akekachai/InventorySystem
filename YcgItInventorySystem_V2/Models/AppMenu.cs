using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class AppMenu
    {
        public string AppMenuId { get; set; }
        public int AppId { get; set; }
        public int MenuId { get; set; }
        public string AppModuleId { get; set; }
        public string MenuName_TH { get; set; }
        public string MenuName_EN { get; set; }
        public string MenuPath { get; set; }
        public int? MenuSort { get; set; }
        public bool? Active { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
