using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class SP_ReqFormItList
    {
        [Key]
        public string  ReqNo { get; set; }
        public string UsersName_TH { get; set; }

        public string ReqStatus { get; set; }

        public string ReqStatusDesc { get; set; }

        public int LocationId { get; set; }

        public string DepartmentText { get; set; }
    }
}
