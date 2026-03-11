using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

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

            return label;
        }


    }
}
