using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfEmployeeRecord.Views;

namespace WpfEmployeeRecord.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {

        Service service = new Service();
        MainWindow main;

        #region Constructors

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }

        #endregion

        #region Properties

        private string userName;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        #endregion

        #region Commands

        private ICommand logIn;

        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(param => LogInExecute(), param => CanLogInExecute());
                }

                return logIn;
            }
        }

        private void LogInExecute()
        {
            try
            {
                if (service.IsEmployee(UserName, Password))
                {
                    if (service.Role(UserName, Password) == "emloyee")
                    {
                        Employee employee = new Employee();
                        employee.ShowDialog();
                    }
                    else if (service.Role(UserName, Password) == "modify-HR")
                    {

                    }
                    else if (service.Role(UserName, Password) == "modify-R&D")
                    {

                    }
                    else if (service.Role(UserName, Password) == "modify-Finances")
                    {

                    }
                    else if (service.Role(UserName, Password) == "read-only-HR")
                    {

                    }
                    else if (service.Role(UserName, Password) == "read-only-R&D")
                    {

                    }
                    else if (service.Role(UserName, Password) == "read-only-Finances")
                    {

                    }
                }
                else if (UserName == "WPFadmin" && Password == "WPFadmin")
                {
                    Admin admin = new Admin();
                    admin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogInExecute()
        {
            return true;
        }

        #endregion
    }
}
