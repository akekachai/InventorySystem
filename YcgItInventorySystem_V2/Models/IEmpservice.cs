using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YcgItInventorySystem_V2.Models
{
    public interface IEmpservice
    {
        string EmpLocation_get(string Username);
        string EmpFirstName_get(string empcode);

        string EmpLastName_get(string empcode);
    }
}
