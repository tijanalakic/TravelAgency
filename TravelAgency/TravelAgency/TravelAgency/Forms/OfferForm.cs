using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using TravelAgency.Forms;
using System.Globalization;

namespace TravelAgency
{
    public partial class OfferForm : Form
    {

        List<Control> buttons;
        List<Control> textboxes;
        List<Control> labels;
        public OfferForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            FillUpCountries();
            dateTimePickerDeparture.MinDate = DateTime.Today;
            dateTimePickerArrival.MinDate = DateTime.Today;

        }
        private void FillUpCountries()
        {
            comboBoxCountry.Items.Clear();
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var countries = ctx.countries.ToList();
                foreach (var c in countries)
                {
                    comboBoxCountry.Items.Add(c.name);
                }
            }

        }
        private void FillUpCities()
        {
            comboBoxCity.Items.Clear();
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var cities = (from c in ctx.cities where c.idCountry == comboBoxCountry.SelectedIndex + 1 select c).ToList();
                foreach (var c in cities)
                {
                    comboBoxCity.Items.Add(c.name);
                }
            }

        }

       
   

        private void OfferForm_Load(object sender, EventArgs e)
        {
            FillUpCountries();

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







        private void button2_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {

                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var cityId = from c in ctx.cities where c.name == comboBoxCity.SelectedItem.ToString() select c.idCity;
                    string value = "";
                    bool isChecked = radioButtonBus.Checked;
                    if (isChecked)
                    {
                        value = radioButtonBus.Text;
                    }
                    else
                    {
                        value = radioButtonAvion.Text;
                    }
                    var transportId = from t in ctx.transportationtypes where t.name == value select t.idTransportationType;
                    var offer = new traveloffer()
                    {

                        title = textBoxTitle.Text,
                        maxPassangerNumber = int.Parse(textBoxMaxPassanger.Text),
                        description = textBoxDescription.Text,
                        departureDate = dateTimePickerDeparture.Value,
                        arrivalDate = dateTimePickerArrival.Value,
                        price=decimal.Parse(textBoxPrice.Text),
                        idCity = cityId.First(),
                        idTransportationType = transportId.First(),
                        isActive=true
                    };

                    ctx.traveloffers.Add(offer);
                    ctx.SaveChanges();
                    MessageBox.Show("Uspješno ste dodali novou ponudu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillUpCities();
            comboBoxCity.SelectedIndex = 0;
        }

        private bool validateForm()
        {
            bool result = true;
            string title, price, maxPassanger, city, country;
            maxPassanger = textBoxMaxPassanger.Text;
            title = textBoxTitle.Text;
            price = textBoxPrice.Text;
            var departure = dateTimePickerDeparture.Value;
            var arrival = dateTimePickerArrival.Value;
            country = comboBoxCountry.Text;
            city = comboBoxCity.Text;

            labelWarningTitle.Visible = false;
            labelWarningPrice.Visible = false;
            labelWarningMaxPassenger.Visible = false;
            labelWarningMaxPassenger.Visible = false;
            labelWarningArrival.Visible = false;
            labelWarningTransport.Visible = false;
            labelWarningCity.Visible = false;
            labelWarningCountry.Visible = false;

            if (String.IsNullOrEmpty(title))
            {
                labelWarningTitle.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(title, @"^[a-zA-ZŠšĐđČčĆćŽž0-9 ]+$"))
            {
                labelWarningTitle.Visible = true;
                labelWarningTitle.Text = "Naziv sadrži nedozvoljene karaktere!";
                result = false;
            }
            if (String.IsNullOrEmpty(price))
            {
                labelWarningPrice.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(price, "^[0-9]{1,6}.{0,1}[0-9]{0,2}$"))
            {
                labelWarningPrice.Visible = true;
                labelWarningPrice.Text = "Iznos nije u validnom formatu!";
                result = false;
            }
            if (String.IsNullOrEmpty(maxPassanger))
            {
                labelWarningMaxPassenger.Visible = true;
                result = false;
            }
            else if (!Regex.IsMatch(maxPassanger, @"^[0-9]{1,4}$"))
            {
                labelWarningMaxPassenger.Visible = true;
                labelWarningMaxPassenger.Text = "Broj putnika mora biti  numerička vrijednost!";
                result = false;
            }

            if (arrival < departure)
            {
                labelWarningArrival.Visible = true;
                labelWarningArrival.Text = "Datum povratka nije validan!";
                result = false;
            }
            if (!radioButtonAvion.Checked && !radioButtonBus.Checked)
            {
                labelWarningTransport.Visible = true;
                result = false;
            }
            if (String.IsNullOrEmpty(city))
            {
                labelWarningCity.Visible = true;
                result = false;
            }
            if (String.IsNullOrEmpty(country))
            {
                labelWarningCountry.Visible = true;
                result = false;
            }
            return result;
        }

        private void buttonAddCountry_Click(object sender, EventArgs e)
        {

            CountryForm country= new CountryForm();
            country.ShowDialog();
            OfferForm_Load(null, EventArgs.Empty);
        }

        private void buttonAddCity_Click(object sender, EventArgs e)
        {

            CityForm city = new CityForm();
            city.ShowDialog();
            OfferForm_Load(null, EventArgs.Empty);

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


            buttons.Add(buttonAddOffer);
            buttons.Add(buttonAddCity);
            buttons.Add(buttonAddCountry);
            buttons.Add(buttonClose);

            textboxes.Add(textBoxTitle);
            textboxes.Add(textBoxPrice);
            textboxes.Add(textBoxMaxPassanger);

            labels.Add(labelWarningTitle);
            labels.Add(labelWarningTransport);
            labels.Add(labelWarningPrice);
            labels.Add(labelWarningMaxPassenger);
            labels.Add(labelWarningCity);
            labels.Add(labelWarningArrival);
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
        private void ChangeLanguage(string lang)
        {

            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(OfferForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}
