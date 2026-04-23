using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormKiracıGiris : Form
    {
        private Panel pnlGiris, pnlKayit;
        private Button btnTabGiris, btnTabKayit;
        private TextBox txtGirisEposta, txtGirisSifre;
        private Label lblGirisHata;
        private TextBox txtKayitAd, txtKayitSoyad, txtKayitEposta, txtKayitSifre, txtKayitSifreTekrar;
        private Label lblKayitHata;
        private Button btnGirisYap, btnKayitOl;

        public FormKiracıGiris()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            UIHelper.FormAyarla(this, "Kullanıcı Girişi", 540, 590);
            this.Controls.Add(UIHelper.HeaderPanelOlustur("👤  Kullanıcı Girişi", "Halı saha kiralamak için giriş yapın veya kayıt olun"));

            // Tab bar
            var tabBar = new Panel { Location = new Point(0, 95), Size = new Size(540, 50), BackColor = Color.White };
            tabBar.Paint += (s, e) => e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 49, tabBar.Width, 49);
            btnTabGiris = TabBtn("Giriş Yap", 0,   true);
            btnTabKayit = TabBtn("Kayıt Ol",  270, false);
            btnTabGiris.Click += (s, e) => TabGoster(true);
            btnTabKayit.Click += (s, e) => TabGoster(false);
            tabBar.Controls.AddRange(new Control[] { btnTabGiris, btnTabKayit });
            this.Controls.Add(tabBar);

            pnlGiris = BuildPnlGiris();
            pnlKayit = BuildPnlKayit();
            pnlKayit.Visible = false;
            this.Controls.Add(pnlGiris);
            this.Controls.Add(pnlKayit);

            var btnGeri = UIHelper.BtnSecondary("← Geri", 20, 540, 110, 35);
            btnGeri.Click += (s, e) => this.Close();
            this.Controls.Add(btnGeri);
        }

        private Button TabBtn(string text, int x, bool aktif)
        {
            var btn = new Button { Text = text, Location = new Point(x, 0), Size = new Size(270, 49), FlatStyle = FlatStyle.Flat, Font = UIHelper.FNormalKalin, Cursor = Cursors.Hand, BackColor = aktif ? UIHelper.CAna : Color.FromArgb(230, 240, 230), ForeColor = aktif ? Color.White : UIHelper.CMetin };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void TabGoster(bool girisTab)
        {
            pnlGiris.Visible = girisTab;
            pnlKayit.Visible = !girisTab;
            btnTabGiris.BackColor = girisTab  ? UIHelper.CAna : Color.FromArgb(230, 240, 230);
            btnTabGiris.ForeColor = girisTab  ? Color.White   : UIHelper.CMetin;
            btnTabKayit.BackColor = !girisTab ? UIHelper.CAna : Color.FromArgb(230, 240, 230);
            btnTabKayit.ForeColor = !girisTab ? Color.White   : UIHelper.CMetin;
        }

        private Panel BuildPnlGiris()
        {
            var p = new Panel { Location = new Point(0, 145), Size = new Size(540, 390), BackColor = UIHelper.CArkaplan };
            p.Controls.Add(UIHelper.LblAlan("E-posta:", 50, 25));
            txtGirisEposta = UIHelper.TxtBox(50, 50, 440); p.Controls.Add(txtGirisEposta);
            p.Controls.Add(UIHelper.LblAlan("Şifre:", 50, 100));
            txtGirisSifre  = UIHelper.TxtBox(50, 125, 440, sifre: true); p.Controls.Add(txtGirisSifre);
            lblGirisHata   = new Label { Location = new Point(50, 172), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false }; p.Controls.Add(lblGirisHata);
            btnGirisYap    = UIHelper.BtnPrimary("Giriş Yap", 50, 198, 440, 48); btnGirisYap.Click += BtnGiris_Click; p.Controls.Add(btnGirisYap);
            p.Controls.Add(UIHelper.LblKucuk("Hesabınız yok mu? 'Kayıt Ol' sekmesine tıklayın.", 50, 262));
            return p;
        }

        private Panel BuildPnlKayit()
        {
            var p = new Panel { Location = new Point(0, 145), Size = new Size(540, 440), BackColor = UIHelper.CArkaplan };
            p.Controls.Add(UIHelper.LblAlan("Ad:", 50, 18));    txtKayitAd       = UIHelper.TxtBox(50,  43, 200); p.Controls.Add(txtKayitAd);
            p.Controls.Add(UIHelper.LblAlan("Soyad:", 270, 18)); txtKayitSoyad   = UIHelper.TxtBox(270, 43, 200); p.Controls.Add(txtKayitSoyad);
            p.Controls.Add(UIHelper.LblAlan("E-posta:", 50, 90)); txtKayitEposta = UIHelper.TxtBox(50, 115, 440); p.Controls.Add(txtKayitEposta);
            p.Controls.Add(UIHelper.LblAlan("Şifre:", 50, 160)); txtKayitSifre  = UIHelper.TxtBox(50, 185, 440, sifre: true); p.Controls.Add(txtKayitSifre);
            p.Controls.Add(UIHelper.LblAlan("Şifre Tekrar:", 50, 230)); txtKayitSifreTekrar = UIHelper.TxtBox(50, 255, 440, sifre: true); p.Controls.Add(txtKayitSifreTekrar);
            lblKayitHata = new Label { Location = new Point(50, 300), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false }; p.Controls.Add(lblKayitHata);
            btnKayitOl   = UIHelper.BtnPrimary("Kayıt Ol", 50, 325, 440, 48); btnKayitOl.Click += BtnKayit_Click; p.Controls.Add(btnKayitOl);
            return p;
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
