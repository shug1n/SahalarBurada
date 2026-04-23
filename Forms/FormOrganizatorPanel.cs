using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormOrganizatorPanel : Form
    {
        public FormOrganizatorPanel()
        {
            InitializeComponent();
            btnYeniSaha.Click  += BtnYeniSaha_Click;
            btnYenile.Click    += (s, e) => SahalariYukle();
            btnCikisYap.Click  += (s, e) => { Oturum.CikisYap(); this.Close(); };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var org = Oturum.AktifOrganizator;
            pnlOrgPanelHeader.Controls.Clear();
            var h = UIHelper.HeaderPanelOlustur(
                $"🏢  {org.IsletmeAdi}",
                $"Hoş geldiniz, {org.Ad} {org.Soyad}  •  {org.Eposta}");
            foreach (Control c in h.Controls)
                pnlOrgPanelHeader.Controls.Add(c);
            pnlOrgPanelHeader.BackColor = h.BackColor;
            SahalariYukle();
        }

        private void SahalariYukle()
        {
            var sahalar = SahaServisi.OrganizatorSahalari(Oturum.AktifOrganizator.Id);
            dgvSahalar.Rows.Clear();
            foreach (var s in sahalar)
                dgvSahalar.Rows.Add(s.Ad, s.Adres, s.Kapasite + " kişi",
                    s.FiyatSaat.ToString("N0") + " ₺", s.EklenmeTarihi.ToString("dd.MM.yyyy"));
            lblSahaCount.Text = sahalar.Count > 0
                ? $"Toplam {sahalar.Count} saha kayıtlı"
                : "Henüz saha eklenmemiş. 'Yeni Saha Ekle' butonu ile başlayın.";
        }

        private void BtnYeniSaha_Click(object sender, EventArgs e)
        {
            var f = new FormSahaEkle();
            this.Hide();
            f.FormClosed += (s, ev) => { this.Show(); SahalariYukle(); };
            f.Show();
        }
    }
}
