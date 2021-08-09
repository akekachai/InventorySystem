using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class EmpMstCompany
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyText { get; set; }
        public string CompanyDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
