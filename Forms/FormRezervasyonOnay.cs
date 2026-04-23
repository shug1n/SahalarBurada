using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormRezervasyonOnay : Form
    {
        private readonly HaliSaha _saha;
        private readonly DateTime _tarih;
        private readonly string _saat;
        private TextBox txtMisafirAd, txtMisafirTelefon;
        private Label lblHata;

        public FormRezervasyonOnay(HaliSaha saha, DateTime tarih, string saat)
        {
            _saha = saha; _tarih = tarih; _saat = saat;
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            UIHelper.FormAyarla(this, "Rezervasyon Onayı", 640, 600);
            this.Controls.Add(UIHelper.HeaderPanelOlustur("✅  Rezervasyon Onayı", "Bilgileri kontrol edin ve onaylayın"));

            var scroll = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan, AutoScroll = true };
            int x = 35, y = 18;

            // Detay kartı
            string saatSonu = (int.Parse(_saat.Split(':')[0]) + 1).ToString("D2") + ":00";
            var detay = UIHelper.KartPanel(x, y, 568, 192);
            detay.Controls.Add(new Label { Text = "📋 Rezervasyon Detayları", Font = UIHelper.FAltBaslik, ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(16, 12) });
            int iy = 48;
            void InfoRow(string lbl, string val) {
                detay.Controls.Add(new Label { Text = lbl, Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, Location = new Point(16, iy), Size = new Size(125, 22) });
                detay.Controls.Add(new Label { Text = val, Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(145, iy) });
                iy += 26;
            }
            InfoRow("⚽ Saha:",   _saha.Ad);
            InfoRow("📍 Adres:",  _saha.Adres);
            InfoRow("📅 Tarih:",  _tarih.ToString("dd MMMM yyyy, dddd"));
            InfoRow("🕐 Saat:",   $"{_saat} – {saatSonu}  (1 saat)");
            InfoRow("💰 Fiyat:",  $"{_saha.FiyatSaat:N0} ₺");
            scroll.Controls.Add(detay);
            y += 208;

            // Misafir bilgileri
            if (!Oturum.GirisYapildi)
            {
                var misKart = UIHelper.KartPanel(x, y, 568, 160);
                misKart.Controls.Add(new Label { Text = "👤 İletişim Bilgileri", Font = UIHelper.FAltBaslik, ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(16, 12) });
                misKart.Controls.Add(new Label { Text = "⚠  Organizatör sizinle iletişime geçebilmek için bu bilgilere ihtiyaç duyar.", Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CUyari, AutoSize = false, Size = new Size(536, 18), Location = new Point(16, 42) });
                misKart.Controls.Add(UIHelper.LblAlan("Ad Soyad:", 16, 70));
                txtMisafirAd = UIHelper.TxtBox(130, 66, 420); misKart.Controls.Add(txtMisafirAd);
                misKart.Controls.Add(UIHelper.LblAlan("Telefon:", 16, 110));
                txtMisafirTelefon = UIHelper.TxtBox(130, 106, 420); misKart.Controls.Add(txtMisafirTelefon);
                scroll.Controls.Add(misKart);
                y += 176;
            }
            else
            {
                scroll.Controls.Add(new Label { Text = $"👤  {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad} adına rezervasyon yapılacak.", Font = UIHelper.FNormal, ForeColor = UIHelper.CMetin, AutoSize = true, Location = new Point(x, y) });
                y += 32;
            }

            lblHata = new Label { Location = new Point(x, y), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };
            scroll.Controls.Add(lblHata);
            y += 25;

            var btnGeri   = UIHelper.BtnSecondary("← Geri Dön", x, y, 170, 46);
            btnGeri.Click += (s, e) => this.Close();
            var btnOnayla = UIHelper.BtnPrimary("✅  Onayla ve Kaydet", x + 190, y, 270, 46);
            btnOnayla.Click += BtnOnayla_Click;
            scroll.Controls.Add(btnGeri);
            scroll.Controls.Add(btnOnayla);

            this.Controls.Add(scroll);
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;
            string misafirAd = null, misafirTelefon = null, kullaniciId = null;
            if (!Oturum.GirisYapildi)
            {
                misafirAd      = txtMisafirAd?.Text.Trim();
                misafirTelefon = txtMisafirTelefon?.Text.Trim();
                if (string.IsNullOrEmpty(misafirAd) || string.IsNullOrEmpty(misafirTelefon))
                { lblHata.Text = "Lütfen ad-soyad ve telefon bilgilerinizi girin."; lblHata.Visible = true; return; }
            }
            else
            {
                kullaniciId = Oturum.AktifKullanici.Id;
                misafirAd   = Oturum.AktifKullanici.Ad + " " + Oturum.AktifKullanici.Soyad;
            }
            SahaServisi.RezervasyonEkle(new Rezervasyon { SahaId = _saha.Id, SahaAdi = _saha.Ad, KullaniciId = kullaniciId, MisafirAd = misafirAd, MisafirTelefon = misafirTelefon, Tarih = _tarih, Saat = _saat, ToplamFiyat = _saha.FiyatSaat });
            MessageBox.Show($"Rezervasyonunuz başarıyla oluşturuldu!\n\n⚽ Saha:  {_saha.Ad}\n📅 Tarih: {_tarih:dd.MM.yyyy}  {_saat}\n💰 Fiyat: {_saha.FiyatSaat:N0} ₺\n\nİyi maçlar! ⚽", "Rezervasyon Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
