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
    class ModifyRDViewModel : ViewModelBase
    {
        ModifyRDView view;
        Service service = new Service();

        #region Constructors

        public ModifyRDViewModel(ModifyRDView viewOpen)
        {
            employee = new tblEmployee();
            view = viewOpen;

            EmployeeList = service.GetAllEmployees();
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

        private List<tblEmployee> employeeList;

        public List<tblEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        #endregion

        #region Commands

        private ICommand addEmployee;

        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(param => AddEmployeeExecute(), param => CanAddEmployeeExecute());
                }

                return addEmployee;
            }
        }

        private void AddEmployeeExecute()
        {
            try
            {
                AddEmployee addEmployee = new AddEmployee();
                addEmployee.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddEmployeeExecute()
        {
            return true;
        }
        private ICommand fillReport;

        public ICommand FillReport
        {
            get
            {
                if (fillReport == null)
                {
                    fillReport = new RelayCommand(param => FillReportExecute(), param => CanFillReportExecute());
                }

                return fillReport;
            }
        }

        private void FillReportExecute()
        {
            Employee employee = new Employee();
            employee.ShowDialog();
        }

        private bool CanFillReportExecute()
        {
            return true;
        }
        #endregion
    }
}
