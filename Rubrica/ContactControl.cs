using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AddressBook
{
    public class ContactControl: UserControl
    {

        private TextBox textBox;
        private PictureBox pic;

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

        public ContactControl(Contact contact)
        {   
            this.contact1 = contact;

            this.BackColor = Color.LightCoral;
            this.Margin = new Padding(25);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            createControls();
            CenterContent();

        }

        public ContactControl()
        {
            this.contact1 = new Contact("3333333", "", "Alfonso", "anz@45.it", "pass");
            

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            createControls();
            CenterContent();
        }

        private void createControls()
        {
            //crea immagine del contatto
            pic = ShowMyImage.ShowImage(contact1.ProfilePic);
            
            //crea fieldtext
            textBox = ShowMyImage.createTextBox();
            Controls.Add(pic);
            Controls.Add(textBox);
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
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Console.WriteLine("called onPaint");
             
        }

    }
}
