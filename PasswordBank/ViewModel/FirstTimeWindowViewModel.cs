using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace PasswordBank.ViewModel
{
    class FirstTimeWindowViewModel
    {
        public string PasswordSetUp { get; set; }
        public string PasswordSetUpConfirm { get; set; }
        public RelayCommand<Window> SetUpButtonCommand { get; set; }

        public XDocument XmlDatabase { get; set; }

        public string XmlPath { get; set; }

        public FirstTimeWindowViewModel(XDocument xmlData, string xmlPath)
        {
            this.XmlDatabase = xmlData;
            this.XmlPath = xmlPath;
            this.SetUpButtonCommand = new RelayCommand<Window>(SetUpButton);
        }
        public void SetUpButton(Window window)
        {
            if(PasswordSetUp == PasswordSetUpConfirm)
            { 
                XmlDatabase.Element("logins").Add(new XElement("MasterPassword", PasswordSetUp));
                XmlDatabase.Save(XmlPath);
                if(window!=null)
                {
                    window.Close();
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match!");
            }
        }
    }
}
