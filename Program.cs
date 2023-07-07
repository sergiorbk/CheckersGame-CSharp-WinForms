using System;
using System.Windows.Forms;

namespace Checkers
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

            MainMenuForm mainMenuForm = new MainMenuForm();

            Application.Run(mainMenuForm);
            
        }
    }
}