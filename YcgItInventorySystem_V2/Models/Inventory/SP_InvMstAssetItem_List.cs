using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class SP_InvMstAssetItem_List
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemText { get; set; }
        public string ItemDescription { get; set; }

        //public int TypeId { get; set; }
        public string TypeText { get; set; }

        //public int CatagoryId { get; set; }
       public string CatagoryText { get; set; }

        //public int BrandId { get; set; }
        public string BrandText { get; set; }

        //public int ModelId { get; set; }
        public string ModelText { get; set; }

        public string UpdateDate { get; set; }

        public string ActiveFlag { get; set; }

    }
}
