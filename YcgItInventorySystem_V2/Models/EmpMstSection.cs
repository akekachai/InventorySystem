using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class EmpMstSection
    {
        [Key]
        public int SectionId { get; set; }
        public string SectionText { get; set; }
        public string SectionDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
