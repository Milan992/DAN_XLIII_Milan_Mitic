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

        /// <summary>
        /// Returns employee's role.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if there is any employee in the database with entered username and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds an employee to database.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public tblEmployee AddEmployee(tblEmployee employee)
        {
            try
            {
                employee.DateOfBirth = GetDateFromJmbg(employee.JMBG);
                using (EmployeeEntities context = new EmployeeEntities())
                {
                    tblEmployee newEmployee = new tblEmployee();

                    newEmployee.EmployeeName = employee.EmployeeName;
                    newEmployee.EmployeeLastName = employee.EmployeeLastName;
                    newEmployee.DateOfBirth = employee.DateOfBirth;
                    newEmployee.JMBG = employee.JMBG;
                    newEmployee.BankAccountNumber = employee.BankAccountNumber;
                    newEmployee.Email = employee.Email;
                    newEmployee.Salary = employee.Salary;
                    newEmployee.Position = employee.Position;
                    newEmployee.UserName = employee.UserName;
                    newEmployee.Pass = employee.Pass;

                    context.tblEmployees.Add(employee);
                    context.SaveChanges();

                    newEmployee.EmployeeID = employee.EmployeeID;
                    return newEmployee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Adds a manager to database.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="sectorID"></param>
        /// <param name="accessLevelID"></param>
        public void AddManager(int employeeID, int sectorID, int accessLevelID)
        {
            try
            {
                using (EmployeeEntities context = new EmployeeEntities())
                {
                    tblManager manager = new tblManager();
                    manager.EmployeeID = employeeID;
                    manager.SectorID = sectorID;
                    manager.AccessLevelID = accessLevelID;
                    context.tblManagers.Add(manager);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Adds all the acces levels from the database to a list.
        /// </summary>
        /// <returns></returns>
        public List<tblAccessLevel> GetAllAccesLevels()
        {
            try
            {
                using (EmployeeEntities context = new EmployeeEntities())
                {
                    List<tblAccessLevel> list = new List<tblAccessLevel>();
                    list = (from x in context.tblAccessLevels select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Adds all the sectors from the database to a list.
        /// </summary>
        /// <returns></returns>
        public List<tblSector> GetAllSectors()
        {
            try
            {
                using (EmployeeEntities context = new EmployeeEntities())
                {
                    List<tblSector> list = new List<tblSector>();
                    list = (from x in context.tblSectors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Caculates date from JMBG.
        /// </summary>
        /// <param name="jMBG"></param>
        /// <returns></returns>
        public DateTime GetDateFromJmbg(string jmbg)
        {
            string date = "1" + jmbg.Substring(4, 3) + "-" + jmbg.Substring(2, 2) + "-" + jmbg.Substring(0, 2);
            DateTime dateOfBirth = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return dateOfBirth;
        }
    }
}
