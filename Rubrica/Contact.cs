using System;
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
            this.user.username = username;
            this.user.email = email;
            this.user.password = password;

        }
        public Contact(string number, string username, string email, string password, string profilePicCustom)
        {
            this.user = new User(username, email, password);
            this.number = number;
            this.user.username = username;
            this.user.email = email;
            this.user.password = password;
            this.profilePicCustom = profilePicCustom;

        }

        public class User
        {
            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }


            public User(string username, string email, string password)
            {
                this.username = username;
                this.email = email;
                this.password = password;

            }

        }
        public String toString()
        {
            Console.WriteLine($"I am : {user.username} with {user.email}. My number is {this.number}");
           
            return "I am : {user.username} with {user.email}. My number is";
        }

    }
}
