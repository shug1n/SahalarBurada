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
            Application.Run(new Forms.FormAnaEkran());
        }
    }
}
