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
        private TextBox textBox;
        private PictureBox profilePic, removePic;
        private Label lblName, lblEmail, lblNumber;
        private string removeContactImage = "";
        private ContactControlWrapper contactControlWrapper;
        private bool[] visibleborder;

        Panel lineTop { get; set; } 
        Panel lineLeft { get; set; }
        Panel lineRight { get; set; }
        public 
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
        private int contactControlHeight = 80;
        private int contactControlWidth = 200;
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

        public ContactControl(FlowLayoutPanel flowLayoutPanel, Contact contact, ContactControlWrapper contactControlWrapper)
        {
            this.contact1 = contact;
            this.contactControlWrapper = contactControlWrapper;
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
            profilePic = addImage(profilePic, contact1.ProfilePic);
     

            Point point = new Point(profilePic.Right + 10, profilePic.Top);
            Font lblFont = new Font("Segoe UI", 10, FontStyle.Bold);
            int textX = profilePic.Right + 10;
            int textY = profilePic.Top;
            lblName = ShowMyImage.createLabel(contact1.user.username, new Point(textX, textY), lblFont);
            Controls.Add(lblName);
            lblEmail = ShowMyImage.createLabel(contact1.user.email, new Point(textX, textY + 22), lblFont);
            Controls.Add(lblEmail);
            lblNumber = ShowMyImage.createLabel(contact1.Number, new Point(textX + 120, textY), lblFont);
            Controls.Add(lblNumber);


            Panel[] panels = createBorders(new Color[] {Color.Yellow, Color.Black, Color.Red, Color.Blue}, new bool [] {false, false, true, false });
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
                this.contactControlWrapper.removeContactControl(this);
            });

        }

        private Panel[] createBorders(Color[] colors, bool[] borderPresent, int height = 2, int width = 2)
        {
            Panel[] panels = new Panel[4];
            visibleborder = new bool[4]{true, true, true, true};

            // Linea in alto
            Panel lineTop = new Panel();
                lineTop.Height = height;
                lineTop.Dock = DockStyle.Top;
                lineTop.BackColor = Color.Yellow;
                lineTop.BringToFront();
                panels[0] = lineTop;

            // Linea in basso
            Panel lineBottom = new Panel();
                lineBottom.Height = height;
                lineBottom.Dock = DockStyle.Bottom;
                lineBottom.BackColor = Color.Black;
                lineBottom.BringToFront();
                panels[1] = lineBottom;

            // Linea a sinistra
            Panel lineLeft = new Panel();
                lineLeft.Width = width;
                lineLeft.Height = this.Height - lineTop.Height - lineBottom.Height;
                lineLeft.Location = new Point(0, lineTop.Height);
                lineLeft.BackColor = Color.Red;
                lineLeft.BringToFront();
                panels[2] = lineLeft;

            // Linea a destra
            Panel lineRight = new Panel();
                lineRight.Width = width;
                lineRight.Height = this.Height - lineTop.Height - lineBottom.Height;
                lineRight.Location = new Point(this.Width - 10, lineTop.Height);
                lineRight.BackColor = Color.Blue;
                lineRight.BringToFront();
                
                panels[3] = lineRight;

            int i;
            for (i = 0; i < borderPresent.Length; i++)
                if (!borderPresent[i]) {
                    panels[i].Enabled = false;
                    panels[i].Visible = false;
                } else{
                    panels[i].Visible = true;
                    panels[i].Enabled = true;

                }
            return panels;
        }

        private PictureBox addImage(PictureBox pic, string profilePic)
        {
            pic = ShowMyImage.ShowImage(profilePic);
            Controls.Add(pic);
            return pic;
        }
        private void removeImage(PictureBox pic)
        {  
            Controls.Remove(pic);
        }
        private void removeLabel(Label label)
        {
            Controls.Remove(label);    
        }
        private void removeBorder(Panel line)
        {
            Controls.Remove(line);
        }

        
        /*public void createLabels()
        {
            int textX = profilePic.Right + 10;
            int textY = profilePic.Top;

            lblName = new Label();
            lblName.Text = contact1.user.username;
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblName.AutoSize = true;
            lblName.Location = new Point(textX, textY);
            Controls.Add(lblName);


            lblEmail = new Label();
            lblEmail.Text = contact1.user.email;
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(textX, textY + 22);
            Controls.Add(lblEmail);


             lblNumber = new Label();
            lblNumber.Text = contact1.Number;
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(textX + 120, textY);
            Controls.Add(lblNumber);
        }*/
        
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
    }
}
