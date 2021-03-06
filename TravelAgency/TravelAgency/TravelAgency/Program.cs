using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency.Forms;

namespace TravelAgency
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var language = Properties.Settings.Default.Language;
            var value = "";
            if (language == "English")
            {
                value = "en";
            }
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(value);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(value);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

        }
    }
}
