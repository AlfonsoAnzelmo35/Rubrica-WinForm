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
            flowLayoutPanel.DragDrop += flowLayoutPanel_DragDrop;
            flowLayoutPanel.DragOver += flowLayoutPanel_DragOver;



            this.Size = new Size(400, 400);
            this.MinimumSize = new Size(400, 400);
            flowLayoutPanel.TabIndex = 0;
            flowLayoutPanel.WrapContents = false;                   //necessary, otherwise Windows tries to wrap into a new column
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

            Contact contact1 = new Contact("11111113333333", "", "Alfonso", "anz@45.it", "pass");
            ContactControl contactControl1 = new ContactControl(flowLayoutPanel, contact1);

            Contact contact2 = new Contact("2222222", "", "Fabio", "anz@45.it", "pass");
            ContactControl contactControl2 = new ContactControl(flowLayoutPanel, contact2);

            Contact contact3 = new Contact("3333333", "", "Aniello", "anz@45.it", "pass");
            ContactControl contactControl3 = new ContactControl(flowLayoutPanel, contact3);

            flowLayoutPanel.Controls.Add(contactControl1);
            flowLayoutPanel.Controls.Add(contactControl2);
            flowLayoutPanel.Controls.Add(contactControl3);

            //contactControl1.Width = flowLayoutPanel.ClientSize.Width - this.Margin.Horizontal;
            //contactControl2.Width = flowLayoutPanel.ClientSize.Width - this.Margin.Horizontal;
            //contactControl3.Width = flowLayoutPanel.ClientSize.Width - this.Margin.Horizontal;




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
            Control dragged = (Control)e.Data.GetData(typeof(Control));
            if (dragged == null) return;

            Point mousePos = flowLayoutPanel.PointToClient(new Point(e.X, e.Y));

            // Calcolo il nuovo indice basato sulla posizione verticale del mouse
            int newIndex = 0;
            for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
            {
                Control c = flowLayoutPanel.Controls[i];
                if (c == dragged) continue; // salto il controllo trascinato
                if (mousePos.Y > c.Top + c.Height / 2)
                    newIndex = i + 1;
            }

            // Se l’indice non cambia, non faccio nulla
            int oldIndex = flowLayoutPanel.Controls.GetChildIndex(dragged);
            if (oldIndex == newIndex) return;

            // Sposto il controllo nella nuova posizione
            flowLayoutPanel.SuspendLayout();
            flowLayoutPanel.Controls.SetChildIndex(dragged, newIndex);
            flowLayoutPanel.ResumeLayout();
        }
        private void flowLayoutPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void addConcat(string number, string filePic, string name, string email, string password) {
            Contact contact = new Contact(number, filePic, name, email, password);
            ContactControl contactControl = new ContactControl(flowLayoutPanel, contact);

            flowLayoutPanel.Controls.Add(contactControl);
            //contactControl.Width = flowLayoutPanel.ClientSize.Width - this.Margin.Horizontal;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
