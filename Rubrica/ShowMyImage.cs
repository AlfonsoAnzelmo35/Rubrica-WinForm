using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace AddressBook
{
    public static class ShowMyImage
    {

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
            pictureBox1.Margin = new Padding(25);
            //MakePictureBoxCircular(pictureBox1);

            return pictureBox1;
        }

        private static void MakePictureBoxCircular(PictureBox pb)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, pb.Width - 1, pb.Height - 1);
            pb.Region = new Region(gp);
        }

        public static TextBox createTextBox() {
            TextBox textBox = new TextBox();

            textBox.Size = new Size(300, 200);
            textBox.Visible = true;
            textBox.Text = "This is a TextBox control.";

            return textBox;
        }


        

    }
}
