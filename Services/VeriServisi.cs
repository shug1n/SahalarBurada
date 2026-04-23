using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using SahalarBurada.Helpers;
using SahalarBurada.Models;

namespace SahalarBurada.Services
{
    public static class VeriServisi
    {
        private static readonly string VeriKlasor;
        private static readonly JavaScriptSerializer Srl = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };

        static VeriServisi()
        {
            VeriKlasor = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "SahalarBurada");
            Directory.CreateDirectory(VeriKlasor);
            DemoVeriOlustur();
        }

        private static string Yol(string dosya) => Path.Combine(VeriKlasor, dosya);

        public static List<T> Yukle<T>(string dosya)
        {
            var p = Yol(dosya);
            if (!File.Exists(p)) return new List<T>();
            try
            {
                var json = File.ReadAllText(p, Encoding.UTF8);
                return Srl.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch { return new List<T>(); }
        }

        public static void Kaydet<T>(string dosya, List<T> liste)
        {
            var json = Srl.Serialize(liste);
            File.WriteAllText(Yol(dosya), json, Encoding.UTF8);
        }

        // ─── Demo veri (sadece ilk çalıştırmada) ─────────────────────
        private static void DemoVeriOlustur()
        {
            // Demo organizatör
            if (!File.Exists(Yol("organizatorler.json")))
            {
                var list = new List<Organizator>
                {
                    new Organizator
                    {
                        Id            = "org-001",
                        IsletmeAdi   = "Yeşil Çim Spor Tesisleri",
                        Ad           = "Ahmet",
                        Soyad        = "Yılmaz",
                        Eposta       = "demo@org.com",
                        SifreHash    = SifreHelper.Hash("123456"),
                        KayitTarihi  = DateTime.Now
                    }
                };
                Kaydet("organizatorler.json", list);
            }

            // Demo sahalar
            if (!File.Exists(Yol("sahalar.json")))
            {
                var saatler = new List<string>();
                for (int i = 8; i <= 22; i++) saatler.Add(i.ToString("D2") + ":00");
                var gunler = new List<string>
                    { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };

                var list = new List<HaliSaha>
                {
                    new HaliSaha
                    {
                        Id = "saha-001", OrganizatorId = "org-001",
                        Ad = "Yeşil Çim Halı Saha 1", Adres = "Kadıköy, İstanbul",
                        Kapasite = 14, FiyatSaat = 350.0,
                        MüsaitGunler = gunler, MüsaitSaatler = saatler,
                        Aciklama = "Profesyonel halı zemin, soyunma odası ve duş. Kadıköy merkeze 5 dk mesafede.",
                        EklenmeTarihi = DateTime.Now
                    },
                    new HaliSaha
                    {
                        Id = "saha-002", OrganizatorId = "org-001",
                        Ad = "Spor Arena Kapalı Saha", Adres = "Beşiktaş, İstanbul",
                        Kapasite = 12, FiyatSaat = 420.0,
                        MüsaitGunler = gunler, MüsaitSaatler = saatler,
                        Aciklama = "Kapalı alan, iklim kontrollü. Ücretsiz otopark. Modern soyunma odaları.",
                        EklenmeTarihi = DateTime.Now
                    },
                    new HaliSaha
                    {
                        Id = "saha-003", OrganizatorId = "org-001",
                        Ad = "Meydan Spor Tesisi Açık Saha", Adres = "Üsküdar, İstanbul",
                        Kapasite = 16, FiyatSaat = 300.0,
                        MüsaitGunler = gunler, MüsaitSaatler = saatler,
                        Aciklama = "Geniş açık saha, tribün alanı, kafeterya. Aile dostu ortam, otopark mevcut.",
                        EklenmeTarihi = DateTime.Now
                    }
                };
                Kaydet("sahalar.json", list);
            }

            if (!File.Exists(Yol("kullanicilar.json")))
                Kaydet("kullanicilar.json", new List<Kullanici>());
            if (!File.Exists(Yol("rezervasyonlar.json")))
                Kaydet("rezervasyonlar.json", new List<Rezervasyon>());
        }
    }
}
