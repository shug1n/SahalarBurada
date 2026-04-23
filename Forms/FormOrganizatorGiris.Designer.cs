using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    partial class FormOrganizatorGiris
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            UIHelper.FormAyarla(this, "Organizatör Girişi", 560, 640);

            pnlOrgHeader = UIHelper.HeaderPanelOlustur("🏢  Organizatör Girişi", "İşletme hesabınızla giriş yapın veya kayıt olun");

            // Tab bar
            pnlOrgTabBar = new Panel { Location = new Point(0, 95), Size = new Size(560, 50), BackColor = Color.White };
            pnlOrgTabBar.Paint += (s, e) => e.Graphics.DrawLine(new System.Drawing.Pen(UIHelper.CBolme), 0, 49, ((Panel)s).Width, 49);

            btnTabGiris = new Button { Name = "btnTabGiris", Text = "Giriş Yap", Location = new Point(0, 0), Size = new Size(280, 49), FlatStyle = FlatStyle.Flat, Font = UIHelper.FNormalKalin, Cursor = Cursors.Hand, BackColor = UIHelper.CAna, ForeColor = Color.White };
            btnTabGiris.FlatAppearance.BorderSize = 0;
            btnTabKayit = new Button { Name = "btnTabKayit", Text = "Kayıt Ol",  Location = new Point(280, 0), Size = new Size(280, 49), FlatStyle = FlatStyle.Flat, Font = UIHelper.FNormalKalin, Cursor = Cursors.Hand, BackColor = Color.FromArgb(230, 240, 230), ForeColor = UIHelper.CMetin };
            btnTabKayit.FlatAppearance.BorderSize = 0;
            pnlOrgTabBar.Controls.AddRange(new Control[] { btnTabGiris, btnTabKayit });

            // Giriş paneli
            pnlOrgGiris = new Panel { Name = "pnlOrgGiris", Location = new Point(0, 145), Size = new Size(560, 390), BackColor = UIHelper.CArkaplan };
            pnlOrgGiris.Controls.Add(UIHelper.LblAlan("E-posta:", 50, 25));
            txtOrgGirisEposta = UIHelper.TxtBox(50, 50, 460); txtOrgGirisEposta.Name = "txtOrgGirisEposta";
            pnlOrgGiris.Controls.Add(txtOrgGirisEposta);
            pnlOrgGiris.Controls.Add(UIHelper.LblAlan("Şifre:", 50, 100));
            txtOrgGirisSifre  = UIHelper.TxtBox(50, 125, 460, sifre: true); txtOrgGirisSifre.Name = "txtOrgGirisSifre";
            pnlOrgGiris.Controls.Add(txtOrgGirisSifre);
            pnlOrgGiris.Controls.Add(UIHelper.LblKucuk("Demo: demo@org.com  /  123456", 50, 170));
            lblOrgGirisHata = new Label { Name = "lblOrgGirisHata", Location = new Point(50, 195), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };
            pnlOrgGiris.Controls.Add(lblOrgGirisHata);
            btnOrgGirisYap  = UIHelper.BtnPrimary("Giriş Yap", 50, 220, 460, 48); btnOrgGirisYap.Name = "btnOrgGirisYap";
            pnlOrgGiris.Controls.Add(btnOrgGirisYap);

            // Kayıt paneli
            pnlOrgKayit = new Panel { Name = "pnlOrgKayit", Location = new Point(0, 145), Size = new Size(560, 490), BackColor = UIHelper.CArkaplan, Visible = false };
            pnlOrgKayit.Controls.Add(UIHelper.LblAlan("İşletme Adı: *", 50, 15));
            txtOrgIsletme = UIHelper.TxtBox(50, 40, 460); txtOrgIsletme.Name = "txtOrgIsletme";
            pnlOrgKayit.Controls.Add(txtOrgIsletme);
            pnlOrgKayit.Controls.Add(UIHelper.LblAlan("Ad:", 50, 85));
            txtOrgAd    = UIHelper.TxtBox(50, 110, 210); txtOrgAd.Name = "txtOrgAd";
            pnlOrgKayit.Controls.Add(txtOrgAd);
            pnlOrgKayit.Controls.Add(UIHelper.LblAlan("Soyad:", 280, 85));
            txtOrgSoyad = UIHelper.TxtBox(280, 110, 210); txtOrgSoyad.Name = "txtOrgSoyad";
            pnlOrgKayit.Controls.Add(txtOrgSoyad);
            pnlOrgKayit.Controls.Add(UIHelper.LblAlan("E-posta:", 50, 155));
            txtOrgEposta = UIHelper.TxtBox(50, 180, 460); txtOrgEposta.Name = "txtOrgEposta";
            pnlOrgKayit.Controls.Add(txtOrgEposta);
            pnlOrgKayit.Controls.Add(UIHelper.LblAlan("Şifre:", 50, 225));
            txtOrgSifre  = UIHelper.TxtBox(50, 250, 460, sifre: true); txtOrgSifre.Name = "txtOrgSifre";
            pnlOrgKayit.Controls.Add(txtOrgSifre);
            pnlOrgKayit.Controls.Add(UIHelper.LblAlan("Şifre Tekrar:", 50, 295));
            txtOrgSifreTekrar = UIHelper.TxtBox(50, 320, 460, sifre: true); txtOrgSifreTekrar.Name = "txtOrgSifreTekrar";
            pnlOrgKayit.Controls.Add(txtOrgSifreTekrar);
            lblOrgKayitHata = new Label { Name = "lblOrgKayitHata", Location = new Point(50, 365), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };
            pnlOrgKayit.Controls.Add(lblOrgKayitHata);
            btnOrgKayitOl   = UIHelper.BtnPrimary("Kayıt Ol", 50, 390, 460, 48); btnOrgKayitOl.Name = "btnOrgKayitOl";
            pnlOrgKayit.Controls.Add(btnOrgKayitOl);

            btnOrgGeri = UIHelper.BtnSecondary("← Geri", 20, 592, 110, 35); btnOrgGeri.Name = "btnOrgGeri";

            this.Controls.Add(pnlOrgHeader);
            this.Controls.Add(pnlOrgTabBar);
            this.Controls.Add(pnlOrgGiris);
            this.Controls.Add(pnlOrgKayit);
            this.Controls.Add(btnOrgGeri);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Panel pnlOrgHeader, pnlOrgTabBar, pnlOrgGiris, pnlOrgKayit;
        private Button btnTabGiris, btnTabKayit, btnOrgGirisYap, btnOrgKayitOl, btnOrgGeri;
        private Label lblOrgGirisHata, lblOrgKayitHata;
        private System.Windows.Forms.TextBox txtOrgGirisEposta, txtOrgGirisSifre;
        private System.Windows.Forms.TextBox txtOrgIsletme, txtOrgAd, txtOrgSoyad, txtOrgEposta, txtOrgSifre, txtOrgSifreTekrar;
    }
}
