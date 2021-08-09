using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class AppModule
    {
        public string AppModuleId { get; set; }
        public int? AppId { get; set; }
        public int? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string SysController { get; set; }
        public int? Sequence { get; set; }
    }
}
