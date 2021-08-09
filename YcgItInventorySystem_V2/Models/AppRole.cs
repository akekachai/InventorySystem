using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class AppRole
    {
        public string AppRoleId { get; set; }
        public int? AppId { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
