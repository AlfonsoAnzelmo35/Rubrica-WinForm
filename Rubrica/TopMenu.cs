using AddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubrica
{
    public class TopMenu
    {
        private FlowLayoutPanel flowLayoutPanel;
        private MenuStrip menuStrip;
        public MenuStrip MenuStrip
        {
            get { return menuStrip; }
            set { menuStrip = value; }
        }

        ToolStripMenuItem contactsMenu { get; set; }
        ToolStripMenuItem addItem { get; set; }
        ToolStripMenuItem reomveItem { get; set; }
        ToolStripMenuItem optionsItem { get; set; }
        ToolStripMenuItem sortByName { get; set; }
        ToolStripMenuItem sortByEmail { get; set; }

        public TopMenu(FlowLayoutPanel flowLayoutPanel)
        {
            this.flowLayoutPanel = flowLayoutPanel;
            menuStrip = new MenuStrip();
            contactsMenu = new ToolStripMenuItem("Contacts");
            addItem = new ToolStripMenuItem("Add Contact");
            reomveItem = new ToolStripMenuItem("Remove Contact");

            contactsMenu.DropDownItems.Add(addItem);
            contactsMenu.DropDownItems.Add(reomveItem);


            optionsItem = new ToolStripMenuItem("Options");
            sortByName = new ToolStripMenuItem("Sort by Name");
            sortByEmail = new ToolStripMenuItem("Sort by Email");
            optionsItem.DropDownItems.Add("Sort by Name");
            optionsItem.DropDownItems.Add("Sort by Email");
            contactsMenu.DropDownItems.Add(optionsItem);
            

            menuStrip.Items.Add(contactsMenu);

            addEvents();
        }


        public void addEvents()
        {
            addItem.Click += AddItem_Click;
        
        
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("add contact was clicked");

            Contact contact = new Contact("", "", "", "", "");
            ContactControl contactControl = new ContactControl(flowLayoutPanel, contact);

            flowLayoutPanel.Controls.Add(contactControl);

            Console.WriteLine("added contact ");
        }
    }
}
