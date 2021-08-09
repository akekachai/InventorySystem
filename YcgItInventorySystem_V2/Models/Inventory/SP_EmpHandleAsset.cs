using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class SP_EmpHandleAsset
    {
        [Key]
        public Int64 row_num { get; set; }
        public String EmployeeId { get; set; }

        public string EmpName { get; set; }
    }
}
