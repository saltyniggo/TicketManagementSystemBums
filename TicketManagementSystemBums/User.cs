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
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }
        public string UserPassword
        {
            get
            {
                return this.userPassword;
            }
            set
            {
                this.userPassword = value;
            }
        }
        public string UserMail
        {
            get
            {
                return this.userMail;
            }
            set
            {
                this.userMail = value;
            }
        }
        
        public User()
        {
            this.UserName = "undefined";
            this.UserPassword = "undefined";
            this.UserMail = "undefined";
        }

        public User(string name, string password, string mail)
        {
            this.UserName = name;
            this.UserPassword = password;
            this.UserMail = mail;
        }

        public void updateUser(string name, string password, string mail)
        {
            this.UserName = name;
            this.UserPassword = password;
            this.UserMail = mail;
        }
    }
}
