using System;
using System.Collections.Generic;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class EmpMstDepartment
    {
        public int DepartmentId { get; set; }
        public string DepartmentText { get; set; }
        public string DepartmentDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
