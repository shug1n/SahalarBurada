using System;

namespace SahalarBurada.Models
{
    public class Kullanici
    {
        public string Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string SifreHash { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
