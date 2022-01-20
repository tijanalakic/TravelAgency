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
    public partial class UserModifyForm : Form
    {
        List<Control> buttons;
        List<Control> textboxes;
        List<Control> labels;
        List<city> cities;
        string usernameOld;
        public UserModifyForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            FillUpCities();
            FillUpUserData();
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
        private void FillUpUserData()
        {
            string pid = MainForm.pidOfSelectedCellUsers;
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var user = (from u in ctx.users where u.person.pid == pid select u).First();

                textBoxFirstName.Text = user.person.firstName;
                textBoxLastName.Text = user.person.lastName;
                textBoxAddress.Text = user.person.address;
                textBoxPid.Text = user.person.pid;
                textBoxUsername.Text = user.username;
                textBoxPassword.Text = user.password;
                textBoxPhone.Text = user.person.phone;
                textBoxMail.Text = user.person.email;
                usernameOld= user.username;
                comboBoxCity.SelectedIndex = comboBoxCity.FindStringExact(user.person.city.name);
                if (user.role.name == "admin")
                {
                    radioButtonAdmin.Checked = true;
                }
                else
                {
                    radioButtonReferent.Checked = true;
                }
            }
        }

        private void buttonModifyUser_Click(object sender, EventArgs e)
        {
            if (validateForm()) {
                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var user = (from u in ctx.users where u.person.pid == MainForm.pidOfSelectedCellUsers select u).First();
                    var cityId = from c in ctx.cities where c.name == comboBoxCity.SelectedItem.ToString() select c.idCity;

                    user.person.firstName = textBoxFirstName.Text;
                    user.person.lastName = textBoxLastName.Text;
                    user.person.address = textBoxAddress.Text;
                    user.person.pid = textBoxPid.Text;
                    user.username = textBoxUsername.Text;
                    user.password = textBoxPassword.Text;
                    user.person.phone = textBoxPhone.Text;
                    user.person.email = textBoxMail.Text;
                    user.person.idCity = cityId.First();
                    bool isChecked = radioButtonAdmin.Checked;
                    if (isChecked)
                    {
                        user.idRole = 1;
                    }
                    else
                    {
                        user.idRole = 2;
                    }
                    ctx.SaveChanges();
                    MessageBox.Show("Uspješno ste izmjenili podatke o klijentu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
            }
        }
        private bool validateForm()
        {
            bool result = true;
            string firstName, lastName, address, pid, phone, email, username, password;
            firstName = textBoxFirstName.Text;
            lastName = textBoxLastName.Text;
            address = textBoxAddress.Text;
            pid = textBoxPid.Text;
            phone = textBoxPhone.Text;
            email = textBoxMail.Text;
            username = textBoxUsername.Text;
            password = textBoxPassword.Text;
            var city = comboBoxCity.Text;
            labelWarningFirstName.Visible = false;
            labelWarningLastName.Visible = false;
            labelWarningAddress.Visible = false;
            labelWarningCity.Visible = false;
            labelWarningMail.Visible = false;
            labelWarningPhone.Visible = false;
            labelWarningPid.Visible = false;
            labelWarningUsername.Visible = false;
            labelWarningPassword.Visible = false;
            labelWarningAccount.Visible = false;

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
            else if (!Regex.IsMatch(address, @"^[a-zA-ZŠšĐđČčĆćŽž0-9 ]+$"))
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
            if (String.IsNullOrEmpty(username))
            {
                labelWarningUsername.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]{8,}$"))
            {
                labelWarningUsername.Visible = true;
                labelWarningUsername.Text = "Korisničko ime mora imati bar 8 karaktera!";
                result = false;
            }
            else if (!checkUsernameAvailable(username))
            {

                labelWarningUsername.Visible = true;
                labelWarningUsername.Text = "Korisničko ime već postoji!";
                result = false;

            }
            if (String.IsNullOrEmpty(password))
            {
                labelWarningPassword.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(username, "^.{8,35}$"))
            {
                labelWarningPassword.Visible = true;
                labelWarningPassword.Text = "Lozinka mora imati bar 8 karaktera!";
                result = false;
            }
            if (String.IsNullOrEmpty(city))
            {
                labelWarningCity.Visible = true;

                result = false;
            }
            return result;

        }
        private bool checkUsernameAvailable(string username)
        {
            if (username == usernameOld)
            {
                return true;
            }
            else
            {
                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var user = (from u in ctx.users where u.username == username select u).FirstOrDefault();
                    if (user != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void buttonAddCity_Click(object sender, EventArgs e)
        {
            CityForm city = new CityForm();
            city.ShowDialog();
            FillUpCities();
        }

        private void UserModifyForm_Load(object sender, EventArgs e)
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

        void Initialize_Add()
        {

            buttons = new List<Control>();
            textboxes = new List<Control>();
            labels = new List<Control>();


            buttons.Add(buttonModifyUser);
            buttons.Add(buttonAddCity);
            buttons.Add(buttonClose);


            textboxes.Add(textBoxFirstName);
            textboxes.Add(textBoxLastName);
            textboxes.Add(textBoxAddress);
            textboxes.Add(textBoxPid);
            textboxes.Add(textBoxMail);
            textboxes.Add(textBoxUsername);
            textboxes.Add(textBoxPassword);
            textboxes.Add(textBoxPhone);

            labels.Add(labelWarningAddress);
            labels.Add(labelWarningFirstName);
            labels.Add(labelWarningLastName);
            labels.Add(labelWarningPassword);
            labels.Add(labelWarningUsername);
            labels.Add(labelWarningCity);
            labels.Add(labelWarningMail);
            labels.Add(labelWarningPhone);



        }

        void ApplyTheme(Color back, Color btn, Color tbox, Color combo, Color textColor)
        {
            this.BackColor = back;



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
            foreach (Control item in labels)
            {
                item.BackColor = back;
                item.ForeColor = Color.DarkRed;
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonModifyUser_Click(sender, e);
            }
        }

        private void ChangeLanguage(string lang)
        {

            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(UserModifyForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}

