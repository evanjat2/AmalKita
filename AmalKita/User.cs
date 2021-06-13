using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmalKita2
{
    class User
    {
        private int _userID;
        private string _username;
        private string _password;

        public int UserID
        {
            get { return _userID; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Boolean Login(string LoginName, string Password)
        {
            if (LoginName == "Evan" & Password == "123")
            {
                _userID = 100;
                return true;
            }
            else
            {
                return false;
            }
        }
        public User() { }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
