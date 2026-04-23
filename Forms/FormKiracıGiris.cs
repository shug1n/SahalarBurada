using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public class FormKiracıGiris : Form
    {
        // Tab simülasyonu
        private Panel pnlGiris, pnlKayit;
        private Button btnTabGiris, btnTabKayit;

        // Giriş alanları
        private TextBox txtGirisEposta, txtGirisSifre;
        private Label lblGirisHata;

        // Kayıt alanları
        private TextBox txtKayitAd, txtKayitSoyad, txtKayitEposta, txtKayitSifre, txtKayitSifreTekrar;
        private Label lblKayitHata;

        public FormKiracıGiris()
        {
            UIHelper.FormAyarla(this, "Kullanıcı Girişi", 540, 590);
            InitUI();
        }

        private void InitUI()
        {
            this.Controls.Add(UIHelper.HeaderPanelOlustur("👤  Kullanıcı Girişi",
                "Halı saha kiralamak için giriş yapın veya kayıt olun"));

            // ── Tab bar ─────────────────────────────────────────────
            var tabBar = new Panel
            {
                Location = new Point(0, 95), Size = new Size(540, 50),
                BackColor = Color.White
            };
            tabBar.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 49, tabBar.Width, 49);

            btnTabGiris = TabBtn("Giriş Yap", 0, true);
            btnTabKayit = TabBtn("Kayıt Ol", 270, false);
            btnTabGiris.Click += (s, e) => TabGoster(true);
            btnTabKayit.Click += (s, e) => TabGoster(false);
            tabBar.Controls.AddRange(new Control[] { btnTabGiris, btnTabKayit });
            this.Controls.Add(tabBar);

            // ── Paneller ────────────────────────────────────────────
            pnlGiris = BuildPnlGiris();
            pnlKayit = BuildPnlKayit();
            pnlKayit.Visible = false;
            this.Controls.Add(pnlGiris);
            this.Controls.Add(pnlKayit);

            // Geri
            var btnGeri = UIHelper.BtnSecondary("← Geri", 20, 540, 110, 35);
            btnGeri.Click += (s, e) => this.Close();
            this.Controls.Add(btnGeri);
        }

        private Button TabBtn(string text, int x, bool aktif)
        {
            var btn = new Button
            {
                Text = text, Location = new Point(x, 0), Size = new Size(270, 49),
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
            var p = new Panel { Location = new Point(0, 145), Size = new Size(540, 390), BackColor = UIHelper.CArkaplan };
            int x = 50, w = 440;

            p.Controls.Add(UIHelper.LblAlan("E-posta:", x, 25));
            txtGirisEposta = UIHelper.TxtBox(x, 50, w);
            p.Controls.Add(txtGirisEposta);

            p.Controls.Add(UIHelper.LblAlan("Şifre:", x, 100));
            txtGirisSifre = UIHelper.TxtBox(x, 125, w, sifre: true);
            p.Controls.Add(txtGirisSifre);

            lblGirisHata = new Label
            {
                Location = new Point(x, 172), AutoSize = true,
                Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false
            };
            p.Controls.Add(lblGirisHata);

            var btnGiris = UIHelper.BtnPrimary("Giriş Yap", x, 198, w, 48);
            btnGiris.Click += BtnGiris_Click;
            p.Controls.Add(btnGiris);

            p.Controls.Add(UIHelper.LblKucuk(
                "Hesabınız yok mu? Üstteki 'Kayıt Ol' sekmesine tıklayın.", x, 262));
            return p;
        }

        private Panel BuildPnlKayit()
        {
            var p = new Panel { Location = new Point(0, 145), Size = new Size(540, 440), BackColor = UIHelper.CArkaplan };
            int x = 50, w = 440, wH = 200;

            p.Controls.Add(UIHelper.LblAlan("Ad:", x, 18));
            txtKayitAd = UIHelper.TxtBox(x, 43, wH);
            p.Controls.Add(txtKayitAd);

            p.Controls.Add(UIHelper.LblAlan("Soyad:", x + wH + 20, 18));
            txtKayitSoyad = UIHelper.TxtBox(x + wH + 20, 43, wH);
            p.Controls.Add(txtKayitSoyad);

            p.Controls.Add(UIHelper.LblAlan("E-posta:", x, 90));
            txtKayitEposta = UIHelper.TxtBox(x, 115, w);
            p.Controls.Add(txtKayitEposta);

            p.Controls.Add(UIHelper.LblAlan("Şifre:", x, 160));
            txtKayitSifre = UIHelper.TxtBox(x, 185, w, sifre: true);
            p.Controls.Add(txtKayitSifre);

            p.Controls.Add(UIHelper.LblAlan("Şifre Tekrar:", x, 230));
            txtKayitSifreTekrar = UIHelper.TxtBox(x, 255, w, sifre: true);
            p.Controls.Add(txtKayitSifreTekrar);

            lblKayitHata = new Label
            {
                Location = new Point(x, 300), AutoSize = true,
                Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false
            };
            p.Controls.Add(lblKayitHata);

            var btnKayit = UIHelper.BtnPrimary("Kayıt Ol", x, 325, w, 48);
            btnKayit.Click += BtnKayit_Click;
            p.Controls.Add(btnKayit);

            return p;
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            lblGirisHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtGirisEposta.Text) || string.IsNullOrWhiteSpace(txtGirisSifre.Text))
            { ShowGirisHata("Lütfen tüm alanları doldurun."); return; }

            var (ok, msg, k) = KullaniciServisi.KiracıGiris(txtGirisEposta.Text.Trim(), txtGirisSifre.Text);
            if (!ok) { ShowGirisHata(msg); return; }

            Oturum.AktifKullanici = k;
            GirisBasarili();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            lblKayitHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtKayitAd.Text) || string.IsNullOrWhiteSpace(txtKayitSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtKayitEposta.Text) || string.IsNullOrWhiteSpace(txtKayitSifre.Text))
            { ShowKayitHata("Lütfen tüm alanları doldurun."); return; }

            if (txtKayitSifre.Text != txtKayitSifreTekrar.Text)
            { ShowKayitHata("Şifreler uyuşmuyor."); return; }

            if (txtKayitSifre.Text.Length < 6)
            { ShowKayitHata("Şifre en az 6 karakter olmalıdır."); return; }

            var (ok, msg, k) = KullaniciServisi.KiracıKayit(
                txtKayitAd.Text.Trim(), txtKayitSoyad.Text.Trim(),
                txtKayitEposta.Text.Trim(), txtKayitSifre.Text);
            if (!ok) { ShowKayitHata(msg); return; }

            Oturum.AktifKullanici = k;
            GirisBasarili();
        }

        private void ShowGirisHata(string msg)  { lblGirisHata.Text = msg; lblGirisHata.Visible = true; }
        private void ShowKayitHata(string msg)  { lblKayitHata.Text = msg; lblKayitHata.Visible = true; }

        private void GirisBasarili()
        {
            var f = new FormSahaAra();
            this.Hide();
            f.FormClosed += (s, e) =>
            {
                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                    this.Close();
                else
                    this.Show();
            };
            f.Show();
        }
    }
}
