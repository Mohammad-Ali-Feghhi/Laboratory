using System;
using System.Threading;
using System.Windows.Forms;
using Laboratory.Forms;
using Laboratory.Forms.Doctors;
using Laboratory.Forms.Employees;
using Laboratory.Forms.Patients;
using Laboratory.Forms.Tests;

namespace Laboratory
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("fa-IR");
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
