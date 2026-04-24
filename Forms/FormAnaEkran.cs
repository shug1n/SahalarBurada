using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    public partial class FormAnaEkran : Form
    {
        public FormAnaEkran()
        {
            InitializeComponent();
        }


        private void NavSahaAra()     { var f = new FormSahaAra();          this.Hide(); f.FormClosed += (s, e) => this.Show(); f.Show(); }
        private void NavKiracıGiris() { var f = new FormKiracıGiris();      this.Hide(); f.FormClosed += (s, e) => this.Show(); f.Show(); }
        private void NavOrgGiris()    { var f = new FormOrganizatorGiris(); this.Hide(); f.FormClosed += (s, e) => this.Show(); f.Show(); }
    }
}
