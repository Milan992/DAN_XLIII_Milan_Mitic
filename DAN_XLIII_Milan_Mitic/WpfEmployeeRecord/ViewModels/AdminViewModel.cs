using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfEmployeeRecord.Model;
using WpfEmployeeRecord.Views;

namespace WpfEmployeeRecord.ViewModels
{
    class AdminViewModel : ViewModelBase
    {
        Admin admin;
        Service service = new Service();

        #region Constructors

        public AdminViewModel(Admin adminOpen)
        {
            employee = new tblEmployee();
            manager = new tblManager();
            admin = adminOpen;

            SectorList = service.GetAllSectors();
            AccessLevelList = service.GetAllAccesLevels();
        }

        #endregion

        #region Properties

        private tblEmployee employee;

        public tblEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private tblManager manager;

        public tblManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private List<tblSector> sectorList;

        public List<tblSector> SectorList
        {
            get
            {
                return sectorList;
            }
            set
            {
                sectorList = value;
                OnPropertyChanged("SectorList");
            }
        }

        private List<tblAccessLevel> accessLevelList;

        public List<tblAccessLevel> AccessLevelList
        {
            get
            {
                return accessLevelList;
            }
            set
            {
                accessLevelList = value;
                OnPropertyChanged("AccessLevelList");
            }
        }

        private tblSector sector;

        public tblSector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged("Sector");
            }
        }

        private tblAccessLevel accessLevel;

        public tblAccessLevel AccessLevel
        {
            get
            {
                return accessLevel;
            }
            set
            {
                accessLevel = value;
                OnPropertyChanged("AccessLevel");
            }
        }

        #endregion

        #region Commands

        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }

                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {
               tblEmployee newEmployee = service.AddEmployee(Employee);
                service.AddManager(newEmployee.EmployeeID, Sector.SectorID, AccessLevel.AccessLevelID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (!string.IsNullOrEmpty(Employee.JMBG))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Some fields are in incorrect format.");
                return false;
            }
        }

        private ICommand logOut;

        public ICommand LogOut
        {
            get
            {
                if (logOut == null)
                {
                    logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }

                return logOut;
            }
        }

        private void LogOutExecute()
        {
            try
            {
                admin.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogOutExecute()
        {
            return true;
        }

        #endregion
    }
}
