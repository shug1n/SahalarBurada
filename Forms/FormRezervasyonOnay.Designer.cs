using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    partial class FormRezervasyonOnay
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            UIHelper.FormAyarla(this, "Rezervasyon Onayı", 640, 600);

            pnlResHeader = UIHelper.HeaderPanelOlustur("✅  Rezervasyon Onayı", "Bilgileri kontrol edin ve onaylayın");

            // Scroll alanı (Dock.Fill — otomatik boyut)
            pnlResScroll = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan, AutoScroll = true };

            int x = 35, y = 18;

            // Detay kartı
            pnlResDetay = UIHelper.KartPanel(x, y, 565, 192);
            pnlResDetay.Controls.Add(new Label { Text = "📋 Rezervasyon Detayları", Font = UIHelper.FAltBaslik, ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(16, 12) });

            int iy = 48;
            void InfoRow(string lbl, out Label val)
            {
                pnlResDetay.Controls.Add(new Label { Text = lbl, Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, Location = new Point(16, iy), Size = new Size(125, 22) });
                val = new Label { Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(145, iy) };
                pnlResDetay.Controls.Add(val);
                iy += 26;
            }
            pnlResDetay.Controls.Add(new Label { Text = "⚽ Saha:",   Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, Location = new Point(16, iy), Size = new Size(125, 22) });
            lblResDetaySaha  = new Label { Name = "lblResDetaySaha",  Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(145, iy) }; pnlResDetay.Controls.Add(lblResDetaySaha); iy += 26;
            pnlResDetay.Controls.Add(new Label { Text = "📍 Adres:",  Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, Location = new Point(16, iy), Size = new Size(125, 22) });
            lblResDetayAdres = new Label { Name = "lblResDetayAdres", Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(145, iy) }; pnlResDetay.Controls.Add(lblResDetayAdres); iy += 26;
            pnlResDetay.Controls.Add(new Label { Text = "📅 Tarih:",  Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, Location = new Point(16, iy), Size = new Size(125, 22) });
            lblResDetayTarih = new Label { Name = "lblResDetayTarih", Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(145, iy) }; pnlResDetay.Controls.Add(lblResDetayTarih); iy += 26;
            pnlResDetay.Controls.Add(new Label { Text = "🕐 Saat:",   Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, Location = new Point(16, iy), Size = new Size(125, 22) });
            lblResDetaySaat  = new Label { Name = "lblResDetaySaat",  Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(145, iy) }; pnlResDetay.Controls.Add(lblResDetaySaat); iy += 26;
            pnlResDetay.Controls.Add(new Label { Text = "💰 Fiyat:",  Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, Location = new Point(16, iy), Size = new Size(125, 22) });
            lblResDetayFiyat = new Label { Name = "lblResDetayFiyat", Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(145, iy) }; pnlResDetay.Controls.Add(lblResDetayFiyat);
            pnlResScroll.Controls.Add(pnlResDetay);
            y += 208;

            // Misafir bilgi kartı
            pnlMisafir = UIHelper.KartPanel(x, y, 565, 160);
            pnlMisafir.Controls.Add(new Label { Text = "👤 İletişim Bilgileri", Font = UIHelper.FAltBaslik, ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(16, 12) });
            pnlMisafir.Controls.Add(new Label { Text = "⚠  Organizatör sizinle iletişime geçebilmek için bu bilgilere ihtiyaç duyar.", Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CUyari, AutoSize = false, Size = new Size(530, 18), Location = new Point(16, 42) });
            pnlMisafir.Controls.Add(UIHelper.LblAlan("Ad Soyad:", 16, 70));
            txtResAd       = UIHelper.TxtBox(130, 66, 415); txtResAd.Name = "txtResAd";
            pnlMisafir.Controls.Add(txtResAd);
            pnlMisafir.Controls.Add(UIHelper.LblAlan("Telefon:", 16, 110));
            txtResTelefon  = UIHelper.TxtBox(130, 106, 415); txtResTelefon.Name = "txtResTelefon";
            pnlMisafir.Controls.Add(txtResTelefon);
            pnlResScroll.Controls.Add(pnlMisafir);
            y += 176;

            // Üye bilgisi (logged in)
            lblUyelik = new Label { Name = "lblUyelik", Location = new Point(x, y), AutoSize = true, Font = UIHelper.FNormal, ForeColor = UIHelper.CMetin, Visible = false };
            pnlResScroll.Controls.Add(lblUyelik);
            y += 32;

            // Hata
            lblResHata = new Label { Name = "lblResHata", Location = new Point(x, y), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };
            pnlResScroll.Controls.Add(lblResHata);
            y += 25;

            // Butonlar
            btnResGeri   = UIHelper.BtnSecondary("← Geri Dön", x, y, 170, 46);     btnResGeri.Name = "btnResGeri";     btnResGeri.Click += (s, e) => this.Close();
            btnResOnayla = UIHelper.BtnPrimary("✅  Onayla ve Kaydet", x + 190, y, 270, 46); btnResOnayla.Name = "btnResOnayla"; btnResOnayla.Click += BtnOnayla_Click;
            pnlResScroll.Controls.Add(btnResGeri);
            pnlResScroll.Controls.Add(btnResOnayla);

            this.Controls.Add(pnlResScroll);
            this.Controls.Add(pnlResHeader);
            this.ResumeLayout(false);
        }

        private Panel pnlResHeader, pnlResScroll, pnlResDetay, pnlMisafir;
        private Label lblResDetaySaha, lblResDetayAdres, lblResDetayTarih, lblResDetaySaat, lblResDetayFiyat;
        private Label lblUyelik, lblResHata;
        private System.Windows.Forms.TextBox txtResAd, txtResTelefon;
        private Button btnResGeri, btnResOnayla;
    }
}
