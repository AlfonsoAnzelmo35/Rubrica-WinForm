using Rubrica;
using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

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
            createLabels();
            createBorders();

            removePic = addImage(removePic, Path.GetFullPath(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, @"..\..\images\cestino.png")));
            removePic.Dock = DockStyle.Right;
            removePic.Height = 50;removePic.Width= 50;
            removePic.Click += ((s, e) =>
            {
                Console.WriteLine("clicked remvove button" + this.ToString());
                this.contactControlWrapper.removeContactControl(this);
            });


        }

        private void createBorders()
        {
            // Linea in alto
            lineTop = new Panel();
            lineTop.Height = 2;
            lineTop.Dock = DockStyle.Top;
            lineTop.BackColor = Color.Yellow;
            lineTop.BringToFront();

            // Linea in basso
            lineBottom = new Panel();
            lineBottom.Height = 2;
            lineBottom.Dock = DockStyle.Bottom;
            lineBottom.BackColor = Color.Black;
            lineBottom.BringToFront();

            // Linea a sinistra
            lineLeft = new Panel();
            lineLeft.Width = 2;
            lineLeft.Height = this.Height - lineTop.Height - lineBottom.Height;
            lineLeft.Location = new Point(0, lineTop.Height);
            lineLeft.BackColor = Color.Red;
            lineLeft.BringToFront();

            // Linea a destra
            lineRight = new Panel();
            lineRight.Width = 2;
            lineRight.Height = this.Height - lineTop.Height - lineBottom.Height;
            lineRight.Location = new Point(this.Width - 10, lineTop.Height);
            lineRight.BackColor = Color.Blue;
            lineRight.BringToFront();

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

        public void createLabels()
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
            lineTop.Visible = true;
            lineLeft.Visible = true;
            lineRight.Visible = true;
            lineBottom.Visible = true;

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
