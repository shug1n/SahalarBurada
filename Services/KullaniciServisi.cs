using System;
using System.Collections.Generic;
using System.Linq;
using SahalarBurada.Helpers;
using SahalarBurada.Models;

namespace SahalarBurada.Services
{
    public static class KullaniciServisi
    {
        private const string KDosya = "kullanicilar.json";
        private const string ODosya = "organizatorler.json";

        // ─── Kiracı ──────────────────────────────────────────────────
        public static (bool basarili, string mesaj, Kullanici kullanici) KiracıGiris(string eposta, string sifre)
        {
            var liste = VeriServisi.Yukle<Kullanici>(KDosya);
            var k = liste.FirstOrDefault(x =>
                x.Eposta.Equals(eposta, StringComparison.OrdinalIgnoreCase));
            if (k == null) return (false, "E-posta adresi bulunamadı.", null);
            if (!SifreHelper.Dogrula(sifre, k.SifreHash)) return (false, "Şifre hatalı.", null);
            return (true, "Giriş başarılı.", k);
        }

        public static (bool basarili, string mesaj, Kullanici kullanici) KiracıKayit(
            string ad, string soyad, string eposta, string sifre)
        {
            var liste = VeriServisi.Yukle<Kullanici>(KDosya);
            if (liste.Any(x => x.Eposta.Equals(eposta, StringComparison.OrdinalIgnoreCase)))
                return (false, "Bu e-posta zaten kayıtlı.", null);

            var k = new Kullanici
            {
                Id = Guid.NewGuid().ToString(), Ad = ad, Soyad = soyad,
                Eposta = eposta, SifreHash = SifreHelper.Hash(sifre),
                KayitTarihi = DateTime.Now
            };
            liste.Add(k);
            VeriServisi.Kaydet(KDosya, liste);
            return (true, "Kayıt başarılı.", k);
        }

        // ─── Organizatör ─────────────────────────────────────────────
        public static (bool basarili, string mesaj, Organizator org) OrgGiris(string eposta, string sifre)
        {
            var liste = VeriServisi.Yukle<Organizator>(ODosya);
            var o = liste.FirstOrDefault(x =>
                x.Eposta.Equals(eposta, StringComparison.OrdinalIgnoreCase));
            if (o == null) return (false, "E-posta adresi bulunamadı.", null);
            if (!SifreHelper.Dogrula(sifre, o.SifreHash)) return (false, "Şifre hatalı.", null);
            return (true, "Giriş başarılı.", o);
        }

        public static (bool basarili, string mesaj, Organizator org) OrgKayit(
            string isletme, string ad, string soyad, string eposta, string sifre)
        {
            var liste = VeriServisi.Yukle<Organizator>(ODosya);
            if (liste.Any(x => x.Eposta.Equals(eposta, StringComparison.OrdinalIgnoreCase)))
                return (false, "Bu e-posta zaten kayıtlı.", null);

            var o = new Organizator
            {
                Id = Guid.NewGuid().ToString(), IsletmeAdi = isletme,
                Ad = ad, Soyad = soyad, Eposta = eposta,
                SifreHash = SifreHelper.Hash(sifre), KayitTarihi = DateTime.Now
            };
            liste.Add(o);
            VeriServisi.Kaydet(ODosya, liste);
            return (true, "Kayıt başarılı.", o);
        }
    }
}
