using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models
{
    public interface IMenuMasterService
    {
        IEnumerable<AppMenu> GetMenuMasters();
        IEnumerable<AppMenu> GetMenuMasters(String UserRole);
        IEnumerable<AppModule> GetGroupMenuMasters(String UserRole);
    }
}
