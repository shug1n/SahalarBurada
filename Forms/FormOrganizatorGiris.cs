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
            btnTabGiris.Click += (s, e) => TabGoster(true);
            btnTabKayit.Click += (s, e) => TabGoster(false);
            btnOrgGirisYap.Click += BtnGiris_Click;
            btnOrgKayitOl.Click  += BtnKayit_Click;
            btnOrgGeri.Click     += (s, e) => this.Close();
        }

        private void TabGoster(bool girisTab)
        {
            pnlOrgGiris.Visible = girisTab;
            pnlOrgKayit.Visible = !girisTab;
            btnTabGiris.BackColor = girisTab  ? UIHelper.CAna : Color.FromArgb(230, 240, 230);
            btnTabGiris.ForeColor = girisTab  ? Color.White   : UIHelper.CMetin;
            btnTabKayit.BackColor = !girisTab ? UIHelper.CAna : Color.FromArgb(230, 240, 230);
            btnTabKayit.ForeColor = !girisTab ? Color.White   : UIHelper.CMetin;
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            lblOrgGirisHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtOrgGirisEposta.Text) || string.IsNullOrWhiteSpace(txtOrgGirisSifre.Text))
            { lblOrgGirisHata.Text = "Lütfen tüm alanları doldurun."; lblOrgGirisHata.Visible = true; return; }

            var (ok, msg, org) = KullaniciServisi.OrgGiris(txtOrgGirisEposta.Text.Trim(), txtOrgGirisSifre.Text);
            if (!ok) { lblOrgGirisHata.Text = msg; lblOrgGirisHata.Visible = true; return; }

            Oturum.AktifOrganizator = org;
            AcOrgPanel();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            lblOrgKayitHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtOrgIsletme.Text) || string.IsNullOrWhiteSpace(txtOrgAd.Text) ||
                string.IsNullOrWhiteSpace(txtOrgSoyad.Text)   || string.IsNullOrWhiteSpace(txtOrgEposta.Text) ||
                string.IsNullOrWhiteSpace(txtOrgSifre.Text))
            { lblOrgKayitHata.Text = "Lütfen tüm alanları doldurun."; lblOrgKayitHata.Visible = true; return; }

            if (txtOrgSifre.Text != txtOrgSifreTekrar.Text)
            { lblOrgKayitHata.Text = "Şifreler uyuşmuyor."; lblOrgKayitHata.Visible = true; return; }
            if (txtOrgSifre.Text.Length < 6)
            { lblOrgKayitHata.Text = "Şifre en az 6 karakter."; lblOrgKayitHata.Visible = true; return; }

            var (ok, msg, org) = KullaniciServisi.OrgKayit(
                txtOrgIsletme.Text.Trim(), txtOrgAd.Text.Trim(),
                txtOrgSoyad.Text.Trim(), txtOrgEposta.Text.Trim(), txtOrgSifre.Text);
            if (!ok) { lblOrgKayitHata.Text = msg; lblOrgKayitHata.Visible = true; return; }

            Oturum.AktifOrganizator = org;
            AcOrgPanel();
        }

        private void AcOrgPanel()
        {
            var f = new FormOrganizatorPanel();
            this.Hide();
            f.FormClosed += (s, e) => this.Close();
            f.Show();
        }
    }
}
