using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public class FormOrganizatorGiris : Form
    {
        private Panel pnlGiris, pnlKayit;
        private Button btnTabGiris, btnTabKayit;

        private TextBox txtGirisEposta, txtGirisSifre;
        private Label lblGirisHata;

        private TextBox txtKayitIsletme, txtKayitAd, txtKayitSoyad,
                        txtKayitEposta, txtKayitSifre, txtKayitSifreTekrar;
        private Label lblKayitHata;

        public FormOrganizatorGiris()
        {
            UIHelper.FormAyarla(this, "Organizatör Girişi", 560, 640);
            InitUI();
        }

        private void InitUI()
        {
            this.Controls.Add(UIHelper.HeaderPanelOlustur("🏢  Organizatör Girişi",
                "İşletme hesabınızla giriş yapın veya kayıt olun"));

            var tabBar = new Panel
            {
                Location = new Point(0, 95), Size = new Size(560, 50), BackColor = Color.White
            };
            tabBar.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 49, tabBar.Width, 49);

            btnTabGiris = TabBtn("Giriş Yap", 0, true);
            btnTabKayit = TabBtn("Kayıt Ol", 280, false);
            btnTabGiris.Click += (s, e) => TabGoster(true);
            btnTabKayit.Click += (s, e) => TabGoster(false);
            tabBar.Controls.AddRange(new Control[] { btnTabGiris, btnTabKayit });
            this.Controls.Add(tabBar);

            pnlGiris = BuildPnlGiris();
            pnlKayit = BuildPnlKayit();
            pnlKayit.Visible = false;
            this.Controls.Add(pnlGiris);
            this.Controls.Add(pnlKayit);

            var btnGeri = UIHelper.BtnSecondary("← Geri", 20, 590, 110, 35);
            btnGeri.Click += (s, e) => this.Close();
            this.Controls.Add(btnGeri);
        }

        private Button TabBtn(string text, int x, bool aktif)
        {
            var btn = new Button
            {
                Text = text, Location = new Point(x, 0), Size = new Size(280, 49),
                FlatStyle = FlatStyle.Flat, Font = UIHelper.FNormalKalin, Cursor = Cursors.Hand,
                BackColor = aktif ? UIHelper.CAna : Color.FromArgb(230, 240, 230),
                ForeColor = aktif ? Color.White : UIHelper.CMetin
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
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

        private Panel BuildPnlGiris()
        {
            var p = new Panel { Location = new Point(0, 145), Size = new Size(560, 390), BackColor = UIHelper.CArkaplan };
            int x = 50, w = 460;

            p.Controls.Add(UIHelper.LblAlan("E-posta:", x, 25));
            txtGirisEposta = UIHelper.TxtBox(x, 50, w);
            p.Controls.Add(txtGirisEposta);

            p.Controls.Add(UIHelper.LblAlan("Şifre:", x, 100));
            txtGirisSifre = UIHelper.TxtBox(x, 125, w, sifre: true);
            p.Controls.Add(txtGirisSifre);

            p.Controls.Add(UIHelper.LblKucuk("Demo kullanıcı: demo@org.com  /  123456", x, 170));

            lblGirisHata = new Label
            {
                Location = new Point(x, 195), AutoSize = true,
                Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false
            };
            p.Controls.Add(lblGirisHata);

            var btn = UIHelper.BtnPrimary("Giriş Yap", x, 220, w, 48);
            btn.Click += BtnGiris_Click;
            p.Controls.Add(btn);
            return p;
        }

        private Panel BuildPnlKayit()
        {
            var p = new Panel { Location = new Point(0, 145), Size = new Size(560, 490), BackColor = UIHelper.CArkaplan };
            int x = 50, wF = 460, wH = 210;

            p.Controls.Add(UIHelper.LblAlan("İşletme Adı: *", x, 15));
            txtKayitIsletme = UIHelper.TxtBox(x, 40, wF);
            p.Controls.Add(txtKayitIsletme);

            p.Controls.Add(UIHelper.LblAlan("Ad:", x, 85));
            txtKayitAd = UIHelper.TxtBox(x, 110, wH);
            p.Controls.Add(txtKayitAd);

            p.Controls.Add(UIHelper.LblAlan("Soyad:", x + wH + 30, 85));
            txtKayitSoyad = UIHelper.TxtBox(x + wH + 30, 110, wH);
            p.Controls.Add(txtKayitSoyad);

            p.Controls.Add(UIHelper.LblAlan("E-posta:", x, 155));
            txtKayitEposta = UIHelper.TxtBox(x, 180, wF);
            p.Controls.Add(txtKayitEposta);

            p.Controls.Add(UIHelper.LblAlan("Şifre:", x, 225));
            txtKayitSifre = UIHelper.TxtBox(x, 250, wF, sifre: true);
            p.Controls.Add(txtKayitSifre);

            p.Controls.Add(UIHelper.LblAlan("Şifre Tekrar:", x, 295));
            txtKayitSifreTekrar = UIHelper.TxtBox(x, 320, wF, sifre: true);
            p.Controls.Add(txtKayitSifreTekrar);

            lblKayitHata = new Label
            {
                Location = new Point(x, 365), AutoSize = true,
                Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false
            };
            p.Controls.Add(lblKayitHata);

            var btn = UIHelper.BtnPrimary("Kayıt Ol", x, 390, wF, 48);
            btn.Click += BtnKayit_Click;
            p.Controls.Add(btn);
            return p;
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            lblGirisHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtGirisEposta.Text) || string.IsNullOrWhiteSpace(txtGirisSifre.Text))
            { lblGirisHata.Text = "Lütfen tüm alanları doldurun."; lblGirisHata.Visible = true; return; }

            var (ok, msg, org) = KullaniciServisi.OrgGiris(txtGirisEposta.Text.Trim(), txtGirisSifre.Text);
            if (!ok) { lblGirisHata.Text = msg; lblGirisHata.Visible = true; return; }

            Oturum.AktifOrganizator = org;
            AcOrgPanel();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            lblKayitHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtKayitIsletme.Text) || string.IsNullOrWhiteSpace(txtKayitAd.Text) ||
                string.IsNullOrWhiteSpace(txtKayitSoyad.Text)   || string.IsNullOrWhiteSpace(txtKayitEposta.Text) ||
                string.IsNullOrWhiteSpace(txtKayitSifre.Text))
            { lblKayitHata.Text = "Lütfen tüm alanları doldurun."; lblKayitHata.Visible = true; return; }

            if (txtKayitSifre.Text != txtKayitSifreTekrar.Text)
            { lblKayitHata.Text = "Şifreler uyuşmuyor."; lblKayitHata.Visible = true; return; }

            if (txtKayitSifre.Text.Length < 6)
            { lblKayitHata.Text = "Şifre en az 6 karakter olmalıdır."; lblKayitHata.Visible = true; return; }

            var (ok, msg, org) = KullaniciServisi.OrgKayit(
                txtKayitIsletme.Text.Trim(), txtKayitAd.Text.Trim(),
                txtKayitSoyad.Text.Trim(),   txtKayitEposta.Text.Trim(), txtKayitSifre.Text);
            if (!ok) { lblKayitHata.Text = msg; lblKayitHata.Visible = true; return; }

            Oturum.AktifOrganizator = org;
            AcOrgPanel();
        }

        private void AcOrgPanel()
        {
            var f = new FormOrganizatorPanel();
            this.Hide();
            f.FormClosed += (s, e) => this.Close(); // her durumda AnaEkran'a dön
            f.Show();
        }
    }
}
