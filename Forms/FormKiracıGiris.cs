using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormKiracıGiris : Form
    {

        public FormKiracıGiris()
        {
            InitializeComponent();
        }

        private void btnTabGiris_Click(object sender, EventArgs e) => TabGoster(true);
        private void btnTabKayit_Click(object sender, EventArgs e) => TabGoster(false);
        private void BtnGeri_Click(object sender, EventArgs e) => this.Close();

        private void pnlTabBar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 49, pnlTabBar.Width, 49);
        }

        private void TabGoster(bool girisTab)
        {
            pnlGiris.Visible = girisTab;
            pnlKayit.Visible = !girisTab;
            btnTabGiris.BackColor = girisTab ? UIHelper.CAna : Color.FromArgb(230, 240, 230);
            btnTabGiris.ForeColor = girisTab ? Color.White : UIHelper.CMetin;
            btnTabKayit.BackColor = !girisTab ? UIHelper.CAna : Color.FromArgb(230, 240, 230);
            btnTabKayit.ForeColor = !girisTab ? Color.White : UIHelper.CMetin;
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            lblGirisHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtGirisEposta.Text) || string.IsNullOrWhiteSpace(txtGirisSifre.Text))
            { lblGirisHata.Text = "Lütfen tüm alanları doldurun."; lblGirisHata.Visible = true; return; }
            var (ok, msg, k) = KullaniciServisi.KiracıGiris(txtGirisEposta.Text.Trim(), txtGirisSifre.Text);
            if (!ok) { lblGirisHata.Text = msg; lblGirisHata.Visible = true; return; }
            Oturum.AktifKullanici = k;
            GirisBasarili();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            lblKayitHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtKayitAd.Text) || string.IsNullOrWhiteSpace(txtKayitSoyad.Text) || string.IsNullOrWhiteSpace(txtKayitEposta.Text) || string.IsNullOrWhiteSpace(txtKayitSifre.Text))
            { lblKayitHata.Text = "Lütfen tüm alanları doldurun."; lblKayitHata.Visible = true; return; }
            if (txtKayitSifre.Text != txtKayitSifreTekrar.Text) { lblKayitHata.Text = "Şifreler uyuşmuyor."; lblKayitHata.Visible = true; return; }
            if (txtKayitSifre.Text.Length < 6) { lblKayitHata.Text = "Şifre en az 6 karakter."; lblKayitHata.Visible = true; return; }
            var (ok, msg, k) = KullaniciServisi.KiracıKayit(txtKayitAd.Text.Trim(), txtKayitSoyad.Text.Trim(), txtKayitEposta.Text.Trim(), txtKayitSifre.Text);
            if (!ok) { lblKayitHata.Text = msg; lblKayitHata.Visible = true; return; }
            Oturum.AktifKullanici = k;
            GirisBasarili();
        }

        private void GirisBasarili()
        {
            var f = new FormSahaAra();
            this.Hide();
            f.FormClosed += (s, e) => { if (f.DialogResult == System.Windows.Forms.DialogResult.OK) this.Close(); else this.Show(); };
            f.Show();
        }
    }
}
