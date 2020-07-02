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
    class EmployeeViewModel : ViewModelBase
    {

        Employee employee;
        Service service = new Service();

        #region Constructors

        public EmployeeViewModel(Employee employeeOpen)
        {
            report = new tblReport();
            employee = employeeOpen;
        }

        #endregion

        #region Properties

        private tblReport report;

        public tblReport Report
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
                OnPropertyChanged("Report");
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
               service.AddReport(report);
                MessageBox.Show("Report saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            return true;
        }

        #endregion
    }
}
