using GalaSoft.MvvmLight.Command;
using PasswordBank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace PasswordBank.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Login> PasswordList
        {
            get
            {
                return _passwordList;
            }
            set
            {
                _passwordList = value;
                OnPropertyChanged("PasswordList");
            }
        }
        public string PasswordTextBox { get; set; }
        public string ServiceTextBox { get; set; }
        public string AppLoginTextbox { get; set; }
        public bool LoggedIn
        {
            get
            {
                return _loggedIn;
            }
            set
            {
                _loggedIn = value;
                OnPropertyChanged("LoggedIn");
            }
        }
        public ICommand AddButtonCommand { get; set; }
        public ICommand RemoveButtonCommand { get; set; }
        public ICommand AppLoginCommand { get; set; }

        private MainWindowModel _model;

        private ObservableCollection<Login> _passwordList;

        private bool _loggedIn;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// constructor
        /// </summary>
        public MainWindowViewModel()
        {
            //link model and viewmodel
            this._model = new MainWindowModel(this);
            this.AddButtonCommand = new RelayCommand(AddButton);
            this.RemoveButtonCommand = new RelayCommand(RemoveButton);
            this.AppLoginCommand = new RelayCommand(AppLogin);
            this.PasswordTextBox = "";
            this.ServiceTextBox = "";
        }

        public void AddButton()
        {
            this._model.AddToXml(ServiceTextBox, PasswordTextBox);
        }

        public void RemoveButton()
        {
            this._model.RemoveFromXml(ServiceTextBox, PasswordTextBox);
        }

        public void AppLogin()
        {
            this._model.AppLogin(this.AppLoginTextbox);
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
