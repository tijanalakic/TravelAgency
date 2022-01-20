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
    public partial class CityForm : Form
    {

        List<Control> buttons;
        List<Control> textboxes;
        List<Control> labels;
        public CityForm()
        {
            InitializeComponent();
            FillUpCountries();
            this.CenterToScreen();

        }

        private void buttonAddCity_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {

                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var countryId = (from c in ctx.countries where c.name == comboBoxCountry2.SelectedItem.ToString() select c.idCountry).First();

                    var city = new city()
                    {

                        name = textBoxCity.Text,
                        idCountry = countryId
                    };

                    ctx.cities.Add(city);
                    ctx.SaveChanges();
                    MessageBox.Show("Uspješno ste dodali novi grad!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void FillUpCountries()
        {
            comboBoxCountry2.Items.Clear();
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var countries = ctx.countries.ToList();
                foreach (var c in countries)
                {
                    comboBoxCountry2.Items.Add(c.name);
                }
            }

        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool validateForm()
        {
            bool result = true;
            string country = comboBoxCountry2.Text;
            string city = textBoxCity.Text;
            labelWarningCity.Visible = false;
            labelWarningCountry.Visible = false;

            if (String.IsNullOrEmpty(city))
            {
                labelWarningCity.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(city, @"^[a-zA-ZŠšĐđČčĆćŽž ]+$"))
            {
                labelWarningCity.Visible = true;
                labelWarningCity.Text = "Naziv sadrži nedozvoljene karaktere!";
                result = false;
            }
            if (String.IsNullOrEmpty(country))
            {
                labelWarningCountry.Visible = true;
                result = false;
            }
            else if (exists(city))
            {
                labelWarningCity.Visible = true;
                labelWarningCity.Text = "Naziv grada već postoji u bazi!";
                result = false;
            }


            return result;
        }
        private bool exists(string city)
        {
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var countryId = (from c in ctx.countries where c.name == comboBoxCountry2.SelectedItem.ToString() select c.idCountry).FirstOrDefault();
                var existCity = (from c in ctx.cities
                                 where c.idCountry == countryId && c.name == city
                                 select c).FirstOrDefault();

                return (existCity == null) ? false : true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CityForm_Load(object sender, EventArgs e)
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


            buttons.Add(buttonAddCity);
            buttons.Add(buttonClose);


            textboxes.Add(textBoxCity);



            labels.Add(labelWarningCity);
            labels.Add(labelWarningCountry);




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

        private void textBoxCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAddCity_Click(sender, e);
            }
        }

        private void ChangeLanguage(string lang)
        {
            
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(CityForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}
