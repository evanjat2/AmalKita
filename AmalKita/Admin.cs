using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmalKita2
{
    class Admin
    {
        private int _adminID;
        private string _adminname;
        private string _password;

        public int AdminID
        {
            get { return _adminID; }
        }
        public string Adminname
        {
            get { return _adminname; }
            set { _adminname = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Admin() { }
        public Admin(string adminname, string password)
        {
            Adminname = adminname;
            Password = password;
        }
    }
}
