using AddressBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AddressBook.ContactControl;
using static System.Windows.Forms.LinkLabel;

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


        ToolStripMenuItem FileMenu { get; set; }
        ToolStripMenuItem contactsMenu { get; set; }
        ToolStripMenuItem importContacts { get; set; }
        ToolStripMenuItem addItem { get; set; }
        ToolStripMenuItem optionsItem { get; set; }
        ToolStripMenuItem sortByName { get; set; }
        ToolStripMenuItem sortByEmail { get; set; }
        ToolStripMenuItem saveContacts { get; set; }


        public TopMenu(FlowLayoutPanel flowLayoutPanel)
        {
            this.flowLayoutPanel = flowLayoutPanel;
            menuStrip = new MenuStrip();

            //contactsMenu
            contactsMenu = new ToolStripMenuItem("Contacts");

            addItem = new ToolStripMenuItem("Add Contact");
            contactsMenu.DropDownItems.Add(addItem);

            optionsItem = new ToolStripMenuItem("Options");
            sortByName = new ToolStripMenuItem("Sort by Name");
            sortByEmail = new ToolStripMenuItem("Sort by Email");


            optionsItem.DropDownItems.Add(sortByName);
            optionsItem.DropDownItems.Add(sortByEmail);

            contactsMenu.DropDownItems.Add(optionsItem);

            addItem.Click += AddItem_Click;
            sortByName.Click += doSortByName;
            sortByEmail.Click += doSortByEmail;

            menuStrip.Items.Add(contactsMenu);

            //File Menu
            FileMenu = new ToolStripMenuItem("File");

            saveContacts = new ToolStripMenuItem("Save in File");
            importContacts = new ToolStripMenuItem("Import From File");
            FileMenu.DropDownItems.Add(saveContacts);
            FileMenu.DropDownItems.Add(importContacts);


            menuStrip.Items.Add(FileMenu);

            saveContacts.Click += saveContactsInFile;
            importContacts.Click += importContactsFromFile;

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

            updateUI();

        }
        private void doSortByEmail(object sender, EventArgs e)
        {
            Console.WriteLine("Sorting by email");
            ContactControlWrapper.contacts.Sort(new ContactControEmailComparer());

            updateUI();

        }
        private void updateUI()
        {
            flowLayoutPanel.Controls.Clear();

            int i;
            for (i = 0; i < ContactControlWrapper.contacts.Count; i++){
                flowLayoutPanel.Controls.Add(ContactControlWrapper.contacts[i]);
            }
            Console.WriteLine(ContactControlWrapper.toString());
        }
        private void saveContactsInFile(object sender, EventArgs e)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.GetFullPath(Path.Combine(basePath, @"..\..\contacts.json"));
            string contactControlWrapper_jsonString = String.Empty;

            List<User> users = new List<User>();
            foreach (ContactControl cc in ContactControlWrapper.contacts){

                User user = new User(cc.Contact1.user.Username, cc.Contact1.user.Email, cc.Contact1.user.Password);
                user.Number = cc.Contact1.Number;

                users.Add(user);
            }
            contactControlWrapper_jsonString = JsonSerializer.Serialize(users);

            File.WriteAllText(path, contactControlWrapper_jsonString);
            

        }
        private void importContactsFromFile(object sender, EventArgs e)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.GetFullPath(Path.Combine(basePath, @"..\..\contacts.json"));

            ContactControlWrapper.contacts.Clear();

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                List<User> users = JsonSerializer.Deserialize<List<User>>(json);

                foreach (User user in users)
                {

                    Contact contact = new Contact(user.Number, user.Username, user.Email, user.Password);

                    ContactControl cc = new ContactControl(flowLayoutPanel, contact);
                    ContactControlWrapper.addConcatControl(cc, flowLayoutPanel);
                }
            }
            updateUI();
        }
    }
}
