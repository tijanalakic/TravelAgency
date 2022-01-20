using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.Forms
{
    public partial class LoginForm : Form
    {
        List<Control> buttons;
        List<Control> textboxes;
        public static user user;
        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();

        }




        void Initialize_Add()
        {

            buttons = new List<Control>();
            textboxes = new List<Control>();

            buttons.Add(buttonLogin);

            textboxes.Add(textBoxUsername);
            textboxes.Add(textBoxPassword);

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
            pictureBox3.BackColor = (this.BackColor == Color.MidnightBlue) ? Color.RoyalBlue : back;
            
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            Initialize_Add();
            comboBoxThemeSettings.SelectedItem = Properties.Settings.Default.Theme;
            comboBoxLanguageSettings.SelectedItem = Properties.Settings.Default.Language;

        }



        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text; 
            if(username=="" || password == "")
            {
                MessageBox.Show("Niste unijeli kredencijale!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                using(TravelAgencyDb ctx=new TravelAgencyDb())
                {
                     user = (from u in ctx.users where u.username == username && u.password == password select u).FirstOrDefault();
                    if (user != null)
                    {
                        if (user.isActive) {
                            this.Hide();
                            MainForm forma = new MainForm();
                            forma.ShowDialog();
                            this.Close();

                        }
                        else {
                            MessageBox.Show("Vaš nalog je deaktiviran!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Niste unijeli validne kredencijale!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
         
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(sender, e);
            }
        }

        private void comboBoxThemeSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxThemeSettings.Text == "PaleVioletRed")
            {
                ApplyTheme(Color.FromArgb(205, 94, 119), Color.FromArgb(100, 12, 60), Color.FromArgb(205, 94, 119), Color.FromArgb(205, 94, 119), Color.Azure);
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
                ComponentResourceManager resources = new ComponentResourceManager(typeof(LoginForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }

           
            
        }

        private void comboBoxLanguageSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = comboBoxLanguageSettings.SelectedItem.ToString();
            if (lang == "English") {
                ChangeLanguage("en");
                Properties.Settings.Default.Language = lang;
                Properties.Settings.Default.Save();
            }
            else
            {
                ChangeLanguage("");
                Properties.Settings.Default.Language = lang;
                Properties.Settings.Default.Save();
            }
           
        }
    }
}
