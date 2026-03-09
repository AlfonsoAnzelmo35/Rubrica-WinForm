using Rubrica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        private List<Contact> contacts;
        private FlowLayoutPanel flowLayoutPanel;
        private ContactControlWrapper contactControlWrapper;


        public Form1()
        {
            InitializeComponent();
            this.AutoScroll = true;

            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Name = "FlowLayoutPanel1";
            flowLayoutPanel.AutoSize = false;
            flowLayoutPanel.Dock = DockStyle.Fill;   // not Top
            flowLayoutPanel.AllowDrop = true;
            flowLayoutPanel.DragOver += flowLayoutPanel_DragOver;
            flowLayoutPanel.DragDrop += flowLayoutPanel_DragDrop;


            this.Size = new Size(400, 400);
            this.MinimumSize = new Size(400, 400);
            flowLayoutPanel.TabIndex = 0;
            flowLayoutPanel.WrapContents = false;                  
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.AliceBlue;
            
            flowLayoutPanel.Resize += (s, e) =>
            {
                foreach (Control c in flowLayoutPanel.Controls)
                {
                    if(typeof(ContactControl).IsInstanceOfType(c)){
                        ContactControl c1 = (ContactControl)c;
                        c1.LineRight.Location = new Point(c1.Width - 3, 0);
                        c1.LineRight.Height = Height;
                        c1.Width = flowLayoutPanel.ClientSize.Width - c1.Margin.Horizontal;
                    }
                }
            };

            //Once the FlowLayoutPanel control is ready with its properties, the next step is to add the FlowLayoutPanel to a Form
            this.Controls.Add(flowLayoutPanel);
            contactControlWrapper = new ContactControlWrapper();

            Contact contact1 = new Contact("11111113333333", "", "Alfonso", "anz@45.it", "pass");
            ContactControl contactControl1 = new ContactControl(flowLayoutPanel, contact1, contactControlWrapper);

            Contact contact2 = new Contact("2222222", "", "Fabio", "anz@45.it", "pass");
            ContactControl contactControl2 = new ContactControl(flowLayoutPanel, contact2, contactControlWrapper);

            Contact contact3 = new Contact("3333333", "", "Aniello", "anz@45.it", "pass");
            ContactControl contactControl3 = new ContactControl(flowLayoutPanel, contact3, contactControlWrapper);

            contactControlWrapper.addConcatControl(contactControl1, flowLayoutPanel);
            contactControlWrapper.addConcatControl(contactControl2, flowLayoutPanel);
            contactControlWrapper.addConcatControl(contactControl3, flowLayoutPanel);

            addToptMenu();
           
        }
        private void addToptMenu()
        {
            TopMenu topMenu = new TopMenu(flowLayoutPanel);
            
            // Add menuStrip to form
            this.MainMenuStrip = topMenu.MenuStrip;
            this.Controls.Add(topMenu.MenuStrip);
        }

        private void flowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            ContactControl dragged = e.Data.GetData(typeof(ContactControl)) as ContactControl;
            if (dragged == null) return;

            Point p = flowLayoutPanel.PointToClient(new Point(e.X, e.Y));
            Control target = flowLayoutPanel.GetChildAtPoint(p);

            if (target == null || target == dragged) return;

            int index = flowLayoutPanel.Controls.GetChildIndex(target);
            flowLayoutPanel.Controls.SetChildIndex(dragged, index);
        }

        private void flowLayoutPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
