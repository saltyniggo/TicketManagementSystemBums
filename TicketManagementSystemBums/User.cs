using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemBums
{
    public class User
    {
        private int userID;
        private string userName;
        private string userPassword;
        private string userMail;

        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public string UserPassword
        {
            get
            {
                return userPassword;
            }
            set
            {
                userPassword = value;
            }
        }
        public string UserMail
        {
            get
            {
                return userMail;
            }
            set
            {
                userMail = value;
            }
        }
        
        public User()
        {
        }

        public User(string name, string password, string mail)
        {
            UserName = name;
            UserPassword = password;
            UserMail = mail;
        }

        public void updateUser(string name, string password, string mail)
        {
            UserName = name;
            UserPassword = password;
            UserMail = mail;
        }
    }
}
