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

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserMail { get; set; }
        
        public User()
        {
            userName = "undefined";
            userPassword = "undefined";
            userMail = "undefined";
        }

        public User(string name, string password, string mail)
        {
            userName = name;
            userPassword = password;
            userMail = mail;
        }

        public static void updateUser(User user, string name, string password, string mail)
        {
            user.UserName = name;
            user.UserPassword = password;
            user.UserMail = mail;
        }
    }
}
