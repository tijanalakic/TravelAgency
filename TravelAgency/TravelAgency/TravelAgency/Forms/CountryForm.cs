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
    public partial class CountryForm : Form
    {
        List<Control> buttons;
        List<Control> textboxes;
        List<Control> labels;
        public CountryForm()
        {
            InitializeComponent();
            this.CenterToScreen();

        }

        private void buttonAddCountry_Click(object sender, EventArgs e)
        {

            if (validateForm())
            {

                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    country country = new country()
                    {
                        name = textBoxCountry.Text,
                        
                    };
                    ctx.countries.Add(country);
                    ctx.SaveChanges();
                    var countryId = (from c in ctx.countries where c.name == textBoxCountry.Text select c.idCountry).First();

                    city city = new city()
                    {
                        name = textBoxCity.Text,
                        idCountry = countryId
                    };

                ctx.cities.Add(city);
                ctx.SaveChanges();
                MessageBox.Show("Uspješno ste dodali novu državu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }   }
        }
        


        private bool validateForm()
        {
            bool result = true;
            string country = textBoxCountry.Text;
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
            else if (!Regex.IsMatch(country, @"^[a-zA-ZŠšĐđČčĆćŽž ]+$"))
            {
                labelWarningCountry.Visible = true;
                labelWarningCountry.Text = "Naziv sadrži nedozvoljene karaktere!";
                result = false;
            }else if (exists(country))
            {
                labelWarningCountry.Visible = true;
                labelWarningCountry.Text = "Država postoji u bazi!";
                result = false;
            }


            return result;
        }

        private bool exists(string country)
        {
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var existCountry = (from c in ctx.countries where c.name == country select c).FirstOrDefault();
                

                return (existCountry == null) ? false : true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Initialize_Add()
        {

            buttons = new List<Control>();
            textboxes = new List<Control>();
            labels = new List<Control>();


            buttons.Add(buttonAddCountry);
            buttons.Add(buttonClose);


            textboxes.Add(textBoxCity);
            textboxes.Add(textBoxCountry);




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

        private void CountryForm_Load(object sender, EventArgs e)
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

        private void textBoxCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAddCountry_Click(sender, e);
            }
        }

        private void ChangeLanguage(string lang)
        {

            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(CountryForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}
