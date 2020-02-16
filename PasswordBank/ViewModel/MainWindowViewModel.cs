using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PasswordBank.ViewModel
{
    class MainWindowViewModel
    {

        public string Password { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public MainWindowViewModel()
        {
            this.Password = "hello";
        }

    }
}
