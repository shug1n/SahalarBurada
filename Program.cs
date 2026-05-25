using System;
using System.Windows.Forms;

namespace SahalarBurada
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SahalarBurada.Helpers.TrayManager.Initialize();
            SahalarBurada.Services.DatabaseServisi.InitializeDatabase();
            SahalarBurada.Services.DatabaseServisi.CleanOldReservations();
            Application.Run(new Forms.FormAnaEkran());
        }
    }
}
