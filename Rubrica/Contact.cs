using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AddressBook
{
    public class Contact 
    {
        private int contactImagelength = 20, contactImageWidth = 20;

        private static string basePath = AppDomain.CurrentDomain.BaseDirectory;
        public string profilePic = Path.GetFullPath(Path.Combine(basePath, @"..\..\images\User_icon_2.svg.png"));

        public string ProfilePic
        {
            get { return profilePic; }
            set { profilePic = value; }
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
        public Contact() { }
       
        public Contact(string number, string username, string email, string password, string birthDay)
        {
            this.user = new User(username, email, password, birthDay);
            this.number = number;
            this.user.Username = username;
            this.user.Email = email;
            this.user.Password = password;
        }
        public Contact(string number,  string username, string email, string password)
        {
            this.user = new User(username, email, password);
            this.number = number;
            this.user.Username = username;
            this.user.Email = email;
            this.user.Password = password;

        }
        public Contact(Contact contact)
        {
            this.number = number;
            this.user = new User(contact.user.Username, contact.user.Email, contact.user.Password);

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
           
            return $"I am : {user.Username} with {user.Email}. My number is {this.Number}";
        }

      
    }
}
