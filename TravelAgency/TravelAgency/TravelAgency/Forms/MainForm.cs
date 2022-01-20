using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace TravelAgency.Forms
{
    public partial class MainForm : Form
    {
        List<Control> buttons;
        List<Control> textboxes;
        List<Control> tabPages;
        List<Control> dataGridViews;
        List<Control> labels;
        List<Control> toolTips;
        public static string pidOfSelectedCellClients;
        public static string pidOfSelectedCellUsers;
        public static List<traveloffer> allActiveOffers;
        public static List<traveloffer> allOffers;
        public static traveloffer offer;
        public static traveloffer selectedOffer;
        public static string theme;
        public static bool isChecked = true;

        public MainForm()
        {
            InitializeComponent();

            this.CenterToScreen();

            FillUpCountries();
            comboBoxCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCountry.AutoCompleteSource = AutoCompleteSource.ListItems;

            FillUpUsers();
            FillUpClients();
            FillUpActiveOffers();
        }

        private void FillUpActiveOffers()
        {
            dataGridViewOffers.Rows.Clear();
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                allActiveOffers =
               (from c in ctx.traveloffers
                where c.departureDate > DateTime.Today && c.isActive == true
                select c).ToList();

                allOffers =
               (from c in ctx.traveloffers
                where c.isActive == true
                select c).ToList();
                foreach (var c in allActiveOffers)
                {
                    dataGridViewOffers.Rows.Add(c.title, c.departureDate.ToString("dd/MM/yyyy"), c.arrivalDate.ToString("dd/MM/yyyy"), c.price, c.city.country.name, c.city.name, c.passangerNumber, c.transportationtype.name, c.idTravelOffer);
                }
            }
        }
        private void FillUpOffers()
        {
            dataGridViewOffers.Rows.Clear();
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                allOffers =
               (from c in ctx.traveloffers
                where c.isActive == true
                select c).ToList();
                foreach (var c in allOffers)
                {
                    dataGridViewOffers.Rows.Add(c.title, c.departureDate, c.arrivalDate, c.price, c.city.country.name, c.city.name, c.passangerNumber, c.transportationtype.name, c.idTravelOffer);
                }
            }
        }
        private void FillUpClients()
        {
            dataGridViewClients.Rows.Clear();
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var allClients =
                (from c in ctx.clients
                 where c.isActive == true
                 select c).ToList();
                foreach (var c in allClients)
                {
                    dataGridViewClients.Rows.Add(c.person.pid, c.person.firstName, c.person.lastName, c.person.phone, c.person.email, c.passport);
                }
            }
            if (dataGridViewClients.Rows.Count > 0)
            {
                pidOfSelectedCellClients = dataGridViewClients.Rows[0].Cells[0].Value.ToString();

            }
        }
        private void FillUpUsers()
        {
            dataGridViewUsers.Rows.Clear();
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var allUsers =
                (from c in ctx.users
                 where c.isActive == true
                 select c).ToList();
                foreach (var c in allUsers)
                {
                    dataGridViewUsers.Rows.Add(c.person.pid, c.person.firstName, c.person.lastName, c.person.phone, c.person.email, c.username);
                }
            }

            if (dataGridViewOffers.Rows.Count > 0)
            {
                pidOfSelectedCellUsers = dataGridViewUsers.Rows[0].Cells[0].Value.ToString();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            OfferForm offer = new OfferForm();
            offer.ShowDialog();
            MainForm_Load(null, EventArgs.Empty);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClientForm form = new ClientForm();
            form.ShowDialog();
            MainForm_Load(null, EventArgs.Empty);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.ShowDialog();
            MainForm_Load(null, EventArgs.Empty);


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Initialize_Add();
     
            comboBoxThemeSettings.SelectedItem= Properties.Settings.Default.Theme;
            comboBoxLanguageSettings.SelectedItem = Properties.Settings.Default.Language;
            FillUpCountries();
            comboBoxCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCountry.AutoCompleteSource = AutoCompleteSource.ListItems;

            FillUpUsers();
            FillUpClients();
            if (checkBox1.Checked)
            {
                FillUpActiveOffers();

            }
            else
            {
                FillUpOffers();
            }

            if (LoginForm.user.idRole == 2) {
                buttonAdd.Visible = false;
                buttonDelete.Visible = false;
                buttonModify.Visible = false;
                buttonDeleteClient.Visible = false;
                buttonRemoveOffer.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OfferModifyForm offerModifyForm = new OfferModifyForm();
            offerModifyForm.ShowDialog();
            MainForm_Load(null, EventArgs.Empty);

        }

        private void button9_Click(object sender, EventArgs e)
        {   if (pidOfSelectedCellClients == null)
            {
                MessageBox.Show("Morate selektovati klijenta!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                ClientModifyForm clientModifyForm = new ClientModifyForm();
                clientModifyForm.ShowDialog();
                MainForm_Load(null, EventArgs.Empty);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pidOfSelectedCellUsers == null)
            {
                MessageBox.Show("Morate selektovati korisnika!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                UserModifyForm userModifyForm = new UserModifyForm();
                userModifyForm.ShowDialog();
                MainForm_Load(null, EventArgs.Empty);
            }
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillUpCities();
            comboBoxCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCity.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewOffers.Rows.Clear();

            if (checkBox1.Checked)
            {
                isChecked = true;

                FillUpActiveOffers();
            }
            else
            {
                isChecked = false;
                FillUpOffers();
            }
        }

        private void dataGridViewClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewClients.Focused && dataGridViewClients.SelectedRows.Count > 0)
            {
                pidOfSelectedCellClients = dataGridViewClients.SelectedRows[0].Cells[0].Value.ToString();
            }
        }


        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            
                if (dataGridViewUsers.Focused && dataGridViewUsers.SelectedRows.Count > 0)
                {
                    pidOfSelectedCellUsers = dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString();
                }
            
        }


        private void dataGridViewOffers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = int.Parse(dataGridViewOffers.SelectedRows[0].Cells[8].Value.ToString());

            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                offer =
               (from c in ctx.traveloffers
                where c.idTravelOffer == index
                select c).FirstOrDefault();
            }
                if (offer.maxPassangerNumber > offer.passangerNumber)
            {
                ShowOffer windowOffer = new ShowOffer();
                windowOffer.ShowDialog();
                MainForm_Load(null, EventArgs.Empty);

            }
            else
            {
                MessageBox.Show("Nema slobodnog mijesta za ovu ponudu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void buttonRemoveOffer_Click(object sender, EventArgs e)
        {
            if (selectedOffer == null)
            {
                MessageBox.Show("Morate selektovati ponudu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var offerSelected = (from o in ctx.traveloffers
                                         where o.idTravelOffer == selectedOffer.idTravelOffer
                                         select o).First();
                    offerSelected.isActive = false;
                    MessageBox.Show("Uspješno ste uklonili ponudu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctx.SaveChanges();
                    MainForm_Load(null, EventArgs.Empty);

                }
            }
        }

        private void buttonModifyOffer_Click(object sender, EventArgs e)
        {
            OfferModifyForm modifyOffer = new OfferModifyForm();
            modifyOffer.ShowDialog();
            MainForm_Load(null, EventArgs.Empty);
        }

        private void buttonAddOffer_Click(object sender, EventArgs e)
        {
            OfferForm newOffer = new OfferForm();
            newOffer.ShowDialog();
            MainForm_Load(null, EventArgs.Empty);


        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            if (pidOfSelectedCellClients == null)
            {
                MessageBox.Show("Morate selektovati klijenta!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else { 
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var client = (from c in ctx.clients where c.person.pid == pidOfSelectedCellClients select c).First();

                client.isActive = false;
                ctx.SaveChanges();
            }
            MessageBox.Show("Uspješno ste uklonili klijenta!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainForm_Load(null, EventArgs.Empty);
            }
        }
        private void dataGridViewOffers_SelectionChanged(object sender, EventArgs e)
        {
            traveloffer seloffer;
            if (dataGridViewOffers.Focused  && dataGridViewOffers.SelectedRows.Count > 0)
            {
                int index = int.Parse(dataGridViewOffers.SelectedRows[0].Cells[8].Value.ToString());
                Console.WriteLine("indeks:"+index);

                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                     seloffer =
                   (from c in ctx.traveloffers
                    where c.idTravelOffer == index
                    select c).FirstOrDefault();
                }
               
                    selectedOffer = seloffer;
                    offer = seloffer;
                
            }
        }

        private void buttonSearchClient_Click(object sender, EventArgs e)
        {
            var pid = textBoxJMBGKlijent.Text;
            if (pid == null || pid == "")
            {
                FillUpClients();

            } else {
                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var clients = (from c in ctx.clients where c.person.pid.StartsWith(pid) && c.isActive == true select c).ToList();
                    if (clients != null)
                    {
                        dataGridViewClients.Rows.Clear();
                        foreach (var client in clients)
                        {
                            dataGridViewClients.Rows.Add(client.person.pid, client.person.firstName, client.person.lastName, client.person.phone, client.person.email);
                        }
                        if (dataGridViewClients.Rows.Count > 0)
                        {
                            pidOfSelectedCellClients = dataGridViewClients.Rows[0].Cells[0].Value.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ne postoji trazeni klijent!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridViewClients.Rows.Clear();

                    }
                }
            }
        }

        private void textBoxJMBGKlijent_TextChanged(object sender, EventArgs e)
        {
            if (textBoxJMBGKlijent.Text == "")
            {
                FillUpClients();
            }
        }

        private void textBoxJMBGKlijent_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                buttonSearchClient_Click(sender, e);
            }
        }

        private void textBoxJMBGKorisnik_TextChanged(object sender, EventArgs e)
        {
            if (textBoxJMBGKlijent.Text == "")
            {
                FillUpUsers();
            }
        }

        private void textBoxJMBGKorisnik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearchUser_Click(sender, e);
            }
        }

        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            var pid = textBoxJMBGKorisnik.Text;
            if (pid == null || pid == "")
            {
                FillUpUsers();

            }
            else
            {
                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var users = (from c in ctx.users where c.person.pid.StartsWith(pid) && c.isActive == true select c).ToList();
                    if (users != null)
                    {
                        dataGridViewUsers.Rows.Clear();
                        foreach (var user in users)
                        {
                            dataGridViewUsers.Rows.Add(user.person.pid, user.person.firstName, user.person.lastName, user.person.phone, user.person.email);
                        }
                        if (dataGridViewUsers.Rows.Count > 0)
                        {
                            pidOfSelectedCellUsers = dataGridViewUsers.Rows[0].Cells[0].Value.ToString();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ne postoji trazeni korisnik!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridViewUsers.Rows.Clear();

                    }
                }
            }
        }

        private void buttonSearchOffer_Click(object sender, EventArgs e)
        {
            string name = textBoxTitle.Text;
            string country = (comboBoxCountry.SelectedItem != null) ? comboBoxCountry.SelectedItem.ToString() : "";
            string city = (comboBoxCity.SelectedItem != null) ? comboBoxCity.SelectedItem.ToString() : "";

            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                allOffers =
                (from c in ctx.traveloffers
                 where c.isActive ==true && (name == ""  || c.title.Contains(name))
                        && (country == "" || c.city.country.name == country)
                        && (city == "" || c.city.name == city) select c).ToList();
                
                allActiveOffers =
                (from c in ctx.traveloffers
                 where c.isActive == true && c.departureDate > DateTime.Today && (name == "" || c.title.Contains(name))
                        && (country == "" || c.city.country.name == country)
                        && (city == "" || c.city.name == city)
                 select c).ToList();

                dataGridViewOffers.Rows.Clear();

                List<traveloffer> offers = (checkBox1.Checked) ? allActiveOffers : allOffers;
                foreach (var c in offers)
                {
                    dataGridViewOffers.Rows.Add(c.title, c.departureDate, c.arrivalDate, c.price, c.city.country.name, c.city.name, c.passangerNumber, c.transportationtype.name, c.idTravelOffer);
                }
            }


        }

        void Initialize_Add()
        {

            buttons = new List<Control>();
            textboxes = new List<Control>();
            tabPages = new List<Control>();
            dataGridViews = new List<Control>();
            labels = new List<Control>();
            toolTips = new List<Control>();

            buttons.Add(buttonSearchUser);
            buttons.Add(buttonAdd);
            buttons.Add(buttonModify);
            buttons.Add(buttonShowOffer);
            buttons.Add(buttonDelete);
            buttons.Add(buttonAddOffer);
            buttons.Add(buttonModifyOffer);
            buttons.Add(buttonRemoveOffer);
            buttons.Add(buttonSearchClient);
            buttons.Add(buttonAddClient);
            buttons.Add(buttonModifyClient);
            buttons.Add(buttonDeleteClient);
            buttons.Add(buttonSearchOffer);
            buttons.Add(buttonViewClient);
            buttons.Add(buttonViewUser);
            buttons.Add(buttonLogout);

            textboxes.Add(textBoxJMBGKorisnik);
            textboxes.Add(textBoxJMBGKlijent);
            textboxes.Add(textBoxTitle);

           /* toolTips.Add(toolTip1);
            toolTips.Add(toolTip2);
            toolTips.Add(toolTip3);
            toolTips.Add(toolTip4);
            toolTips.Add(toolTip5);
            toolTips.Add(toolTip6);*/

            tabPages.Add(tabPage1);
            tabPages.Add(tabPage2);
            tabPages.Add(tabPage3);

            dataGridViews.Add(dataGridViewUsers);
            dataGridViews.Add(dataGridViewClients);
            dataGridViews.Add(dataGridViewOffers);

            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label10);
            labels.Add(label8);
            labels.Add(label12);






        }

        void ApplyTheme(Color back, Color btn, Color tbox, Color combo, Color textColor)
        {
            this.BackColor = back;
            
            foreach (Control item in tabPages)
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
            buttonLogout.BackColor = btn;
            panelSettings.BackColor = btn;

        }

        

        private void dataGridViewOffers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewOffers_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                traveloffer seloffer;
                var index = int.Parse(dataGridViewOffers.SelectedRows[0].Cells[8].Value.ToString());

                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    seloffer =
                  (from c in ctx.traveloffers
                   where c.idTravelOffer == index
                   select c).FirstOrDefault();
                }
                if (checkBox1.Checked)
                {
                    offer = seloffer;
                    selectedOffer = seloffer;

                }
                else
                {
                    offer = seloffer;
                    selectedOffer = seloffer;

                }
                if (Properties.Settings.Default.Language == "English")
                {
                    ContextMenu menu = new ContextMenu();
                    MenuItem menuItemView = new MenuItem("View");
                    MenuItem menuItemEdit = new MenuItem("Edit");
                    MenuItem menuItemRemove = new MenuItem("Remove");
                    menu.MenuItems.Add(menuItemView);
                    menu.MenuItems.Add(menuItemEdit);
                    menu.MenuItems.Add(menuItemRemove);

                    int currentMouseOverRow = dataGridViewOffers.HitTest(e.X, e.Y).RowIndex;


                    menu.Show(dataGridViewOffers, new Point(e.X, e.Y));

                    menuItemView.Click += new System.EventHandler(this.menuItemView_Click);
                    menuItemEdit.Click += new System.EventHandler(this.menuItemEdit_Click);
                    menuItemRemove.Click += new System.EventHandler(this.menuItemRemove_Click);
                }
                else
                {

                    ContextMenu menu = new ContextMenu();
                    MenuItem menuItemView = new MenuItem("Pregled");
                    MenuItem menuItemEdit = new MenuItem("Uredi");
                    MenuItem menuItemRemove = new MenuItem("Obrisi");
                    menu.MenuItems.Add(menuItemView);
                    menu.MenuItems.Add(menuItemEdit);
                    menu.MenuItems.Add(menuItemRemove);

                    int currentMouseOverRow = dataGridViewOffers.HitTest(e.X, e.Y).RowIndex;


                    menu.Show(dataGridViewOffers, new Point(e.X, e.Y));

                    menuItemView.Click += new System.EventHandler(this.menuItemView_Click);
                    menuItemEdit.Click += new System.EventHandler(this.menuItemEdit_Click);
                    menuItemRemove.Click += new System.EventHandler(this.menuItemRemove_Click);
                }
            }
        }
        private void menuItemView_Click(object sender, System.EventArgs e)
        {
            if (offer.maxPassangerNumber > offer.passangerNumber)
            {
                ShowOffer windowOffer = new ShowOffer();
                windowOffer.ShowDialog();
                MainForm_Load(null, EventArgs.Empty);

            }
            else
            {
                MessageBox.Show("Nema slobodnog mijesta za ovu ponudu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void menuItemEdit_Click(object sender, System.EventArgs e)
        {
            OfferModifyForm offerModifyForm = new OfferModifyForm();
            offerModifyForm.ShowDialog();
            MainForm_Load(null, EventArgs.Empty);

        }
        private void menuItemRemove_Click(object sender, System.EventArgs e)
        {
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var offerSelected = (from o in ctx.traveloffers
                                     where o.idTravelOffer == selectedOffer.idTravelOffer
                                     select o).First();
                offerSelected.isActive = false;
                MessageBox.Show("Uspješno ste uklonili ponudu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctx.SaveChanges();
                MainForm_Load(null, EventArgs.Empty);

            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowOffer_Click_1(object sender, EventArgs e)
        {
            var index = int.Parse(dataGridViewOffers.CurrentCell.RowIndex.ToString());
            if (checkBox1.Checked)
            {
                offer = allActiveOffers[index];
            }
            else
            {
                offer = allOffers[index];
            }
            if (offer.maxPassangerNumber > offer.passangerNumber)
            {
                ShowOffer windowOffer = new ShowOffer();
                windowOffer.ShowDialog();
                MainForm_Load(null, EventArgs.Empty);

            }
            else
            {
                MessageBox.Show("Nema slobodnog mijesta za ovu ponudu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (pidOfSelectedCellUsers == null)
            {
                MessageBox.Show("Morate selektovati korisnika!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                using (TravelAgencyDb ctx = new TravelAgencyDb())
                {
                    var user = (from c in ctx.users where c.person.pid == pidOfSelectedCellUsers select c).First();

                    user.isActive = false;
                    ctx.SaveChanges();
                }
                MessageBox.Show("Uspješno ste uklonili korisnika!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm_Load(null, EventArgs.Empty);
            }
        }



        private void buttonLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewClients_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Language == "English") {
                    ContextMenu menuClient = new ContextMenu();
                    MenuItem menuItemView = new MenuItem("View");
                    MenuItem menuItemEdit = new MenuItem("Edit");
                    MenuItem menuItemRemove = new MenuItem("Remove");
                    menuClient.MenuItems.Add(menuItemView);
                    menuClient.MenuItems.Add(menuItemEdit);
                    menuClient.MenuItems.Add(menuItemRemove);

                    int currentMouseOverRow = dataGridViewClients.HitTest(e.X, e.Y).RowIndex;


                    menuClient.Show(dataGridViewClients, new Point(e.X, e.Y));

                    menuItemView.Click += new System.EventHandler(this.menuClientItemView_Click);
                    menuItemEdit.Click += new System.EventHandler(this.menuClientItemEdit_Click);
                    menuItemRemove.Click += new System.EventHandler(this.menuClientItemRemove_Click);
                }
                else
                {

                    ContextMenu menuClient = new ContextMenu();
                    MenuItem menuItemView = new MenuItem("Pregled");
                    MenuItem menuItemEdit = new MenuItem("Uredi");
                    MenuItem menuItemRemove = new MenuItem("Obrisi");
                    menuClient.MenuItems.Add(menuItemView);
                    menuClient.MenuItems.Add(menuItemEdit);
                    menuClient.MenuItems.Add(menuItemRemove);

                    int currentMouseOverRow = dataGridViewClients.HitTest(e.X, e.Y).RowIndex;


                    menuClient.Show(dataGridViewClients, new Point(e.X, e.Y));

                    menuItemView.Click += new System.EventHandler(this.menuClientItemView_Click);
                    menuItemEdit.Click += new System.EventHandler(this.menuClientItemEdit_Click);
                    menuItemRemove.Click += new System.EventHandler(this.menuClientItemRemove_Click);
                }
            }
        }

        private void menuClientItemView_Click(object sender, EventArgs e)
        {
            ClientViewForm clientViewForm = new ClientViewForm();
            clientViewForm.ShowDialog();
        }

        private void menuClientItemEdit_Click(object sender, EventArgs e)
        {
            ClientModifyForm clientModifyForm = new ClientModifyForm();
            clientModifyForm.ShowDialog();
            MainForm_Load(null, EventArgs.Empty);
        }

        private void menuClientItemRemove_Click(object sender, EventArgs e)
        {
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var client = (from c in ctx.clients where c.person.pid == pidOfSelectedCellClients select c).First();

                client.isActive = false;
                ctx.SaveChanges();
            }
            MessageBox.Show("Uspješno ste uklonili klijenta!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainForm_Load(null, EventArgs.Empty);
        }

        private void dataGridViewUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                if (Properties.Settings.Default.Language == "English") {

                    ContextMenu menuUser = new ContextMenu();
                    MenuItem menuItemView = new MenuItem("View");
                    MenuItem menuItemEdit = new MenuItem("Edit");
                    MenuItem menuItemRemove = new MenuItem("Remove");
                    menuUser.MenuItems.Add(menuItemView);
                    menuUser.MenuItems.Add(menuItemEdit);
                    menuUser.MenuItems.Add(menuItemRemove);

                    int currentMouseOverRow = dataGridViewUsers.HitTest(e.X, e.Y).RowIndex;

                    menuUser.Show(dataGridViewUsers, new Point(e.X, e.Y));

                    menuItemView.Click += new System.EventHandler(this.menuUserItemView_Click);
                    menuItemEdit.Click += new System.EventHandler(this.menuUserItemEdit_Click);
                    menuItemRemove.Click += new System.EventHandler(this.menuUserItemRemove_Click);


                } else { 

                ContextMenu menuUser = new ContextMenu();
                    MenuItem menuItemView = new MenuItem("Pregled");
                    MenuItem menuItemEdit = new MenuItem("Uredi");
                    MenuItem menuItemRemove = new MenuItem("Obrisi");
                    menuUser.MenuItems.Add(menuItemView);
                    menuUser.MenuItems.Add(menuItemEdit);
                    menuUser.MenuItems.Add(menuItemRemove);

                    int currentMouseOverRow = dataGridViewUsers.HitTest(e.X, e.Y).RowIndex;

                    menuUser.Show(dataGridViewUsers, new Point(e.X, e.Y));

                    menuItemView.Click += new System.EventHandler(this.menuUserItemView_Click);
                    menuItemEdit.Click += new System.EventHandler(this.menuUserItemEdit_Click);
                    menuItemRemove.Click += new System.EventHandler(this.menuUserItemRemove_Click);
                }
            }
        }

        private void menuUserItemView_Click(object sender, EventArgs e)
        {
            UserViewForm userViewForm = new UserViewForm();
            userViewForm.ShowDialog();
        }

        private void menuUserItemEdit_Click(object sender, EventArgs e)
        {
            UserModifyForm userModifyForm = new UserModifyForm();
            userModifyForm.ShowDialog();
            MainForm_Load(null, EventArgs.Empty);
        }

        private void menuUserItemRemove_Click(object sender, EventArgs e)
        {
            using (TravelAgencyDb ctx = new TravelAgencyDb())
            {
                var user = (from c in ctx.users where c.person.pid == pidOfSelectedCellUsers select c).First();

                user.isActive = false;
                ctx.SaveChanges();
            }
            MessageBox.Show("Uspješno ste uklonili korisnika!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainForm_Load(null, EventArgs.Empty);
        }

        private void dataGridViewClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientViewForm view = new ClientViewForm();
            view.ShowDialog();
          
        }

        private void dataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UserViewForm userViewForm = new UserViewForm();
            userViewForm.ShowDialog();
        }

        private void comboBoxThemeSettings_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxThemeSettings.Text == "PaleVioletRed")
            {
                ApplyTheme(Color.FromArgb(205,94,119), Color.FromArgb(100, 12, 60), Color.FromArgb(205, 94, 119), Color.FromArgb(205, 94, 119), Color.Azure);
                Properties.Settings.Default.Theme = "PaleVioletRed";
                Properties.Settings.Default.Save();
            }
            else if (comboBoxThemeSettings.Text == "MidnightBlue")
            {
                ApplyTheme(Color.MidnightBlue, Color.RoyalBlue, Color.MidnightBlue, Color.MidnightBlue, SystemColors.InactiveCaption);
                Properties.Settings.Default.Theme = "MidnightBlue";
                Properties.Settings.Default.Save();
            }
            else
            {
                ApplyTheme(Color.RoyalBlue, Color.MidnightBlue, Color.RoyalBlue, Color.RoyalBlue, SystemColors.InactiveCaption);
                Properties.Settings.Default.Theme = "RoyalBlue";
                Properties.Settings.Default.Save();
            }
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
             {
                 ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                 resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }

            foreach (Control c in buttons)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
            foreach (Control c in tabPages) {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
            foreach (Control c in labels)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
            foreach (Control c in dataGridViews)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }

            ComponentResourceManager resourcess = new ComponentResourceManager(typeof(MainForm));
            resourcess.ApplyResources(panelSettings, panelSettings.Name, new CultureInfo(lang));

        }



        
        private void comboBoxLanguageSettings_SelectedIndexChanged(object sender, EventArgs e)
        {  
                string lang = comboBoxLanguageSettings.Text;
                if (lang == "English")
                {
                    ChangeLanguage("en");
                    Properties.Settings.Default.Language = lang;
                    Properties.Settings.Default.Save();


                }
                else if (lang == "Srpski")
                {
                    ChangeLanguage("");
                    Properties.Settings.Default.Language = lang;
                    Properties.Settings.Default.Save();
                }
        }

        private void buttonViewUser_Click(object sender, EventArgs e)
        {
            UserViewForm userViewForm = new UserViewForm();
            userViewForm.ShowDialog();
        }

        private void buttonViewClient_Click(object sender, EventArgs e)
        {
            ClientViewForm view = new ClientViewForm();
            view.ShowDialog();
        }

        private void textBoxTitle_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                buttonSearchOffer_Click(sender, e);
            }
        }

        private void comboBoxCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearchOffer_Click(sender, e);
            }
        }

        private void comboBoxCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearchOffer_Click(sender, e);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxLanguageSettings_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxLanguageSettings_SelectedIndexChanged(sender, e);
        }
    }
}