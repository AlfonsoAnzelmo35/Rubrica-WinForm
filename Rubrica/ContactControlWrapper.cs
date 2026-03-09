using AddressBook;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rubrica
{
    public class ContactControlWrapper
    {
        private List<ContactControl> contacts;
        public List<ContactControl> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }


        public ContactControlWrapper()
        {
            contacts = new List<ContactControl>();
        }
        public void addConcatControl(ContactControl contactControl, FlowLayoutPanel flowLayoutPanel)
        {
            contacts.Add(contactControl);

            flowLayoutPanel.Controls.Add(contactControl);
            //contactControl.Width = flowLayoutPanel.ClientSize.Width - this.Margin.Horizontal;
        }
        public void addConcatControl(string number, string filePic, string name, string email, string password, FlowLayoutPanel flowLayoutPanel)
        {
            Contact contact = new Contact(number, filePic, name, email, password);
            ContactControl contactControl = new ContactControl(flowLayoutPanel, contact, this);
            contacts.Add(contactControl);

            flowLayoutPanel.Controls.Add(contactControl);
            //contactControl.Width = flowLayoutPanel.ClientSize.Width - this.Margin.Horizontal;

        }

        public void removeContactControl(ContactControl contactControl)
        {
            contactControl.removeMySelf();
            contacts.Remove(contactControl);
            
        }

    }
}
