using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YcgItInventorySystem_V2.Data;
using YcgItInventorySystem_V2.Models;
 
namespace YcgItInventorySystem_V2.Services
{
    public class EmpServiceInfo : IEmpservice
    {
       
        public ApplicationDbContext _ApplicationDbContext;

        public EmpServiceInfo(ApplicationDbContext context)
        {
            _ApplicationDbContext = context;
        }

        public string EmpLocation_get(string Username)
        {
            string result = "";
            try
            {

            string LocationId = (from e in _ApplicationDbContext.EmpMstEmployee
                                 where e.Username == Username
                                 select e.LocationId).FirstOrDefault();
                result = LocationId;
            return result;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public string EmpFirstName_get(string empcode)
        {
            string result = "";
            try
            {

                string LocationId = (from e in _ApplicationDbContext.EmpMstEmployee
                                     where e.EmployeeId == empcode
                                     select e.EmployeeNameFirst).FirstOrDefault();
                result = LocationId;
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public string EmpLastName_get(string empcode)
        {
            string result = "";
            try
            {

                string LocationId = (from e in _ApplicationDbContext.EmpMstEmployee
                                     where e.EmployeeId == empcode
                                     select e.EmployeeNameLast).FirstOrDefault();
                result = LocationId;
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

    }
}
