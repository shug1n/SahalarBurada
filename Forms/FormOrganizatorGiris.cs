using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormOrganizatorGiris : Form
    {
        private Panel pnlGiris, pnlKayit;
        private Button btnTabGiris, btnTabKayit;
        private TextBox txtGirisEposta, txtGirisSifre;
        private Label lblGirisHata;
        private TextBox txtIsletme, txtAd, txtSoyad, txtEposta, txtSifre, txtSifreTekrar;
        private Label lblKayitHata;

        public FormOrganizatorGiris()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            UIHelper.FormAyarla(this, "Organizatör Girişi", 560, 640);
            this.Controls.Add(UIHelper.HeaderPanelOlustur("🏢  Organizatör Girişi", "İşletme hesabınızla giriş yapın veya kayıt olun"));

            var tabBar = new Panel { Location = new Point(0, 95), Size = new Size(560, 50), BackColor = Color.White };
            tabBar.Paint += (s, e) => e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 49, tabBar.Width, 49);
            btnTabGiris = TabBtn("Giriş Yap", 0,   true);
            btnTabKayit = TabBtn("Kayıt Ol",  280, false);
            btnTabGiris.Click += (s, e) => TabGoster(true);
            btnTabKayit.Click += (s, e) => TabGoster(false);
            tabBar.Controls.AddRange(new Control[] { btnTabGiris, btnTabKayit });
            this.Controls.Add(tabBar);

            pnlGiris = BuildPnlGiris();
            pnlKayit = BuildPnlKayit();
            pnlKayit.Visible = false;
            this.Controls.Add(pnlGiris);
            this.Controls.Add(pnlKayit);

            var btnGeri = UIHelper.BtnSecondary("← Geri", 20, 592, 110, 35);
            btnGeri.Click += (s, e) => this.Close();
            this.Controls.Add(btnGeri);
        }

        private Button TabBtn(string text, int x, bool aktif)
        {
            var btn = new Button { Text = text, Location = new Point(x, 0), Size = new Size(280, 49), FlatStyle = FlatStyle.Flat, Font = UIHelper.FNormalKalin, Cursor = Cursors.Hand, BackColor = aktif ? UIHelper.CAna : Color.FromArgb(230, 240, 230), ForeColor = aktif ? Color.White : UIHelper.CMetin };
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
            var p = new Panel { Location = new Point(0, 145), Size = new Size(560, 390), BackColor = UIHelper.CArkaplan };
            p.Controls.Add(UIHelper.LblAlan("E-posta:", 50, 25));
            txtGirisEposta = UIHelper.TxtBox(50, 50, 460); p.Controls.Add(txtGirisEposta);
            p.Controls.Add(UIHelper.LblAlan("Şifre:", 50, 100));
            txtGirisSifre  = UIHelper.TxtBox(50, 125, 460, sifre: true); p.Controls.Add(txtGirisSifre);
            p.Controls.Add(UIHelper.LblKucuk("Demo: demo@org.com  /  123456", 50, 170));
            lblGirisHata   = new Label { Location = new Point(50, 195), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false }; p.Controls.Add(lblGirisHata);
            var btn = UIHelper.BtnPrimary("Giriş Yap", 50, 220, 460, 48); btn.Click += BtnGiris_Click; p.Controls.Add(btn);
            return p;
        }

        private Panel BuildPnlKayit()
        {
            var p = new Panel { Location = new Point(0, 145), Size = new Size(560, 490), BackColor = UIHelper.CArkaplan };
            p.Controls.Add(UIHelper.LblAlan("İşletme Adı: *", 50, 15)); txtIsletme = UIHelper.TxtBox(50, 40,  460); p.Controls.Add(txtIsletme);
            p.Controls.Add(UIHelper.LblAlan("Ad:",    50,  85));         txtAd      = UIHelper.TxtBox(50, 110, 210); p.Controls.Add(txtAd);
            p.Controls.Add(UIHelper.LblAlan("Soyad:", 280, 85));         txtSoyad   = UIHelper.TxtBox(280,110, 210); p.Controls.Add(txtSoyad);
            p.Controls.Add(UIHelper.LblAlan("E-posta:", 50, 155));       txtEposta  = UIHelper.TxtBox(50, 180, 460); p.Controls.Add(txtEposta);
            p.Controls.Add(UIHelper.LblAlan("Şifre:", 50, 225));         txtSifre   = UIHelper.TxtBox(50, 250, 460, sifre: true); p.Controls.Add(txtSifre);
            p.Controls.Add(UIHelper.LblAlan("Şifre Tekrar:", 50, 295)); txtSifreTekrar = UIHelper.TxtBox(50, 320, 460, sifre: true); p.Controls.Add(txtSifreTekrar);
            lblKayitHata = new Label { Location = new Point(50, 365), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false }; p.Controls.Add(lblKayitHata);
            var btn = UIHelper.BtnPrimary("Kayıt Ol", 50, 390, 460, 48); btn.Click += BtnKayit_Click; p.Controls.Add(btn);
            return p;
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
