using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployeeRecord.Model;

namespace WpfEmployeeRecord
{
    class Service
    {
        // int to keep an ID of the employee that tries to login.
        static int id;

        public string Role(string userName, string password)
        {
            try
            {
                using (EmployeeEntities context = new EmployeeEntities())
                {
                    tblManager manager = (from x in context.tblManagers where x.EmployeeID == id select x).First();
                    tblSector sector = (from s in context.tblSectors where s.SectorID == manager.SectorID select s).First();
                    tblAccessLevel accesLevel = (from a in context.tblAccessLevels where a.AccessLevelID == manager.AccessLevelID select a).First();
                    return accesLevel.AccessLevel + "-" + sector.SectorName;
                }
            }
            catch
            {
                return "employee";
            }
        }

        public bool IsEmployee(string userName, string password)
        {
            try
            {
                using (EmployeeEntities context = new EmployeeEntities())
                {
                    tblEmployee employee = (from x in context.tblEmployees where x.UserName == userName && x.Pass == password select x).First();
                    id = employee.EmployeeID;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
