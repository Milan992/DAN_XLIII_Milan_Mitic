﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfEmployeeRecord.ViewModels;

namespace WpfEmployeeRecord.Views
{
    /// <summary>
    /// Interaction logic for ModifyRDView.xaml
    /// </summary>
    public partial class ModifyRDView : Window
    {
        public ModifyRDView()
        {
            InitializeComponent();
            this.DataContext = new ModifyRDViewModel(this);
        }
    }
}
