using GalaSoft.MvvmLight.Command;
using PasswordBank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace PasswordBank.ViewModel
{
    class MainWindowViewModel
    {

        public ObservableCollection<Login> PasswordList { get; set; }
        public string PasswordTextBox { get; set; }
        public string ServiceTextBox { get; set; }

        public ICommand AddButtonCommand { get; set; }

        private MainWindowModel _model;

        /// <summary>
        /// constructor
        /// </summary>
        public MainWindowViewModel()
        {
            //link model and viewmodel
            this._model = new MainWindowModel(this);
            this.AddButtonCommand = new RelayCommand(AddButton);
            this.PasswordTextBox = "";
            this.ServiceTextBox = "";
        }

        public void AddButton()
        {
            this.PasswordList.Add(new Login(ServiceTextBox, PasswordTextBox));
            this._model.AddToXml(ServiceTextBox, PasswordTextBox);
        }

    }
}
