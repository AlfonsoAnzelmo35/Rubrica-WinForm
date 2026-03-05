using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace AddressBook
{
    public class ContactControl: UserControl
    {
        private FlowLayoutPanel flowLayoutPanel;
        private TextBox textBox;
        private PictureBox pic;
        private Label lblName, lblEmail, lblNumber;
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

        public ContactControl(FlowLayoutPanel flowLayoutPanel, Contact contact )
        {
            this.contact1 = contact;
            this.flowLayoutPanel = flowLayoutPanel;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(25);
            this.Height = 100;
            this.Width = flowLayoutPanel.ClientSize.Width - this.Margin.Horizontal;
            this.MouseEnter += ContactControl_MouseEnter;
            this.MouseLeave += ContactControl_MouseLeave;


            foreach (Control c in this.Controls)
            {
                c.MouseDown += ContactControl_MouseDown;
            }
            this.MouseDown += ContactControl_MouseDown;

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
            lineRight.Location = new Point(this.Width -20, lineTop.Height);
            lineRight.BackColor = Color.Blue;
            lineRight.BringToFront();

            createControls();
            createLabels();
        }
        

        private void createControls()
        {
            pic = ShowMyImage.ShowImage(contact1.ProfilePic);
            Controls.Add(pic);

            //textBox = ShowMyImage.createTextBox();
            //Controls.Add(textBox);

            //ShowMyImage.createBackControl() //for shadows

        }
        //public void createBackControl() { 
        //    ContactControl contactControl = new ContactControl();
        //    
        //}

        public void createLabels()
        {
            int textX = pic.Right + 10;
            int textY = pic.Top;

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
        private void CenterContent()
        {
            int contentWidth = pic.Width + 10 + textBox.Width;
            int contentHeight = Math.Max(pic.Height, textBox.Height);

            int startX = (this.Width ) / 2;
            int startY = (this.Height ) / 2;

            Console.WriteLine("" + contentWidth + " " + contentHeight);
            Console.WriteLine("" + startX + " " + startY);

            //textBox.Location = new Point(startX + pic.Width + 10, startY + (pic.Height - textBox.Height) / 2);
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


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
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
