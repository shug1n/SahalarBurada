using System;
using System.Collections.Generic;
using System.Linq;
using SahalarBurada.Helpers;
using SahalarBurada.Models;

namespace SahalarBurada.Services
{
    public static class KullaniciServisi
    {

        // ─── Kiracı ──────────────────────────────────────────────────
        public static (bool basarili, string mesaj, Kullanici kullanici) KiracıGiris(string eposta, string sifre)
        {
            var k = DatabaseServisi.GetUserByEmail(eposta);
            if (k == null) return (false, "E-posta adresi bulunamadı.", null);
            if (!SifreHelper.Dogrula(sifre, k.SifreHash)) return (false, "Şifre hatalı.", null);
            return (true, "Giriş başarılı.", k);
        }

        public static (bool basarili, string mesaj, Kullanici kullanici) KiracıKayit(
            string ad, string soyad, string eposta, string telefon, string sifre)
        {
            if (DatabaseServisi.CheckUserExists(eposta))
                return (false, "Bu e-posta zaten kayıtlı.", null);

            var k = new Kullanici
            {
                Id = Guid.NewGuid().ToString(), Ad = ad, Soyad = soyad,
                Eposta = eposta, Telefon = telefon, SifreHash = SifreHelper.Hash(sifre),
                KayitTarihi = DateTime.Now
            };
            DatabaseServisi.InsertUser(k);
            return (true, "Kayıt başarılı.", k);
        }

        // ─── Organizatör ─────────────────────────────────────────────
        public static (bool basarili, string mesaj, Organizator org) OrgGiris(string eposta, string sifre)
        {
            var o = DatabaseServisi.GetOrganizerByEmail(eposta);
            if (o == null) return (false, "E-posta adresi bulunamadı.", null);
            if (!SifreHelper.Dogrula(sifre, o.SifreHash)) return (false, "Şifre hatalı.", null);
            return (true, "Giriş başarılı.", o);
        }

        public static (bool basarili, string mesaj, Organizator org) OrgKayit(
            string isletme, string ad, string soyad, string eposta, string sifre)
        {
            if (DatabaseServisi.CheckOrganizerExists(eposta))
                return (false, "Bu e-posta zaten kayıtlı.", null);

            var o = new Organizator
            {
                Id = Guid.NewGuid().ToString(), IsletmeAdi = isletme,
                Ad = ad, Soyad = soyad, Eposta = eposta,
                SifreHash = SifreHelper.Hash(sifre), KayitTarihi = DateTime.Now
            };
            DatabaseServisi.InsertOrganizer(o);
            return (true, "Kayıt başarılı.", o);
        }
    }
}
