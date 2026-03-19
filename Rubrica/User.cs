using System;
using System.Globalization;
using System.Windows.Forms;

namespace AddressBook
{
    public class User : Contact
    {
        private string username { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private DateTime birthDay { get; set; }
        public DateTime BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        public  User() { }


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
        public User(string username, string email, string password, string birthDay)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.birthDay = User.StringToDatetime(birthDay, new CultureInfo("it-IT"));
        }



        public static DateTime StringToDatetime(string birthday, CultureInfo culture)
        {
            //new CultureInfo("de-DE")
            return DateTime.ParseExact(birthday, "dd/MM/yyyy", culture);
        }
    }

}
