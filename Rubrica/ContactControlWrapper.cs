using AddressBook;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Rubrica
{
    public static class ContactControlWrapper
    {
        public static List<ContactControl> contacts { get; set; } = new List<ContactControl>();

        
        public static void addConcatControl(ContactControl contactControl, FlowLayoutPanel flowLayoutPanel)
        {
            contacts.Add(contactControl);

            flowLayoutPanel.Controls.Add(contactControl);
        }
        public static void addConcatControl(string number, string filePic, string name, string email, string password, FlowLayoutPanel flowLayoutPanel)
        {
            Contact contact = new Contact(number, filePic, name, email, password);
            ContactControl contactControl = new ContactControl(flowLayoutPanel, contact);
            contacts.Add(contactControl);

            flowLayoutPanel.Controls.Add(contactControl);
            //contactControl.Width = flowLayoutPanel.ClientSize.Width - this.Margin.Horizontal;



        }

        public static void removeContactControl(ContactControl contactControl)
        {
            contactControl.removeMySelf();
            contacts.Remove(contactControl);
        }
        public static string toString()
        {
            string p = string.Empty;
            foreach (ContactControl cc in contacts)
                p += cc.toString()+ "\n";
            return p;
        }
        public static void doSortByName()
        {
            
        }

    }
}
