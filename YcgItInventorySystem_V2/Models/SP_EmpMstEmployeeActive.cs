using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models
{
    public class SP_EmpMstEmployeeActive
    {
        [Key]
        public string EmployeeId { get; set; }
        public string EmployeeNameTitle { get; set; }
        public string EmployeeNameFirst { get; set; }
        public string EmployeeNameLast { get; set; }

        public string EmployeeName { get; set; }
        public string EmployeeNameFull { get; set; }
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public string DepartmentId { get; set; }
        public string SectionId { get; set; }
        public string PositionId { get; set; }

        public string PositionText { get; set; }
        public string LevelId { get; set; }
    }
}
