using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YcgItInventorySystem_V2.Data;
using YcgItInventorySystem_V2.Models.Inventory;

namespace YcgItInventorySystem_V2.Services
{
public class AssetsInfo : IAssetInfo
    {
  public YCGInventoryContext _YCGInventoryContext ;

    public AssetsInfo(YCGInventoryContext context)
    {
        _YCGInventoryContext = context;
    }

        public string AssetitemText_get(int Itemid)
        {
            string result = "";
            try
            {

                string ItemTexts = (from e in _YCGInventoryContext.InvMstAssetItems
                                   where e.ItemId == Itemid
                                   select e.ItemText).FirstOrDefault();
                result = ItemTexts;
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }


        public List<InvMstAssetItemSerial> AssetitemInfo_get(string ItemSerialNo)
        {
            List<InvMstAssetItemSerial> Iteminfo  ;
            try
            {

                Iteminfo = (from e in _YCGInventoryContext.InvMstAssetItemSerials
                                    where e.ItemSerialNo == ItemSerialNo
                                    select e).ToList();
                return Iteminfo;
            }
            catch (Exception)
            {

                throw;
            }
            return Iteminfo;
        }



    }
}
