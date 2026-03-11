using AddressBook;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rubrica
{
    public partial class Form2: Form
    {
        private Font font;
        private TextBox NameTextBox, NumberTextBox, EmailTextBox;
        private Label NameLabel, NumebrLabel, EmailLabel ;
        private FlowLayoutPanel flowLayoutPanel11, flowLayoutPanel12, flowLayoutPanel13;
        private FlowLayoutPanel flowLayoutPanel;
        public Form2(FlowLayoutPanel flowLayoutPanel)
        {
            font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Width = 450;this.Height = 350;
            Console.WriteLine("width height internal dialog box : " + this.Width + " " + this.Height);
            this.flowLayoutPanel = flowLayoutPanel;

            FlowLayoutPanel flowLayoutPanel11 = new FlowLayoutPanel();
            flowLayoutPanel11.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel11.Dock = DockStyle.Fill;
            flowLayoutPanel11.WrapContents = false;


            FlowLayoutPanel flowLayoutPanel12 = new FlowLayoutPanel();
            flowLayoutPanel12.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel12.WrapContents = false;
            flowLayoutPanel12.Dock = DockStyle.Fill;
            flowLayoutPanel12.BackColor = Color.White;
            flowLayoutPanel12.AutoSize = true;

            FlowLayoutPanel flowLayoutPanel13 = new FlowLayoutPanel();
            flowLayoutPanel13.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel13.WrapContents = false;
            flowLayoutPanel13.AutoSize = true;
            flowLayoutPanel13.BackColor = Color.AliceBlue;
            flowLayoutPanel13.Height = flowLayoutPanel11.Height;

            flowLayoutPanel11.Controls.Add(flowLayoutPanel12);
            flowLayoutPanel11.Controls.Add(flowLayoutPanel13);
            this.Controls.Add(flowLayoutPanel11);

            // Resize so they always occupy half
            flowLayoutPanel11.Resize += (s, e) =>
            {
                int halfWidth = flowLayoutPanel11.ClientSize.Width / 2;
                flowLayoutPanel12.Width = halfWidth;
                flowLayoutPanel13.Width = halfWidth;

                flowLayoutPanel12.Height = flowLayoutPanel11.ClientSize.Height;
                flowLayoutPanel13.Height = flowLayoutPanel11.ClientSize.Height;
            };

            NameTextBox = ShowMyImage.createTextBox("inserisci il nome", font);
            NumberTextBox = ShowMyImage.createTextBox("inserisci il numero", font);
            EmailTextBox = ShowMyImage.createTextBox("inserisci email", font);

            flowLayoutPanel13.Controls.Add(NameTextBox);
            flowLayoutPanel13.Controls.Add(NumberTextBox);
            flowLayoutPanel13.Controls.Add(EmailTextBox);

            Point point = new Point(50, 50);
            NameLabel = ShowMyImage.createLabel("Name", point , font);
            NumebrLabel = ShowMyImage.createLabel("Number",new Point(point.X, point.Y +30) , font);
            EmailLabel = ShowMyImage.createLabel("Email", new Point(point.X, point.Y + 60) , font); ;

            flowLayoutPanel12.Controls.Add(NameLabel);
            flowLayoutPanel12.Controls.Add(NumebrLabel);
            flowLayoutPanel12.Controls.Add(EmailLabel);


            Button buttonSubmit = ShowMyImage.createButton("inserisci contatto ", new Point((int) flowLayoutPanel12.Width / 4, flowLayoutPanel12.Height -20), font);
            flowLayoutPanel13.Controls.Add(buttonSubmit);

            buttonSubmit.Click += (s, e) => buttonSubmit_Click(s, e, NameTextBox, NumberTextBox, EmailTextBox);

        }
        private void buttonSubmit_Click(object sender, EventArgs e, TextBox NameTextBox, TextBox NumberTextBox, TextBox EmailTextBox)
        {
            // Validazione dei campi obbligatori
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Inserisci il nome!");
                NameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(NumberTextBox.Text))
            {
                MessageBox.Show("Inserisci l'email!");
                EmailTextBox.Focus();
                return;
            }

            // Logica di submit: ad esempio salva i dati o invia a un database
            MessageBox.Show($"Dati inviati:\nNome: {NameTextBox.Text}\nEmail: {EmailTextBox.Text}");
            ContactControl contactControl = new ContactControl(flowLayoutPanel, new Contact(NumberTextBox.Text, NameTextBox.Text, EmailTextBox.Text, "pino")) ;

            ContactControlWrapper.addConcatControl(contactControl, flowLayoutPanel);
            
            
            // Eventualmente chiudi la form
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
