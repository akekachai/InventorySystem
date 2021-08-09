using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YcgItInventorySystem_V2.Models;
using YcgItInventorySystem_V2.Data;

namespace YcgItInventorySystem_V2.Services
{
    public class MenuMasterService : IMenuMasterService
    {
        private readonly ApplicationDbContext _dbContext;

        public MenuMasterService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AppMenu> GetMenuMasters()
        {
            return _dbContext.AppMenu.AsEnumerable();

        }
     
        public IEnumerable<AppMenu> GetMenuMasters(string UserNames)
        {

            var RoleInfo = (from Re in _dbContext.AppRoleEmployee
                           join R in _dbContext.AppRole on Re.AppRoleId equals R.AppRoleId
                           where Re.Username == UserNames && R.AppId == 1 
                            select Re).ToList(); 


            var Results = (from Rm in _dbContext.AppRoleMenu
                          join M in _dbContext.AppMenu on Rm.AppMenuId equals M.AppMenuId
                          where Rm.AppRoleId == RoleInfo[0].AppRoleId && M.AppId == 1
                           select M).OrderBy(M => M.MenuSort).ToList();

             
            return Results;
        }
        public class GroupModule
        {
            public string AppModuleId { get; set; }
            public int AppId { get; set; }
            public int ModuleId { get; set; }
            public string ModuleName { get; set; }

            public int Sequence { get; set; }
        }
        public IEnumerable<AppModule> GetGroupMenuMasters(string UserNames)
        {

            var RoleInfo = (from Re in _dbContext.AppRoleEmployee
                            join Rm in _dbContext.AppRoleMenu on Re.AppRoleId equals Rm.AppRoleId
                            where Re.Username == UserNames && Re.AppId == 1
                            select Re).ToList();

            var Menu_s = (from Rm in _dbContext.AppRoleMenu
                           join M in _dbContext.AppMenu on Rm.AppMenuId equals M.AppMenuId
                           where Rm.AppRoleId == RoleInfo[0].AppRoleId && M.AppId == 1
                          select M).OrderBy(M => M.MenuSort).ToList();

            var grm = (from Ms in Menu_s
                       join Gm in _dbContext.AppModule on Ms.AppModuleId equals Gm.AppModuleId
                      group Gm by new { Gm.AppModuleId , Gm.AppId , Gm.ModuleId ,Gm.ModuleName, Gm.Sequence } into mcs
                       select new AppModule()
                      { 
                          AppModuleId = mcs.Key.AppModuleId,
                          AppId =mcs.Key.AppId,
                          ModuleId = mcs.Key.ModuleId,
                          ModuleName = mcs.Key.ModuleName,
                          Sequence = mcs.Key.Sequence,
                      }).OrderBy(x => x.Sequence).ToList();

             

            //var GrpMenu = (from G in _dbContext.AppModule

            //               orderby G.Sequence
            //               select G).ToList();


            return grm;
        }
    }
}
