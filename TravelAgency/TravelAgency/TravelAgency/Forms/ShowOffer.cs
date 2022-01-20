using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Globalization;

namespace TravelAgency.Forms
{
    public partial class ShowOffer : Form
    {

        List<Control> buttons;
        List<Control> textboxes;
        List<Control> labels;
        List<Control> tabs;
        List<Control> labelList;

        string pidSelected;
        string pidOfSelectedCellPassanger;
        List<client> clientList;
        public ShowOffer()
        {
            InitializeComponent();
            this.CenterToScreen();
            FillUpOfferData();
            FillUpClientsPids();
            FillUpPassangerTable();
        }
        private void FillUpOfferData()
        {
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var offer = (from o in ctx.traveloffers
                             where o.idTravelOffer == MainForm.offer.idTravelOffer
                             select o).First();
                labelTitle.Text = offer.title;
                labelCountry.Text = offer.city.country.name;
                labelCity.Text = offer.city.name;
                labelArrival.Text = offer.arrivalDate.ToString();
                labelDeparture.Text = offer.departureDate.ToString();
                labelDescription.Text = offer.description;
                labelPrice.Text = offer.price.ToString();
                int numberOfAvailableSeats = offer.maxPassangerNumber - offer.passangerNumber;
                labelPassangerNumber.Text = numberOfAvailableSeats.ToString();
                labelMaxPassanger.Text = offer.maxPassangerNumber.ToString();
                labelTransportation.Text = offer.transportationtype.name;
                clientList = offer.clients.ToList();

            }
        }
        private void FillUpClientsPids()
        {
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                comboBoxClients.Items.Clear();
                var allClients = (from c in ctx.clients where c.isActive == true select c).ToList();
                var allPassangers = (from o in ctx.traveloffers
                                     where o.idTravelOffer == MainForm.offer.idTravelOffer
                                     select o.clients).First();
                foreach (var c in allClients)
                {

                    if (!allPassangers.Contains(c))
                    {
                        comboBoxClients.Items.Add(c.person.pid);
                    }
                }
            }
        }
        private void FillUpPassangerTable()
        {
            dataGridViewPassangers.Rows.Clear();
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {

                var offer = (from o in ctx.traveloffers
                             where o.idTravelOffer == MainForm.offer.idTravelOffer
                             select o).First();
                ICollection<client> clientList = offer.clients;
                foreach (var c in clientList)
                {
                    dataGridViewPassangers.Rows.Add(c.person.pid, c.person.firstName, c.person.lastName, c.person.phone, c.person.email, c.passport);
                }

            }
        }


        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            pidSelected = comboBoxClients.SelectedItem.ToString();
        }


        private void dataGridViewPassangers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPassangers.SelectedRows.Count > 0)
            {

                if (dataGridViewPassangers.SelectedRows[0].Cells[0].Value != null)
                {
                    pidOfSelectedCellPassanger = dataGridViewPassangers.SelectedRows[0].Cells[0].Value.ToString();
                }
            }
        }



        private void ShowOffer_Load(object sender, EventArgs e)
        {
            dataGridViewPassangers.SelectionChanged -= dataGridViewPassangers_SelectionChanged;
            try
            {
                FillUpClientsPids();
                FillUpOfferData();
                FillUpPassangerTable();
            }
            finally
            {
                dataGridViewPassangers.SelectionChanged += dataGridViewPassangers_SelectionChanged;
            }

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

            FillUpOfferData();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddPassanger_Click(object sender, EventArgs e)
        {
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var offer = (from o in ctx.traveloffers
                             where o.idTravelOffer == MainForm.offer.idTravelOffer
                             select o).First();
                var newPassanger = (from c in ctx.clients where c.person.pid == pidSelected select c).First();
                ICollection<client> clientList = offer.clients;
                clientList.Add(newPassanger);
                offer.passangerNumber++;
                ctx.SaveChanges();
                ShowOffer_Load(null, EventArgs.Empty);

            }
        }

        private void buttonAddNewClient_Click(object sender, EventArgs e)
        {
            ClientForm client = new ClientForm();
            client.ShowDialog();
        }

        private void buttonRemovePassanger_Click_1(object sender, EventArgs e)
        {
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var offer = (from o in ctx.traveloffers
                             where o.idTravelOffer == MainForm.offer.idTravelOffer
                             select o).First();
                var selectedPassanger = (from c in ctx.clients where c.person.pid == pidOfSelectedCellPassanger select c).First();
                ICollection<client> clientList = offer.clients;
                clientList.Remove(selectedPassanger);
                offer.passangerNumber--;
                ctx.SaveChanges();
                ShowOffer_Load(null, EventArgs.Empty);

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
            labelList = new List<Control>();

            tabs = new List<Control>();

            tabs.Add(tabPage1);
            tabs.Add(tabPage2);

            buttons.Add(buttonRemovePassanger);
            buttons.Add(buttonAddPassanger);
            buttons.Add(buttonAddNewClient);
            buttons.Add(buttonClose);
            buttons.Add(buttonCancel);

            labels.Add(labelTitle);
            labels.Add(labelTransportation);
            labels.Add(labelPrice);
            labels.Add(labelPassangerNumber);
            labels.Add(labelMaxPassanger);
            labels.Add(labelCity);
            labels.Add(labelArrival);
            labels.Add(labelDeparture);
            labels.Add(labelDescription);
            labels.Add(labelCountry);

            labelList.Add(label1);
            labelList.Add(label11);
            labelList.Add(label10);
            labelList.Add(label12);
            labelList.Add(label13);
            labelList.Add(label2);
            labelList.Add(label22);
            labelList.Add(label3);
            labelList.Add(label4);
            labelList.Add(label5);
            labelList.Add(label6);


        }

        void ApplyTheme(Color back, Color btn, Color tbox, Color combo, Color textColor)
        {
            this.BackColor = back;

            foreach (Control item in labels)
            {
                item.BackColor = back;
                item.ForeColor = btn;
            }

            foreach (Control item in tabs)
            {
                item.BackColor = back;
                item.ForeColor = textColor;
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

        private void comboBoxClients_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAddPassanger_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeLanguage(string lang)
        {




            foreach (Control c in buttons)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(ShowOffer));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
            foreach (Control c in tabs)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(ShowOffer));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
            foreach (Control c in labels)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(ShowOffer));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
            foreach (Control c in labelList)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(ShowOffer));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
            ComponentResourceManager resource = new ComponentResourceManager(typeof(ShowOffer));
            resource.ApplyResources(dataGridViewPassangers, dataGridViewPassangers.Name, new CultureInfo(lang));
        }

        private void dataGridViewPassangers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Language == "English")
                {
                    ContextMenu menuClient = new ContextMenu();

                    MenuItem menuItemRemove = new MenuItem("Remove");

                    menuClient.MenuItems.Add(menuItemRemove);

                    int currentMouseOverRow = dataGridViewPassangers.HitTest(e.X, e.Y).RowIndex;


                    menuClient.Show(dataGridViewPassangers, new Point(e.X, e.Y));


                    menuItemRemove.Click += new System.EventHandler(this.menuClientItemRemove_Click);
                }
                else
                {
                    ContextMenu menuClient = new ContextMenu();

                    MenuItem menuItemRemove = new MenuItem("Ukloni");

                    menuClient.MenuItems.Add(menuItemRemove);

                    int currentMouseOverRow = dataGridViewPassangers.HitTest(e.X, e.Y).RowIndex;


                    menuClient.Show(dataGridViewPassangers, new Point(e.X, e.Y));


                    menuItemRemove.Click += new System.EventHandler(this.menuClientItemRemove_Click);
                }
            }
        }

        private void menuClientItemRemove_Click(object sender, EventArgs e)
        {
            buttonRemovePassanger_Click_1(sender, e);
        }
    }
}