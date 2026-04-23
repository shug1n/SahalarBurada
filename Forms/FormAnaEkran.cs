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

            // Buton olaylarını bağla
            btnMacAra.Click      += (s, e) => NavSahaAra();
            btnKiraciGiris.Click += (s, e) => NavKiracıGiris();
            btnOrgGiris.Click    += (s, e) => NavOrgGiris();
        }

        // ── Çizim olayları ───────────────────────────────────────────
        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (var br = new LinearGradientBrush(pnlHeader.ClientRectangle,
                Color.FromArgb(18, 62, 22), Color.FromArgb(46, 125, 50),
                LinearGradientMode.Horizontal))
                e.Graphics.FillRectangle(br, pnlHeader.ClientRectangle);
        }

        private void PnlKart_Paint(object sender, PaintEventArgs e)
        {
            var p = (Panel)sender;
            using (var pen = new System.Drawing.Pen(UIHelper.CBolme, 1))
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }

        // ── Navigasyon ───────────────────────────────────────────────
        private void NavSahaAra()
        {
            var f = new FormSahaAra();
            this.Hide();
            f.FormClosed += (s, e) => this.Show();
            f.Show();
        }

        private void NavKiracıGiris()
        {
            var f = new FormKiracıGiris();
            this.Hide();
            f.FormClosed += (s, e) => this.Show();
            f.Show();
        }

        private void NavOrgGiris()
        {
            var f = new FormOrganizatorGiris();
            this.Hide();
            f.FormClosed += (s, e) => this.Show();
            f.Show();
        }
    }
}
