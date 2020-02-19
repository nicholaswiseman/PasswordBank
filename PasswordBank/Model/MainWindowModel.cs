using PasswordBank.View;
using PasswordBank.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PasswordBank.Model
{
    class MainWindowModel
    {
        public XDocument XmlDatabase
        {
            get
            {
                return _xmlDatabase;
            }
            set
            {
                _xmlDatabase = value;
                this.ViewModel.PasswordList = this.GetPasswordList();
            }
        }

        public string XmlPath { get; set; }

        public MainWindowViewModel ViewModel { get; set; }

        private XDocument _xmlDatabase;

        /// <summary>
        /// constructor
        /// </summary>
        public MainWindowModel(MainWindowViewModel vm)
        {
            this.ViewModel = vm;

            InitXmlDatabase();

            if (this.XmlDatabase.Element("MasterPassword") == null)
            {
                var firstTimeWin = new FirstTimeWindow();
                firstTimeWin.ShowDialog();
            }
        }

        public void InitXmlDatabase()
        {
                this.XmlPath = $@"{Directory.GetCurrentDirectory()}/database.xml";

                if (!File.Exists(XmlPath))
                {
                    CreateXmlDatabase();
                }
                else
                {
                    XmlDatabase = XDocument.Load(XmlPath);
                }

        }

        public void AddToXml(string service, string password)
        {
            XmlDatabase.Element("logins").Add(new XElement("login",
                new XElement("service", service),
                new XElement("pw", password)));
            XmlDatabase.Save(XmlPath);
            //XmlDatabase = XDocument.Load(XmlPath);

        }

        public void RemoveFromXml(string service, string password)
        {
            try
            {
                foreach (var element in XmlDatabase.Element("logins").Descendants("login"))
                {

                    if(element.Element("service").Value == service)
                    {
                        element.Remove();
                        XmlDatabase.Save(XmlPath);
                    }
                }
            }
            catch
            {

            }
        }
        public ObservableCollection<Login> GetPasswordList()
        {
            ObservableCollection<Login> res = new ObservableCollection<Login>();
            try
            {
                foreach (var element in XmlDatabase.Element("logins").Descendants("login"))
                {

                    string service = element.Element("service").Value;
                    string pw = element.Element("pw").Value;
                    res.Add(new Login(service, pw));

                }
            }
            catch
            {

            }

            return res;
        }

        public void CreateXmlDatabase()
        {
            this.XmlDatabase = new XDocument();
            XmlDatabase.Add(new XElement("logins"));
            XmlDatabase.Save(XmlPath);
        }
    }

    public class Login
    {
        public string Service { get; set; }
        public string Password { get; set; }

        public Login(string service, string pw)
        {
            this.Service = service;
            this.Password = pw;
        }
    }
}
