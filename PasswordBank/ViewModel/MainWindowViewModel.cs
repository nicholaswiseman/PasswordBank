using PasswordBank.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml.Linq;

namespace PasswordBank.ViewModel
{
    class MainWindowViewModel
    {

        public List<Login> PasswordList { get; set; }

        private MainWindowModel _model;

        /// <summary>
        /// constructor
        /// </summary>
        public MainWindowViewModel()
        {
            //link model and viewmodel
            this._model = new MainWindowModel(this);
        }


    }
}
