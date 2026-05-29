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
        private Label lblTelefonKayit;
        private TextBox txtKayitTelefon;

        public FormOrganizatorGiris()
        {
            InitializeComponent();
            this.ClientSize = new Size(1000, 700);

            // Hide demo info text
            lblDemoNot.Visible = false;

            // Increase pnlKayit height to accommodate the new field
            pnlKayit.Height += 70;

            // Shift controls below Y=150 down by 70 pixels
            foreach (Control c in pnlKayit.Controls)
            {
                if (c.Top >= 150)
                {
                    c.Top += 70;
                }
            }

            // Programmatically add phone number field for organizer registration
            lblTelefonKayit = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(50, 155),
                Name = "lblTelefonKayit",
                Size = new Size(95, 19),
                Text = "Telefon:"
            };

            txtKayitTelefon = new TextBox
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(50, 180),
                Name = "txtKayitTelefon",
                Size = new Size(460, 25),
                TabIndex = 6
            };
            UIHelper.SetPlaceholder(txtKayitTelefon, "Örn: 0532 123 45 67");

            pnlKayit.Controls.Add(lblTelefonKayit);
            pnlKayit.Controls.Add(txtKayitTelefon);

            // Shift controls below Y=345 down by 15 pixels in pnlKayit to add password hint
            pnlKayit.Height += 15;
            foreach (Control c in pnlKayit.Controls)
            {
                if (c.Top >= 345)
                {
                    c.Top += 15;
                }
            }

            // Create password hint label
            var lblSifreNot = new Label
            {
                Text = "ℹ️ Şifre en az 6 karakter içermelidir.",
                Location = new Point(50, 348),
                Size = new Size(440, 16),
                Font = new Font("Segoe UI", 8.25F, FontStyle.Italic),
                ForeColor = Color.DimGray,
                AutoSize = false
            };
            pnlKayit.Controls.Add(lblSifreNot);

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
            if (string.IsNullOrWhiteSpace(txtIsletme.Text) || string.IsNullOrWhiteSpace(txtAd.Text) || 
                string.IsNullOrWhiteSpace(txtSoyad.Text) || string.IsNullOrWhiteSpace(txtEposta.Text) || 
                string.IsNullOrWhiteSpace(txtKayitTelefon.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            { lblKayitHata.Text = "Lütfen tüm alanları doldurun (İşletme adı ve Telefon zorunludur)."; lblKayitHata.Visible = true; return; }
            
            string telefon = txtKayitTelefon.Text.Trim();
            string cleanPhone = telefon.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (!System.Text.RegularExpressions.Regex.IsMatch(cleanPhone, @"^0?5\d{9}$"))
            {
                lblKayitHata.Text = "Lütfen geçerli bir Türkiye cep telefonu numarası giriniz.";
                lblKayitHata.Visible = true;
                return;
            }

            if (txtSifre.Text != txtSifreTekrar.Text) { lblKayitHata.Text = "Şifreler uyuşmuyor."; lblKayitHata.Visible = true; return; }
            if (txtSifre.Text.Length < 6) { lblKayitHata.Text = "Şifre en az 6 karakter."; lblKayitHata.Visible = true; return; }
            
            var (ok, msg, org) = KullaniciServisi.OrgKayit(
                txtIsletme.Text.Trim(), 
                txtAd.Text.Trim(), 
                txtSoyad.Text.Trim(), 
                txtEposta.Text.Trim(), 
                cleanPhone, 
                txtSifre.Text);
            if (!ok) { lblKayitHata.Text = msg; lblKayitHata.Visible = true; return; }
            Oturum.AktifOrganizator = org; AcOrgPanel();
        }

        private void AcOrgPanel() { var f = new FormOrganizatorPanel(); this.Hide(); f.FormClosed += (s, e) => { this.Location = f.Location; this.IsBackButtonClicked = true; this.Close(); }; f.Show(); }
    }
}
