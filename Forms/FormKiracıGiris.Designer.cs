using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    partial class FormKiracıGiris
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            UIHelper.FormAyarla(this, "Kullanıcı Girişi", 540, 590);

            // ── Header ──────────────────────────────────────────────
            pnlHeaderKiraci = UIHelper.HeaderPanelOlustur(
                "👤  Kullanıcı Girişi", "Halı saha kiralamak için giriş yapın veya kayıt olun");

            // ── Tab bar ─────────────────────────────────────────────
            pnlTabBar = new Panel { Location = new Point(0, 95), Size = new Size(540, 50), BackColor = Color.White };
            pnlTabBar.Paint += (s, e) =>
                e.Graphics.DrawLine(new System.Drawing.Pen(UIHelper.CBolme), 0, 49, ((Panel)s).Width, 49);

            btnTabGiris = new Button
            {
                Name = "btnTabGiris", Text = "Giriş Yap",
                Location = new Point(0, 0), Size = new Size(270, 49),
                FlatStyle = FlatStyle.Flat, Font = UIHelper.FNormalKalin, Cursor = Cursors.Hand,
                BackColor = UIHelper.CAna, ForeColor = Color.White
            };
            btnTabGiris.FlatAppearance.BorderSize = 0;

            btnTabKayit = new Button
            {
                Name = "btnTabKayit", Text = "Kayıt Ol",
                Location = new Point(270, 0), Size = new Size(270, 49),
                FlatStyle = FlatStyle.Flat, Font = UIHelper.FNormalKalin, Cursor = Cursors.Hand,
                BackColor = Color.FromArgb(230, 240, 230), ForeColor = UIHelper.CMetin
            };
            btnTabKayit.FlatAppearance.BorderSize = 0;

            pnlTabBar.Controls.AddRange(new Control[] { btnTabGiris, btnTabKayit });

            // ── Giriş paneli ─────────────────────────────────────────
            pnlGiris = new Panel { Name = "pnlGiris", Location = new Point(0, 145), Size = new Size(540, 390), BackColor = UIHelper.CArkaplan };

            lblGirisEpostaLbl = new Label { Text = "E-posta:", Location = new Point(50, 25), Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, AutoSize = true };
            txtGirisEposta    = UIHelper.TxtBox(50, 50, 440);
            txtGirisEposta.Name = "txtGirisEposta";

            lblGirisSifreLbl  = new Label { Text = "Şifre:", Location = new Point(50, 100), Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, AutoSize = true };
            txtGirisSifre     = UIHelper.TxtBox(50, 125, 440, sifre: true);
            txtGirisSifre.Name = "txtGirisSifre";

            lblGirisHata = new Label { Name = "lblGirisHata", Location = new Point(50, 172), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };
            btnGirisYap  = UIHelper.BtnPrimary("Giriş Yap", 50, 198, 440, 48);
            btnGirisYap.Name = "btnGirisYap";
            lblGirisHint = new Label { Text = "Hesabınız yok mu? 'Kayıt Ol' sekmesine tıklayın.", Location = new Point(50, 262), Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik, AutoSize = true };

            pnlGiris.Controls.AddRange(new Control[] { lblGirisEpostaLbl, txtGirisEposta, lblGirisSifreLbl, txtGirisSifre, lblGirisHata, btnGirisYap, lblGirisHint });

            // ── Kayıt paneli ─────────────────────────────────────────
            pnlKayit = new Panel { Name = "pnlKayit", Location = new Point(0, 145), Size = new Size(540, 440), BackColor = UIHelper.CArkaplan, Visible = false };

            lblKayitAdLbl     = new Label { Text = "Ad:",     Location = new Point(50, 18),  Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, AutoSize = true };
            txtKayitAd        = UIHelper.TxtBox(50, 43, 200); txtKayitAd.Name = "txtKayitAd";
            lblKayitSoyadLbl  = new Label { Text = "Soyad:", Location = new Point(270, 18), Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, AutoSize = true };
            txtKayitSoyad     = UIHelper.TxtBox(270, 43, 200); txtKayitSoyad.Name = "txtKayitSoyad";

            lblKayitEpostaLbl = new Label { Text = "E-posta:", Location = new Point(50, 90), Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, AutoSize = true };
            txtKayitEposta    = UIHelper.TxtBox(50, 115, 440); txtKayitEposta.Name = "txtKayitEposta";

            lblKayitSifreLbl  = new Label { Text = "Şifre:", Location = new Point(50, 160), Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, AutoSize = true };
            txtKayitSifre     = UIHelper.TxtBox(50, 185, 440, sifre: true); txtKayitSifre.Name = "txtKayitSifre";

            lblKayitTekrarLbl = new Label { Text = "Şifre Tekrar:", Location = new Point(50, 230), Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, AutoSize = true };
            txtKayitSifreTekrar = UIHelper.TxtBox(50, 255, 440, sifre: true); txtKayitSifreTekrar.Name = "txtKayitSifreTekrar";

            lblKayitHata = new Label { Name = "lblKayitHata", Location = new Point(50, 300), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };
            btnKayitOl   = UIHelper.BtnPrimary("Kayıt Ol", 50, 325, 440, 48); btnKayitOl.Name = "btnKayitOl";

            pnlKayit.Controls.AddRange(new Control[] {
                lblKayitAdLbl, txtKayitAd, lblKayitSoyadLbl, txtKayitSoyad,
                lblKayitEpostaLbl, txtKayitEposta,
                lblKayitSifreLbl, txtKayitSifre,
                lblKayitTekrarLbl, txtKayitSifreTekrar,
                lblKayitHata, btnKayitOl });

            // ── Geri butonu ──────────────────────────────────────────
            btnGeri = UIHelper.BtnSecondary("← Geri", 20, 540, 110, 35);
            btnGeri.Name = "btnGeri";

            // ── Form'a ekle ──────────────────────────────────────────
            this.Controls.Add(pnlHeaderKiraci);
            this.Controls.Add(pnlTabBar);
            this.Controls.Add(pnlGiris);
            this.Controls.Add(pnlKayit);
            this.Controls.Add(btnGeri);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ── Tasarım değişkenleri ─────────────────────────────────────
        private Panel pnlHeaderKiraci, pnlTabBar, pnlGiris, pnlKayit;
        private Button btnTabGiris, btnTabKayit, btnGirisYap, btnKayitOl, btnGeri;
        private Label lblGirisEpostaLbl, lblGirisSifreLbl, lblGirisHata, lblGirisHint;
        private Label lblKayitAdLbl, lblKayitSoyadLbl, lblKayitEpostaLbl;
        private Label lblKayitSifreLbl, lblKayitTekrarLbl, lblKayitHata;
        private System.Windows.Forms.TextBox txtGirisEposta, txtGirisSifre;
        private System.Windows.Forms.TextBox txtKayitAd, txtKayitSoyad, txtKayitEposta, txtKayitSifre, txtKayitSifreTekrar;
    }
}
