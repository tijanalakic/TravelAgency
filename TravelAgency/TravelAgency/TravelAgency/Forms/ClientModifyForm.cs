using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.Forms
{
    public partial class ClientModifyForm : Form
    {
        List<city> cities;
        List<Control> buttons;
        List<Control> textboxes;
        List<Control> labels;
        private string oldPassport;
        public ClientModifyForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            FillUpCities();
            FillUpClientData();
          
        }
        private void FillUpCities()
        {
            comboBoxCity.Items.Clear();
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                cities = (from c in ctx.cities where c.idCountry == 1 select c).ToList();
                foreach (var c in cities)
                {
                    comboBoxCity.Items.Add(c.name);
                }
            }

        }
        private void FillUpClientData()
        {
            string pid = MainForm.pidOfSelectedCellClients;
            using(TravelAgencyDb ctx=new TravelAgencyDb())
            {
                var client = (from c in ctx.clients where c.person.pid == pid select c).First();

                textBoxFirstName.Text = client.person.firstName;
                textBoxLastName.Text = client.person.lastName;
                textBoxAddress.Text = client.person.address;
                textBoxPid.Text = client.person.pid;
                textBoxPassport.Text = client.passport;
                oldPassport= client.passport;
                textBoxPhone.Text = client.person.phone;
                textBoxMail.Text = client.person.email;
                comboBoxCity.SelectedIndex = comboBoxCity.FindStringExact(client.person.city.name);
            }
        }
        private void buttonModifyClient_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                string pid = MainForm.pidOfSelectedCellClients;
                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var client = (from c in ctx.clients where c.person.pid == pid select c).First();
                    var cityId = from c in ctx.cities where c.name == comboBoxCity.SelectedItem.ToString() select c.idCity;

                    client.person.firstName = textBoxFirstName.Text;
                    client.person.lastName = textBoxLastName.Text;
                    client.person.address = textBoxAddress.Text;
                    client.person.pid = textBoxPid.Text;
                    client.passport = textBoxPassport.Text;
                    client.person.phone = textBoxPhone.Text;
                    client.person.email = textBoxMail.Text;
                    client.person.idCity = cityId.First();
                    ctx.SaveChanges();
                }
                MessageBox.Show("Uspješno ste izmjenili podatke o klijentu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

            private void ClientModifyForm_Load(object sender, EventArgs e)
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
        }
        private bool validateForm()
        {
            bool result = true;
            string firstName, lastName, address, pid, phone, email, passport;
            firstName = textBoxFirstName.Text;
            lastName = textBoxLastName.Text;
            address = textBoxAddress.Text;
            pid = textBoxPid.Text;
            phone = textBoxPhone.Text;
            email = textBoxMail.Text;
            passport = textBoxPassport.Text;
            var city = comboBoxCity.Text;

            labelWarningFirstName.Visible = false;
            labelWarningLastName.Visible = false;
            labelWarningAddress.Visible = false;
            labelWarningCity.Visible = false;
            labelWarningMail.Visible = false;
            labelWarningPhone.Visible = false;
            labelWarningPid.Visible = false;
            labelWarningPassport.Visible = false;


            if (String.IsNullOrEmpty(firstName))
            {
                labelWarningFirstName.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(firstName, @"^[a-zA-ZŠšĐđČčĆćŽž]+$"))
            {
                labelWarningFirstName.Visible = true;
                labelWarningFirstName.Text = "Ime sadrži nedozvoljene karaktere!";
                result = false;
            }
            if (String.IsNullOrEmpty(lastName))
            {
                labelWarningLastName.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(lastName, @"^[a-zA-ZŠšĐđČčĆćŽž]+$"))
            {
                labelWarningLastName.Visible = true;
                labelWarningLastName.Text = "Prezime sadrži nedozvoljene karaktere!";
                result = false;
            }
            if (String.IsNullOrEmpty(address))
            {
                labelWarningAddress.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(address, "^[a-zA-ZŠšĐđČčĆćŽž0-9 ]+$"))
            {
                labelWarningAddress.Visible = true;
                labelWarningAddress.Text = "Adresa sadrži nedozvoljene karaktere!";
                result = false;
            }
            if (String.IsNullOrEmpty(pid))
            {
                labelWarningPid.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(pid, @"^[0-9]{13}$"))
            {
                labelWarningPid.Visible = true;
                labelWarningPid.Text = "JMBG mora imati 13 cifara!";
                result = false;
            }
            if (String.IsNullOrEmpty(phone))
            {
                labelWarningPhone.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(phone, "^[0-9]{3}\\/[0-9]{3}-[0-9]{3}$"))
            {
                labelWarningPhone.Visible = true;
                labelWarningPhone.Text = "Telefon mora biti u formatu: 000/000-000!";
                result = false;
            }
            if (String.IsNullOrEmpty(email))
            {
                labelWarningMail.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(email, "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$"))
            {
                labelWarningMail.Visible = true;
                labelWarningMail.Text = "E-mail mora biti u formatu: example@mail.com!";
                result = false;
            }
            if (String.IsNullOrEmpty(passport))
            {
                labelWarningPassport.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(passport, @"^[a-zA-Z0-9]{8}$"))
            {
                labelWarningPassport.Visible = true;
                labelWarningPassport.Text = "Broj pasoša mora imati 8 karaktera!";
                result = false;
            }
            else if (pidExists(passport))
            {
                labelWarningPassport.Visible = true;
                labelWarningPassport.Text = "Broj pasoša postoji u bazi!";
                result = false;
            }
            if (String.IsNullOrEmpty(city))
            {
                labelWarningCity.Visible = true;
                result = false;
            }
            return result;

        }
        private bool pidExists(string pid)
        {
            if (pid != oldPassport)
            {
                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var existPid = (from c in ctx.clients where c.passport == pid select c).FirstOrDefault();
                    return (existPid == null) ? false : true;
                }
            }else
            { return false; }

        }
      

        void Initialize_Add()
        {

            buttons = new List<Control>();
            textboxes = new List<Control>();
            labels = new List<Control>();


            buttons.Add(buttonModifyClient);
            buttons.Add(buttonAddCity);
            buttons.Add(buttonClose);


            textboxes.Add(textBoxFirstName);
            textboxes.Add(textBoxLastName);
            textboxes.Add(textBoxAddress);
            textboxes.Add(textBoxPid);
            textboxes.Add(textBoxMail);
            textboxes.Add(textBoxPassport);
            textboxes.Add(textBoxPhone);

            labels.Add(labelWarningAddress);
            labels.Add(labelWarningFirstName);
            labels.Add(labelWarningLastName);
            labels.Add(labelWarningPassport);
            labels.Add(labelWarningCity);
            labels.Add(labelWarningMail);
            labels.Add(labelWarningPhone);



        }

        void ApplyTheme(Color back, Color btn, Color tbox, Color combo, Color textColor)
        {
            this.BackColor = back;


            foreach (Control item in labels)
            {
                item.BackColor = back;
                item.ForeColor = Color.DarkRed;
            }

            foreach (Control item in buttons)
            {
                item.BackColor = btn;
                item.ForeColor = textColor;
            }
            foreach (Control item in textboxes)
            {

                item.BackColor = tbox;
                item.ForeColor = textColor;

            }

        }

        private void buttonAddCity_Click(object sender, EventArgs e)
        {
            CityForm city = new CityForm();
            city.ShowDialog();
            FillUpCities();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxMail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonModifyClient_Click(sender, e);
            }
        }

        private void ChangeLanguage(string lang)
        {

            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(ClientModifyForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}
