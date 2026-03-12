using AddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AddressBook.ContactControl;

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

            optionsItem.DropDownItems.Add(sortByName);
            optionsItem.DropDownItems.Add(sortByEmail);
            contactsMenu.DropDownItems.Add(optionsItem);

            sortByName.Click += doSortByName;
            sortByEmail.Click += doSortByName;


            menuStrip.Items.Add(contactsMenu);

            addItem.Click += AddItem_Click;
            

        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("add contact was clicked");
            openNewWindow();

            Console.WriteLine("added contact ");
        }

        private void openNewWindow()
        {
            Form form2 = new Form2(flowLayoutPanel);
            form2.ShowDialog();
        }

        private void doSortByName(object sender, EventArgs e)
        {
            Console.WriteLine("Sorting by name");
            ContactControlWrapper.contacts.Sort(new ContactControlUsernameComparer());
            Console.WriteLine(ContactControlWrapper.toString());
        }
        private void doSortByEmail(object sender, EventArgs e)
        {
            Console.WriteLine("Sorting by email");
            ContactControlWrapper.contacts.Sort(new ContactControEmailComparer());
            Console.WriteLine(ContactControlWrapper.toString());
        }
    }
}
