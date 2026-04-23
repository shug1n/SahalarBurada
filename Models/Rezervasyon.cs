using System;

namespace SahalarBurada.Models
{
    public class Rezervasyon
    {
        public string Id { get; set; }
        public string SahaId { get; set; }
        public string SahaAdi { get; set; }
        public string KullaniciId { get; set; }    // null = misafir
        public string MisafirAd { get; set; }      // misafir adı/soyadı
        public string MisafirTelefon { get; set; } // organizatör iletişim için
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }           // "14:00"
        public double ToplamFiyat { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}
