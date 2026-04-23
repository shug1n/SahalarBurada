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
            DoldurDetaylar();
        }

        private void DoldurDetaylar()
        {
            string saatSonu = (int.Parse(_saat.Split(':')[0]) + 1).ToString("D2") + ":00";
            lblResDetaySaha.Text   = _saha.Ad;
            lblResDetayAdres.Text  = _saha.Adres;
            lblResDetayTarih.Text  = _tarih.ToString("dd MMMM yyyy, dddd");
            lblResDetaySaat.Text   = $"{_saat} – {saatSonu}  (1 saat)";
            lblResDetayFiyat.Text  = $"{_saha.FiyatSaat:N0} ₺";

            if (!Oturum.GirisYapildi)
            {
                pnlMisafir.Visible = true;
                lblUyelik.Visible  = false;
            }
            else
            {
                pnlMisafir.Visible = false;
                lblUyelik.Text     = $"👤  {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad} adına rezervasyon yapılacak.";
                lblUyelik.Visible  = true;
            }
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            lblResHata.Visible = false;
            string misafirAd = null, misafirTelefon = null, kullaniciId = null;

            if (!Oturum.GirisYapildi)
            {
                misafirAd      = txtResAd?.Text.Trim();
                misafirTelefon = txtResTelefon?.Text.Trim();
                if (string.IsNullOrEmpty(misafirAd) || string.IsNullOrEmpty(misafirTelefon))
                { lblResHata.Text = "Lütfen ad-soyad ve telefon bilgilerinizi girin."; lblResHata.Visible = true; return; }
            }
            else
            {
                kullaniciId = Oturum.AktifKullanici.Id;
                misafirAd   = Oturum.AktifKullanici.Ad + " " + Oturum.AktifKullanici.Soyad;
            }

            SahaServisi.RezervasyonEkle(new Rezervasyon
            {
                SahaId = _saha.Id, SahaAdi = _saha.Ad, KullaniciId = kullaniciId,
                MisafirAd = misafirAd, MisafirTelefon = misafirTelefon,
                Tarih = _tarih, Saat = _saat, ToplamFiyat = _saha.FiyatSaat
            });

            MessageBox.Show(
                $"Rezervasyonunuz başarıyla oluşturuldu!\n\n⚽ Saha:  {_saha.Ad}\n📅 Tarih: {_tarih:dd.MM.yyyy}  {_saat}\n💰 Fiyat: {_saha.FiyatSaat:N0} ₺\n\nİyi maçlar! ⚽",
                "Rezervasyon Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
