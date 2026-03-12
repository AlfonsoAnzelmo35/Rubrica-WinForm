using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AddressBook
{
    public class Contact 
    {
        private int contactImagelength = 20, contactImageWidth = 20;

        private static string basePath = AppDomain.CurrentDomain.BaseDirectory;
        public static string profilePic = Path.GetFullPath(Path.Combine(basePath, @"..\..\images\User_icon_2.svg.png"));
        private string profilePicCustom; 

        public string ProfilePicCustom
        {
            get { return profilePicCustom; }
            set { profilePicCustom = value; }
        }
        public int ContactImagelength
        {
            get { return contactImagelength; }
            set { contactImagelength = value; }
        }
        public int ContactImageWidth
        {
            get { return contactImageWidth; }
            set { contactImageWidth = value; }
        }
        private String number { get; set; }
        public String Number
        {
            get { return number; }
            set { number = value; }
        }

        public User user;

        private PictureBox pictureBox1 { get; set; }
        
        public Contact(string number,  string username, string email, string password)
        {
            this.user = new User(username, email, password);
            this.number = number;
            this.user.Username = username;
            this.user.Email = email;
            this.user.Password = password;

        }
        public Contact(string number, string username, string email, string password, string profilePicCustom)
        {
            this.user = new User(username, email, password);
            this.number = number;
            this.user.Username = username;
            this.user.Email = email;
            this.user.Password = password;
            this.profilePicCustom = profilePicCustom;

        }

        public class User
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


        public class UsernameComparer : IComparer<Contact>
        {
            public int Compare(Contact x, Contact y)
            {
                return string.Compare(x.user.Username, y.user.Username);
            }
        }

        public class EmailComparer : IComparer<Contact>
        {
            public int Compare(Contact x, Contact y)
            {
                return string.Compare(x.user.Email, y.user.Email);
            }
        }


        public String toString()
        {
            Console.WriteLine($"I am : {user.Username} with {user.Email}. My number is {this.Number}");
           
            return "I am : {user.username} with {user.email}. My number is";
        }

      
    }
}
