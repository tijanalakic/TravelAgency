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
    public partial class UserViewForm : Form
    {
        List<Control> buttons;
        List<Control> labels;
        public UserViewForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            FillUpUserData();

        }

        private void FillUpUserData()
        {
            string pid = MainForm.pidOfSelectedCellUsers;
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var user = (from u in ctx.users where u.person.pid == pid select u).First();

                labelFirstName.Text = user.person.firstName;
                labelLastName.Text = user.person.lastName;
                labelAddress.Text = user.person.address;
                labelPid.Text = user.person.pid;
                labelUsername.Text = user.username;
                labelPhone.Text = user.person.phone;
                labelMail.Text = user.person.email;
                labelCity.Text=user.person.city.name;
                labelAccountType.Text = user.role.name;
            }
        }

        void Initialize_Add()
        {

            buttons = new List<Control>();
            labels = new List<Control>();


            buttons.Add(buttonClose);
 
            labels.Add(labelAddress);
            labels.Add(labelFirstName);
            labels.Add(labelLastName);
            labels.Add(labelUsername);
            labels.Add(labelCity);
            labels.Add(labelMail);
            labels.Add(labelPhone);
            labels.Add(labelPid);
            labels.Add(labelAccountType);



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

        private void UserViewForm_Load(object sender, EventArgs e)
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeLanguage(string lang)
        {

            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(UserViewForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}
