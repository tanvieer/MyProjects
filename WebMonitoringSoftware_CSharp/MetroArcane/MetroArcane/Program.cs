using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroArcane
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
            Application.SetCompatibleTextRenderingDefault(false);
            if(DbMethod.DbMethods.CheckRegistration())
            {
                Application.Run(new RegistrationForm());
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}
