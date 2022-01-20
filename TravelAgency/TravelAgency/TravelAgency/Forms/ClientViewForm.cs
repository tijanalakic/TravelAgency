using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.Forms
{
    public partial class ClientViewForm : Form
    {
        List<Control> buttons;
        List<Control> textboxes;
        List<Control> labels;
        public ClientViewForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            FillUpUserData();

        }

        private void FillUpUserData()
        {
            string pid = MainForm.pidOfSelectedCellClients;
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var client = (from u in ctx.clients where u.person.pid == pid select u).First();

                labelFirstName.Text = client.person.firstName;
                labelLastName.Text = client.person.lastName;
                labelAddress.Text = client.person.address;
                labelPid.Text = client.person.pid;
                labelPassport.Text = client.passport;
                labelPhone.Text = client.person.phone;
                labelMail.Text = client.person.email;
                labelCity.Text = client.person.city.name;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Initialize_Add()
        {

            buttons = new List<Control>();
            labels = new List<Control>();


            buttons.Add(buttonClose);

            labels.Add(labelAddress);
            labels.Add(labelFirstName);
            labels.Add(labelLastName);
            labels.Add(labelPassport);
            labels.Add(labelCity);
            labels.Add(labelMail);
            labels.Add(labelPhone);
            labels.Add(labelPid);
          



        }

        void ApplyTheme(Color back, Color btn, Color tbox, Color combo, Color textColor)
        {
            this.BackColor = back;



            foreach (Control item in buttons)
            {
                item.BackColor = btn;
                item.ForeColor = textColor;
            }
            foreach (Control item in labels)
            {

                item.BackColor = tbox;
                item.ForeColor = btn;

            }
        }

        private void ClientViewForm_Load(object sender, EventArgs e)
        {
            Initialize_Add();
            if (Properties.Settings.Default.Theme == "PaleVioletRed")
            {
                ApplyTheme(Color.FromArgb(205, 94, 119), Color.FromArgb(100, 12, 60), Color.FromArgb(205, 94, 119), Color.FromArgb(205, 94, 119), Color.Azure);


            }
            else if (Properties.Settings.Default.Theme == "MidnightBlue")
            {
                ApplyTheme(Color.MidnightBlue, Color.RoyalBlue, Color.MidnightBlue, Color.MidnightBlue, SystemColors.InactiveCaption);


            }
            else
            {
                ApplyTheme(Color.RoyalBlue, Color.MidnightBlue, Color.RoyalBlue, Color.RoyalBlue, SystemColors.InactiveCaption);
            }

            if (Properties.Settings.Default.Language == "English")
            {
                ChangeLanguage("en");
            }
            else
            {
                ChangeLanguage("");

            }
            FillUpUserData();
        }
        private void ChangeLanguage(string lang)
        {

            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(ClientViewForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}
