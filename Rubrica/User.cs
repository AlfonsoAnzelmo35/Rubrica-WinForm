using AddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class User : Contact
    {
        private string username { get; set; }
        private string email { get; set; }
        private string password { get; set; }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public User(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }

    }

}
