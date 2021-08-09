using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace YcgItInventorySystem_V2.Models
{
    public partial class EmpMstLevel
    {
        [Key]
        public int LevelId { get; set; }
        public string LevelText { get; set; }
        public string LevelDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
