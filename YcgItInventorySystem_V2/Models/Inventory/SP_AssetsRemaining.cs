using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public class SP_AssetsRemaining
    {
        public int  ItemId { get; set; }
        [Key]
        public string ItemSerialNo { get; set; }
        public string ItemAssetNo { get; set; }
        public string ItemContractNo { get; set; }
        public string ActiveFlag { get; set; }
        public int CompCode { get; set; }
        public int LocationId { get; set; }

        public string itemtext { get; set; }

        public string Brandtext { get; set; }

    }
}
