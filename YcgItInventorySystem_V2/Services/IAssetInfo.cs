using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YcgItInventorySystem_V2.Data;
using YcgItInventorySystem_V2.Models.Inventory;

namespace YcgItInventorySystem_V2.Services
{

    public interface IAssetInfo
    {
        string AssetitemText_get(int Itemid);

        List<InvMstAssetItemSerial> AssetitemInfo_get(string ItemSerialNo);
    }
}
