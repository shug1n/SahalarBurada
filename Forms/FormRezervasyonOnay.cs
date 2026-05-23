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

        public FormRezervasyonOnay(HaliSaha saha, DateTime tarih, string saat)
        {
            _saha = saha; _tarih = tarih; _saat = saat;
            InitializeComponent();
            SetupLogic();
        }

        private void SetupLogic()
        {
            string saatSonu = (int.Parse(_saat.Split(':')[0]) + 1).ToString("D2") + ":00";
            lblSahaDeger.Text   = _saha.Ad;
            lblAdresDeger.Text  = _saha.Adres;
            lblTarihDeger.Text  = _tarih.ToString("dd MMMM yyyy, dddd");
            lblSaatDeger.Text   = $"{_saat} – {saatSonu}  (1 saat)";
            lblFiyatDeger.Text  = $"{_saha.FiyatSaat:N0} ₺  (toplam saha ücreti)";

            // Kişi başı hesap için başlangıç
            HesaplaKisiBasi();

            if (!Oturum.GirisYapildi)
            {
                pnlMisafir.Visible = true;
                pnlMisafir.Location = new System.Drawing.Point(35, 310);
                lblHata.Location   = new System.Drawing.Point(35, 485);
                btnGeri.Location   = new System.Drawing.Point(35, 510);
                btnOnayla.Location = new System.Drawing.Point(225, 510);
            }
            else
            {
                lblAktifKullanici.Visible = true;
                lblAktifKullanici.Text = $"👤  {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad} adına rezervasyon yapılacak.";
                lblAktifKullanici.Location = new System.Drawing.Point(35, 310);
                lblHata.Location   = new System.Drawing.Point(35, 348);
                btnGeri.Location   = new System.Drawing.Point(35, 374);
                btnOnayla.Location = new System.Drawing.Point(225, 374);
            }
        }

        private void HesaplaKisiBasi()
        {
            int kisi = (int)nudKisiSayisi.Value;
            double kisiBasi = _saha.FiyatSaat / kisi;
            lblKisiBasiLabel.Text = kisi == 1
                ? "→ Kişi başı: (tek kişi)"
                : $"→ Kişi başı: {kisiBasi:N0} ₺";
        }

        private void NudKisiSayisi_ValueChanged(object sender, EventArgs e) => HesaplaKisiBasi();

        private void Pnl_PaintBorder(object sender, PaintEventArgs e)
        {
            var pnl = (Panel)sender;
            e.Graphics.DrawRectangle(new Pen(UIHelper.CBolme, 1), 0, 0, pnl.Width - 1, pnl.Height - 1);
        }

        private void BtnGeri_Click(object sender, EventArgs e) => this.Close();

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
            bool basarili = SahaServisi.RezervasyonEkle(new Rezervasyon
            {
                SahaId         = _saha.Id,
                SahaAdi        = _saha.Ad,
                KullaniciId    = kullaniciId,
                MisafirAd      = misafirAd,
                MisafirTelefon = misafirTelefon,
                Tarih          = _tarih,
                Saat           = _saat,
                ToplamFiyat    = _saha.FiyatSaat
            });

            if (!basarili)
            {
                lblHata.Text = "Bu saha için seçilen tarih ve saatte başka bir rezervasyon yapılmıştır. Lütfen başka bir saat seçiniz.";
                lblHata.Visible = true;
                return;
            }
            int kisi = (int)nudKisiSayisi.Value;
            double kisiBasi = _saha.FiyatSaat / kisi;
            string kisiMesaji = kisi > 1 ? $"  👥 Kişi sayısı: {kisi}  →  Kişi başı: {kisiBasi:N0} ₺\n" : "";
            MessageBox.Show(
                $"Rezervasyonunuz başarıyla oluşturuldu!\n\n⚽ Saha:  {_saha.Ad}\n📅 Tarih: {_tarih:dd.MM.yyyy}  {_saat}\n💰 Toplam: {_saha.FiyatSaat:N0} ₺\n{kisiMesaji}\nİyi maçlar! ⚽",
                "Rezervasyon Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
