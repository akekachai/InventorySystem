using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class RunningInfo
    {
        [Key]
        public string InfoDesc { get; set; }
        public int Running { get; set; }
        public int InfoId { get; set; }
        public string Type { get; set; }
    }
}
