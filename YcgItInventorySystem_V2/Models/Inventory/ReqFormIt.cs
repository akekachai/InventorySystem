using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class Req_FormIt
    {
        [Key]
        public string ReqNo { get; set; }
        public string UserStatus { get; set; }
        public int UsersNameTitle { get; set; }
 
        public string UsersFirstName_TH { get; set; }
 
        public string UsersLastName_TH { get; set; }
 
        public string UsersEmpCode { get; set; }
 
        public string UsersFirstName_EN { get; set; }
 
        public string UsersLastName_EN { get; set; }
 

        public int UserCompCode { get; set; }

        public int UserLocationId { get; set; }
        public int UserDeptCode { get; set; }

        public int UserSectionId { get; set; }

        public int UserLevelId { get; set; }
       
        public string UserPosition { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EffectStartDate { get; set; }

   

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EffectEndDate { get; set; }
        [Required]
        public string Reason { get; set; }
        public string FilingEmpCode { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? FilingAceptDate { get; set; }
        public int FilingDept { get; set; }

        public int FilingSection { get; set; }
        public int OfficeBranch { get; set; }

        public string ControlNo { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; } 

        public string ReqStatus { get; set; }

        public int LocationId { get; set; }

        public string ITBy { get; set; }

        public DateTime? ITByDate { get; set; }

        public int ITProcessBy { get; set; }
        public DateTime? ITProcessByDate { get; set; }
        public int ITViewer { get; set; }
        public DateTime? ITViewerDate { get; set; }
        public int ITVerify { get; set; }
        public DateTime? ITVerifyDate { get; set; }
    }
}
