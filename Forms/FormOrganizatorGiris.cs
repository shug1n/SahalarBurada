using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormOrganizatorGiris : BaseChildForm
    {

        public FormOrganizatorGiris()
        {
            InitializeComponent();
            this.ClientSize = new Size(1000, 700);
            UIHelper.CenterControlsInCard(this, new Control[] { pnlTabBar, pnlGiris, pnlKayit });
            this.Resize += (s, e) => btnGeri.Location = new Point(30, this.ClientSize.Height - 60);
            btnGeri.Location = new Point(30, this.ClientSize.Height - 60);
            LoadAyarlar();
        }

        private void LoadAyarlar()
        {
            var ayarlar = AyarlarHelper.Yukle();
            txtGirisEposta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtGirisEposta.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var source = new AutoCompleteStringCollection();
            if (ayarlar.OrgOncekiEpostalar != null)
            {
                source.AddRange(ayarlar.OrgOncekiEpostalar.ToArray());
            }
            txtGirisEposta.AutoCompleteCustomSource = source;

            if (ayarlar.OrgBeniHatirla)
            {
                txtGirisEposta.Text = ayarlar.OrgKayitliEposta;
                txtGirisSifre.Text = ayarlar.OrgKayitliSifre;
                chkBeniHatirla.Checked = true;
            }
        }

        private void btnTabGiris_Click(object sender, EventArgs e) => TabGoster(true);
        private void btnTabKayit_Click(object sender, EventArgs e) => TabGoster(false);
        private void BtnGeri_Click(object sender, EventArgs e) { IsBackButtonClicked = true; this.Close(); }

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
            string eposta = txtGirisEposta.Text.Trim();
            var (ok, msg, org) = KullaniciServisi.OrgGiris(eposta, txtGirisSifre.Text);
            if (!ok) { lblGirisHata.Text = msg; lblGirisHata.Visible = true; return; }

            var ayarlar = AyarlarHelper.Yukle();
            if (ayarlar.OrgOncekiEpostalar == null)
            {
                ayarlar.OrgOncekiEpostalar = new List<string>();
            }
            if (!ayarlar.OrgOncekiEpostalar.Contains(eposta))
            {
                ayarlar.OrgOncekiEpostalar.Add(eposta);
            }

            ayarlar.OrgBeniHatirla = chkBeniHatirla.Checked;
            if (chkBeniHatirla.Checked)
            {
                ayarlar.OrgKayitliEposta = eposta;
                ayarlar.OrgKayitliSifre = txtGirisSifre.Text;
            }
            else
            {
                ayarlar.OrgKayitliEposta = "";
                ayarlar.OrgKayitliSifre = "";
            }
            AyarlarHelper.Kaydet(ayarlar);

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

        private void AcOrgPanel() { var f = new FormOrganizatorPanel(); this.Hide(); f.FormClosed += (s, e) => { this.IsBackButtonClicked = true; this.Close(); }; f.Show(); }
    }
}
