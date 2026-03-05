using System;
using System.Windows.Forms;

namespace AddressBook
{
    public class Contact 
    {
        private int contactImagelength = 20, contactImageWidth = 20;
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
        
        
        private string profilePic;   
        public string ProfilePic     
        {
            get { return profilePic; }
            set { profilePic = value; }
        }

        private PictureBox pictureBox1 { get; set; }
        


        public Contact(string number, string profilePic, string username, string email, string password)
        {
            this.user = new User(username, email, password);
            this.number = number;
            if(profilePic.Length == 0)this.profilePic = "C:\\Users\\AnzelmoA\\Desktop\\ALFONSO\\User_icon_2.svg.png";
            else this.profilePic = profilePic;


            this.user.username = username;
            this.user.email = email;
            this.user.password = password;

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
