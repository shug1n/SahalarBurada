using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormKiracıGiris : BaseChildForm
    {

        public FormKiracıGiris()
        {
            InitializeComponent();
            this.ClientSize = new Size(1000, 700);

            // Shift controls below Y=210 down by 15 pixels in pnlKayit to add password hint
            pnlKayit.Height += 15;
            foreach (Control c in pnlKayit.Controls)
            {
                if (c.Top >= 210)
                {
                    c.Top += 15;
                }
            }

            // Create password hint label
            var lblSifreNot = new Label
            {
                Text = "ℹ️ Şifre en az 6 karakter içermelidir.",
                Location = new Point(50, 213),
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
            if (ayarlar.KiraciOncekiEpostalar != null)
            {
                source.AddRange(ayarlar.KiraciOncekiEpostalar.ToArray());
            }
            txtGirisEposta.AutoCompleteCustomSource = source;

            if (ayarlar.KiraciBeniHatirla)
            {
                txtGirisEposta.Text = ayarlar.KiraciKayitliEposta;
                txtGirisSifre.Text = ayarlar.KiraciKayitliSifre;
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
            var (ok, msg, k) = KullaniciServisi.KiracıGiris(eposta, txtGirisSifre.Text);
            if (!ok) { lblGirisHata.Text = msg; lblGirisHata.Visible = true; return; }

            var ayarlar = AyarlarHelper.Yukle();
            if (ayarlar.KiraciOncekiEpostalar == null)
            {
                ayarlar.KiraciOncekiEpostalar = new List<string>();
            }
            if (!ayarlar.KiraciOncekiEpostalar.Contains(eposta))
            {
                ayarlar.KiraciOncekiEpostalar.Add(eposta);
            }

            ayarlar.KiraciBeniHatirla = chkBeniHatirla.Checked;
            if (chkBeniHatirla.Checked)
            {
                ayarlar.KiraciKayitliEposta = eposta;
                ayarlar.KiraciKayitliSifre = txtGirisSifre.Text;
            }
            else
            {
                ayarlar.KiraciKayitliEposta = "";
                ayarlar.KiraciKayitliSifre = "";
            }
            AyarlarHelper.Kaydet(ayarlar);

            Oturum.AktifKullanici = k;
            GirisBasarili();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            lblKayitHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtKayitAd.Text) || string.IsNullOrWhiteSpace(txtKayitSoyad.Text) || 
                string.IsNullOrWhiteSpace(txtKayitEposta.Text) || string.IsNullOrWhiteSpace(txtKayitTelefon.Text) || 
                string.IsNullOrWhiteSpace(txtKayitSifre.Text))
            { 
                lblKayitHata.Text = "Lütfen tüm alanları doldurun (Telefon zorunludur)."; 
                lblKayitHata.Visible = true; 
                return; 
            }
            string telefon = txtKayitTelefon.Text.Trim();
            string cleanPhone = telefon.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (!System.Text.RegularExpressions.Regex.IsMatch(cleanPhone, @"^0?5\d{9}$"))
            {
                lblKayitHata.Text = "Lütfen geçerli bir Türkiye cep telefonu numarası giriniz.";
                lblKayitHata.Visible = true;
                return;
            }

            if (txtKayitSifre.Text != txtKayitSifreTekrar.Text) { lblKayitHata.Text = "Şifreler uyuşmuyor."; lblKayitHata.Visible = true; return; }
            if (txtKayitSifre.Text.Length < 6) { lblKayitHata.Text = "Şifre en az 6 karakter."; lblKayitHata.Visible = true; return; }
            
            var (ok, msg, k) = KullaniciServisi.KiracıKayit(
                txtKayitAd.Text.Trim(), 
                txtKayitSoyad.Text.Trim(), 
                txtKayitEposta.Text.Trim(), 
                cleanPhone, 
                txtKayitSifre.Text);

            if (!ok) { lblKayitHata.Text = msg; lblKayitHata.Visible = true; return; }
            Oturum.AktifKullanici = k;
            GirisBasarili();
        }

        private void GirisBasarili()
        {
            var f = new FormKullaniciPanel();
            this.Hide();
            f.FormClosed += (s, e) => { this.Location = f.Location; this.IsBackButtonClicked = true; this.Close(); };
            f.Show();
        }
    }
}
