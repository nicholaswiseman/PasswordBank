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

        public ICommand AddButtonCommand { get; set; }

        public ICommand RemoveButtonCommand { get; set; }

        private MainWindowModel _model;

        private ObservableCollection<Login> _passwordList;

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
            this.PasswordTextBox = "";
            this.ServiceTextBox = "";
        }

        public void AddButton()
        {
            this.PasswordList.Add(new Login(ServiceTextBox, PasswordTextBox));
            this._model.AddToXml(ServiceTextBox, PasswordTextBox);
        }

        public void RemoveButton()
        {
            Login loginToRemove = new Login(ServiceTextBox, PasswordTextBox);

            foreach (Login login in PasswordList)
            {
                if (login.Service == ServiceTextBox)
                {
                    loginToRemove = login;
                    break;
                    //PasswordList.Remove(login);
                }
            }

            PasswordList.Remove(loginToRemove);

            this._model.RemoveFromXml(ServiceTextBox, PasswordTextBox);
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
