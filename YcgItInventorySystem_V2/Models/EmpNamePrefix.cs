using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class EmpNamePrefix
    {
        public int Id { get; set; }
        public string NamePrefix { get; set; }
        public string Sequence { get; set; }

        public string NamePrefix_EN { get; set; }
    }
}
