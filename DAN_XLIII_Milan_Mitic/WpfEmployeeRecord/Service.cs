using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployeeRecord.Model;

namespace WpfEmployeeRecord
{
    class Service
    {
        public string Role(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsEmployee(string userName, string password)
        {
            try
            {
                using (EmployeeEntities context = new EmployeeEntities())
                {
                    tblEmployee employee = (from x in context.tblEmployees where x.UserName == userName && x.Pass == password select x).First();
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
