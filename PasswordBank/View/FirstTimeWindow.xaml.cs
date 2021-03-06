﻿using PasswordBank.ViewModel;
using System;
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

namespace PasswordBank.View
{
    /// <summary>
    /// Interaction logic for FirstTimeWindow.xaml
    /// </summary>
    public partial class FirstTimeWindow : Window
    {
        public FirstTimeWindow(System.Xml.Linq.XDocument xmlData, string xmlPath)
        {
            InitializeComponent();
            this.DataContext = new FirstTimeWindowViewModel(xmlData, xmlPath);
        }
    }
}
