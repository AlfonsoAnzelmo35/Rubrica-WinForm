using System;
using System.Drawing;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;

namespace AddressBook
{
    public static class ShowMyImage
    {
        private static string textBoxString;
        private static int contactControlImageHeight = 40;
        private static int contactControlImageWidth = 40;
        public static int ContactControlImageHeight
        {
            get { return contactControlImageHeight; }
            set { contactControlImageHeight = value; }
        }
        public static int ContactControlImageWidth
        {
            get { return contactControlImageWidth; }
            set { contactControlImageWidth = value; }
        }

        public static PictureBox ShowImage(String fileToDisplay)
        {
            Bitmap  myImage = new Bitmap(fileToDisplay);
            PictureBox pictureBox1 = new PictureBox();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Size = new Size(contactControlImageWidth, contactControlImageHeight);
            pictureBox1.Image = (System.Drawing.Image)myImage;
            pictureBox1.Visible = true;

            Console.WriteLine("" + pictureBox1.Location.X, pictureBox1.Location.Y);
            pictureBox1.Location = new Point(pictureBox1.Location.X +25 , pictureBox1.Location.Y+25);
            pictureBox1.Cursor = Cursors.Hand;

            
            return pictureBox1;
        }

        

        public static TextBox createTextBox(string text, Font font, int width = 300, int heigt = 200) {
            TextBox textBox = new TextBox();

            textBox.Font = font;
            textBox.Size = new Size(width, 200);
            textBox.Visible = true;
            textBox.Text = text;

            //modo per passare i parametri ad un evento
            textBox.Enter += textBox1_Enter;
            //textBox.Enter += (s, e) => textBox1_Enter(s, e);
            
            //modo per passare i parametri ad un evento
            //textBox.Leave += textBox1_Leave;
            textBox.Leave += (s, e) => textBox1_Leave(s, e, text);

            return textBox;
        }
        public static void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox) sender;

            if (textBox.Text.Length > 0)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }
        public static void textBox1_Leave(object sender, EventArgs e, string text)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = text;
                textBox.ForeColor = Color.Gray;
            }
        }
        public static Label createLabel(string text, Point point, Font font, bool autosize = true)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = font;
            if(font == null)
                font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.AutoSize = autosize;
            label.Location = point;
            label.Cursor = Cursors.Hand;



            return label;
        }
        public static Button createButton(string text, Point point, Font font, bool autosize = true)
        {
            System.Windows.Forms.Button button = new Button();
            button.Text = text;
            button.Font = font;

            if (font == null)
                font = new Font("Segoe UI", 10, FontStyle.Bold);

            button.AutoSize = autosize;
            button.Location = point;

            return button;
        }
        public static Panel[] createBorders(ContactControl cc, Color[] colors, bool[] borderPresent, int height = 2, int width = 2)
        {
            Panel[] panels = new Panel[4];

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
            lineLeft.Height = cc.Height - lineTop.Height - lineBottom.Height;
            lineLeft.Location = new Point(0, lineTop.Height);
            lineLeft.BackColor = Color.Red;
            lineLeft.BringToFront();
            panels[2] = lineLeft;

            // Linea a destra
            Panel lineRight = new Panel();
            lineRight.Width = width;
            lineRight.Height = cc.Height - lineTop.Height - lineBottom.Height;
            lineRight.Location = new Point(cc.Width - 10, lineTop.Height);
            lineRight.BackColor = Color.Blue;
            lineRight.BringToFront();

            panels[3] = lineRight;

            int i;
            for (i = 0; i < borderPresent.Length; i++)
                if (!borderPresent[i])
                {
                    panels[i].Enabled = false;
                    panels[i].Visible = false;
                }
                else
                {
                    panels[i].Visible = true;
                    panels[i].Enabled = true;

                }
            return panels;
        }
    }
}
