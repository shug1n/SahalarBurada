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
            SetupLogic();
        }

        private void SetupLogic()
        {
            var org = Oturum.AktifOrganizator;
            lblHeaderBaslik.Text = $"🏢  {org.IsletmeAdi}";
            lblHeaderAltBaslik.Text = $"Hoş geldiniz, {org.Ad} {org.Soyad}  •  {org.Eposta}";
            
            SahalariYukle();
        }

        private void pnlToolbar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 59, pnlToolbar.Width, 59);
        }

        private void BtnYenile_Click(object sender, EventArgs e) => SahalariYukle();
        private void BtnCikis_Click(object sender, EventArgs e) { Oturum.CikisYap(); this.Close(); }

        private void SahalariYukle()
        {
            var sahalar = SahaServisi.OrganizatorSahalari(Oturum.AktifOrganizator.Id);
            dgvSahalar.Rows.Clear();
            foreach (var s in sahalar)
                dgvSahalar.Rows.Add(s.Ad, s.Adres, s.Kapasite + " kişi", s.FiyatSaat.ToString("N0") + " ₺", s.EklenmeTarihi.ToString("dd.MM.yyyy"));
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
