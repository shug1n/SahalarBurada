using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormOrganizatorGiris : Form
    {

        public FormOrganizatorGiris()
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
            var (ok, msg, org) = KullaniciServisi.OrgGiris(txtGirisEposta.Text.Trim(), txtGirisSifre.Text);
            if (!ok) { lblGirisHata.Text = msg; lblGirisHata.Visible = true; return; }
            Oturum.AktifOrganizator = org; AcOrgPanel();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            lblKayitHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtIsletme.Text) || string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) || string.IsNullOrWhiteSpace(txtEposta.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            { lblKayitHata.Text = "Lütfen tüm alanları doldurun."; lblKayitHata.Visible = true; return; }
            if (txtSifre.Text != txtSifreTekrar.Text) { lblKayitHata.Text = "Şifreler uyuşmuyor."; lblKayitHata.Visible = true; return; }
            if (txtSifre.Text.Length < 6) { lblKayitHata.Text = "Şifre en az 6 karakter."; lblKayitHata.Visible = true; return; }
            var (ok, msg, org) = KullaniciServisi.OrgKayit(txtIsletme.Text.Trim(), txtAd.Text.Trim(), txtSoyad.Text.Trim(), txtEposta.Text.Trim(), txtSifre.Text);
            if (!ok) { lblKayitHata.Text = msg; lblKayitHata.Visible = true; return; }
            Oturum.AktifOrganizator = org; AcOrgPanel();
        }

        private void AcOrgPanel() { var f = new FormOrganizatorPanel(); this.Hide(); f.FormClosed += (s, e) => this.Close(); f.Show(); }
    }
}
