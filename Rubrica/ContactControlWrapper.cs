using AddressBook;
using System;
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
