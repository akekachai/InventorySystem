using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class EmpMstEmployee
    {
        [Key]
        public string EmployeeId { get; set; }
        public string EmployeeNameTitle { get; set; }
        public string EmployeeNameFirst { get; set; }
        public string EmployeeNameLast { get; set; }
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public string DepartmentId { get; set; }
        public string SectionId { get; set; }
        public string PositionId { get; set; }
        public string LevelId { get; set; }
        public string EmployeeTelephone { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public DateTime? EmployeeStartDate { get; set; }
        public string EmployeeResignFlag { get; set; }
        public DateTime? EmployeeResignDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
        public string Username { get; set; }
    }
}
