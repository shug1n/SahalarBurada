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
            Application.Run(new Forms.FormAnaEkran());
        }
    }
}
