﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
