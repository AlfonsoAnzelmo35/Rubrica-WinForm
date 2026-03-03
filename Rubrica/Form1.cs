using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        private List<Contact> contacts;
        private FlowLayoutPanel flowLayoutPanel;
        public Form1()
        {
            InitializeComponent();

            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Top;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Name = "FlowLayoutPanel1";
            flowLayoutPanel.AutoSize = true; 
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            flowLayoutPanel.TabIndex = 0;
            flowLayoutPanel.WrapContents = false;                   //necessary, otherwise Windows tries to wrap into a new column
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.AliceBlue;

            //Once the FlowLayoutPanel control is ready with its properties, the next step is to add the FlowLayoutPanel to a Form
            this.Controls.Add(flowLayoutPanel);



            Contact contact1 = new Contact("11111113333333", "", "Alfonso", "anz@45.it", "pass");
            ContactControl contactControl1 = new ContactControl(contact1);

            Contact contact2 = new Contact("2222222", "", "Fabio", "anz@45.it", "pass");
            ContactControl contactControl2 = new ContactControl(contact2);

            Contact contact3 = new Contact("3333333", "", "Aniello", "anz@45.it", "pass");
            ContactControl contactControl3 = new ContactControl(contact3);

            Contact contact4 = new Contact("44444444", "", "Silvia", "anz@45.it", "pass");
            ContactControl contactControl4 = new ContactControl(contact4);

            flowLayoutPanel.Controls.Add(contactControl1);
            flowLayoutPanel.Controls.Add(contactControl2);
            flowLayoutPanel.Controls.Add(contactControl3);
            flowLayoutPanel.Controls.Add(contactControl4);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
