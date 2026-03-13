using Rubrica;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace AddressBook
{
    public class ContactControl: UserControl
    {
        private FlowLayoutPanel flowLayoutPanel;
        private PictureBox profilePic, removePic;
        private Label lblName, lblEmail, lblNumber;
    
        Panel lineTop { get; set; } 
        Panel lineLeft { get; set; }
        Panel lineRight { get; set; }
        Panel lineBottom { get; set; }

        public Panel LineRight
        {
            get { return lineRight; }
            set { lineRight = value; }
        }
        public Panel LineLeft
        {
            get { return lineLeft; }
            set { lineLeft = value; }
        }
        private bool showShadow = false;
        private Contact contact1;
        public Contact Contact1
        {
            get { return contact1;  }
            set { contact1 = value; }
        }
        private int contactControlHeight = 80;
        private int contactControlWidth = 200;

        public class ContactControlUsernameComparer : IComparer<ContactControl>
        {
            public int Compare(ContactControl x, ContactControl y)
            {
               return new Contact.UsernameComparer().Compare(x.Contact1, y.Contact1);
            }
        }

        public class ContactControEmailComparer : IComparer<ContactControl>
        {
            public int Compare(ContactControl x, ContactControl y)
            {
                return new Contact.EmailComparer().Compare(x.Contact1, y.Contact1);
            }
        }
        public int ContactControlHeight
        {
            get { return contactControlHeight; }
            set { contactControlHeight = value; }
        }
        public int ContactControlWidth
        {
            get { return contactControlWidth; }
            set { contactControlWidth = value; }
        }

        public ContactControl(FlowLayoutPanel flowLayoutPanel, Contact contact)
        {
            this.contact1 = contact;
            this.flowLayoutPanel = flowLayoutPanel;
            this.BorderStyle = BorderStyle.FixedSingle;
            
            this.Height = 100;
            this.Width = flowLayoutPanel.ClientSize.Width - this.Margin.Horizontal;
            this.MouseEnter += ContactControl_MouseEnter;
            this.MouseLeave += ContactControl_MouseLeave;

            foreach (Control c in this.Controls)
            {
                c.MouseDown += ContactControl_MouseDown;
            }
            this.MouseDown += ContactControl_MouseDown;

            EnableDrag(this);
            profilePic = addImage(profilePic, this.contact1.ProfilePic);
            profilePic.Click += selectProfilePic;

            Point point = new Point(profilePic.Right + 10, profilePic.Top);
            Font lblFont = new Font("Segoe UI", 10, FontStyle.Bold);
            int textX = profilePic.Right + 10;
            int textY = profilePic.Top;
            lblName = ShowMyImage.createLabel(contact1.user.Username, new Point(textX, textY), lblFont);
            Controls.Add(lblName);
            lblEmail = ShowMyImage.createLabel(contact1.user.Email, new Point(textX, textY + 22), lblFont);
            Controls.Add(lblEmail);
            lblNumber = ShowMyImage.createLabel(contact1.Number, new Point(textX + 120, textY), lblFont);
            Controls.Add(lblNumber);


            Panel[] panels = ShowMyImage.createBorders(this, new Color[] {Color.Yellow, Color.Black, Color.Red, Color.Blue}, new bool [] {false, false, true, false });
            lineTop     = panels[0];
            lineBottom  = panels[1];
            lineLeft    = panels[2];
            lineRight   = panels[3];


            removePic = addImage(removePic, Path.GetFullPath(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, @"..\..\images\cestino.png")));
            removePic.Dock = DockStyle.Right;
            removePic.Height = 50;removePic.Width= 50;
            removePic.Click += ((s, e) =>
            {
                Console.WriteLine("clicked remove button" + this.ToString());
                ContactControlWrapper.removeContactControl(this);
            });

        }

        private PictureBox addImage(PictureBox pic, string profilePic)
        {
            pic = ShowMyImage.ShowImage(profilePic);
            Controls.Add(pic);
            return pic;
        }
        private void ContactControl_MouseEnter(object sender, EventArgs e)
        {
            if (!Controls.Contains(lineTop))
            {
                Controls.Add(lineTop);
                Controls.Add(lineLeft);
                Controls.Add(lineRight);
                Controls.Add(lineBottom);

                lineTop.BringToFront(); // assicurati sia sopra a tutto
                lineLeft.BringToFront();
            }
            if(lineTop.Enabled) lineTop.Visible = true;
            if (lineLeft.Enabled) lineLeft.Visible = true;
            if (lineRight.Enabled) lineRight.Visible = true;
            if (lineBottom.Enabled) lineBottom.Visible = true;

        }
        private void ContactControl_MouseLeave(object sender, EventArgs e)
        {
            lineTop.Visible = false;
            lineLeft.Visible = false;
            lineRight.Visible = false;
            lineBottom.Visible = false;
        }

        private void ContactControl_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(this, DragDropEffects.Move);
        }        
        private void flowLayoutPanel1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void EnableDrag(Control parent)
        {
            parent.MouseDown += ContactControl_MouseDown;

            foreach (Control c in parent.Controls)
            {
                EnableDrag(c);
            }
        }
        public  void selectProfilePic(object sender, EventArgs e)
        {
            string path = String.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(ofd.FileName).ToLower();

                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp")
                {
                    this.contact1.ProfilePic = ofd.FileName;
                    Controls.Remove(profilePic);
                    addImage(profilePic, ofd.FileName);
                }
                else
                {
                    MessageBox.Show("Not supported file format.");
                }
            }

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }
        public void removeMySelf()
        {
            //fa rifermento al flowLayoutPanel
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ContactControl
            // 
            this.Name = "ContactControl";
            this.Load += new System.EventHandler(this.ContactControl_Load);
            this.ResumeLayout(false);

        }
        private void ContactControl_Load(object sender, EventArgs e)
        {

        }
        public string toString()
        {
            return this.contact1.toString();

        }
        
    }
}
