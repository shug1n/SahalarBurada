using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    partial class FormSahaEkle
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            UIHelper.FormAyarla(this, "Yeni Saha Ekle", 700, 780);

            pnlSahaEkleHeader = UIHelper.HeaderPanelOlustur("➕  Yeni Saha Ekle", "Halı saha bilgilerini eksiksiz doldurun");

            pnlSahaEkleScroll = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan, AutoScroll = true };

            int x = 32, y = 18, wF = 636, wH = 295;

            // Saha adı
            pnlSahaEkleScroll.Controls.Add(UIHelper.LblAlan("Saha Adı: *", x, y));
            txtSahaAd = UIHelper.TxtBox(x, y + 26, wF); txtSahaAd.Name = "txtSahaAd";
            pnlSahaEkleScroll.Controls.Add(txtSahaAd);
            y += 72;

            // Adres
            pnlSahaEkleScroll.Controls.Add(UIHelper.LblAlan("Adres: *", x, y));
            txtSahaAdres = UIHelper.TxtBox(x, y + 26, wF); txtSahaAdres.Name = "txtSahaAdres";
            pnlSahaEkleScroll.Controls.Add(txtSahaAdres);
            y += 72;

            // Kapasite & Fiyat
            pnlSahaEkleScroll.Controls.Add(UIHelper.LblAlan("Kapasite (kişi): *", x, y));
            nudKapasite = new NumericUpDown { Name = "nudKapasite", Location = new Point(x, y + 26), Size = new Size(wH, 28), Font = UIHelper.FNormal, Minimum = 2, Maximum = 30, Value = 14 };
            pnlSahaEkleScroll.Controls.Add(nudKapasite);

            pnlSahaEkleScroll.Controls.Add(UIHelper.LblAlan("Fiyat / Saat (₺): *", x + wH + 22, y));
            nudFiyat = new NumericUpDown { Name = "nudFiyat", Location = new Point(x + wH + 22, y + 26), Size = new Size(wH, 28), Font = UIHelper.FNormal, Minimum = 50, Maximum = 9999, Value = 300, Increment = 50 };
            pnlSahaEkleScroll.Controls.Add(nudFiyat);
            y += 75;

            // Günler & Saatler
            pnlSahaEkleScroll.Controls.Add(UIHelper.LblAlan("Müsait Günler: *", x, y));
            clbGunler = new CheckedListBox { Name = "clbGunler", Location = new Point(x, y + 26), Size = new Size(wH, 148), Font = UIHelper.FNormal, CheckOnClick = true, BackColor = System.Drawing.Color.White };
            foreach (var g in new[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" })
                clbGunler.Items.Add(g, true);
            pnlSahaEkleScroll.Controls.Add(clbGunler);

            pnlSahaEkleScroll.Controls.Add(UIHelper.LblAlan("Müsait Saatler: *", x + wH + 22, y));
            clbSaatler = new CheckedListBox { Name = "clbSaatler", Location = new Point(x + wH + 22, y + 26), Size = new Size(wH, 148), Font = UIHelper.FNormal, CheckOnClick = true, BackColor = System.Drawing.Color.White };
            for (int i = 8; i <= 22; i++) clbSaatler.Items.Add(i.ToString("D2") + ":00", true);
            pnlSahaEkleScroll.Controls.Add(clbSaatler);
            y += 195;

            // Açıklama
            pnlSahaEkleScroll.Controls.Add(UIHelper.LblAlan("Açıklama:", x, y));
            txtSahaAciklama = new TextBox { Name = "txtSahaAciklama", Location = new Point(x, y + 26), Size = new Size(wF, 80), Font = UIHelper.FNormal, Multiline = true, BorderStyle = BorderStyle.FixedSingle, BackColor = System.Drawing.Color.White, ScrollBars = ScrollBars.Vertical };
            pnlSahaEkleScroll.Controls.Add(txtSahaAciklama);
            y += 122;

            // Hata & Butonlar
            lblSahaEkleHata = new Label { Name = "lblSahaEkleHata", Location = new Point(x, y), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };
            pnlSahaEkleScroll.Controls.Add(lblSahaEkleHata);
            y += 26;

            btnSahaEkleGeri    = UIHelper.BtnSecondary("← Geri", x, y, 145, 44);          btnSahaEkleGeri.Name    = "btnSahaEkleGeri";
            btnSahaOzetGoster  = UIHelper.BtnPrimary("📄  Form Özetini Görüntüle", x + 160, y, 300, 44); btnSahaOzetGoster.Name  = "btnSahaOzetGoster";
            pnlSahaEkleScroll.Controls.AddRange(new Control[] { lblSahaEkleHata, btnSahaEkleGeri, btnSahaOzetGoster });

            this.Controls.Add(pnlSahaEkleScroll);
            this.Controls.Add(pnlSahaEkleHeader);
            this.ResumeLayout(false);
        }

        private Panel pnlSahaEkleHeader, pnlSahaEkleScroll;
        private System.Windows.Forms.TextBox txtSahaAd, txtSahaAdres, txtSahaAciklama;
        private NumericUpDown nudKapasite, nudFiyat;
        private CheckedListBox clbGunler, clbSaatler;
        private Label lblSahaEkleHata;
        private Button btnSahaEkleGeri, btnSahaOzetGoster;
    }
}
