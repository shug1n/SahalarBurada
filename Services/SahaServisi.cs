using System;
using System.Collections.Generic;
using System.Linq;
using SahalarBurada.Models;

namespace SahalarBurada.Services
{
    public static class SahaServisi
    {
        private const string SDosya = "sahalar.json";
        private const string RDosya = "rezervasyonlar.json";

        public static List<HaliSaha> TumSahalariGetir()
            => VeriServisi.Yukle<HaliSaha>(SDosya);

        public static List<HaliSaha> OrganizatorSahalari(string orgId)
            => TumSahalariGetir().Where(s => s.OrganizatorId == orgId).ToList();

        /// <summary>
        /// Belirtilen tarih ve saatte müsait sahaları getirir (çakışma kontrolü dahil).
        /// </summary>
        public static List<HaliSaha> UygunSahalariGetir(DateTime tarih, string saat)
        {
            var tumSahalar   = TumSahalariGetir();
            var rezervasyonlar = VeriServisi.Yukle<Rezervasyon>(RDosya);
            var gunAdi = TurkceGunAdi(tarih.DayOfWeek);

            var uygun = new List<HaliSaha>();
            foreach (var saha in tumSahalar)
            {
                if (!saha.MüsaitGunler.Contains(gunAdi))   continue;
                if (!saha.MüsaitSaatler.Contains(saat))    continue;

                // Çakışma kontrolü
                bool cakismaVar = rezervasyonlar.Any(r =>
                    r.SahaId == saha.Id &&
                    r.Tarih.Date == tarih.Date &&
                    r.Saat == saat);

                if (!cakismaVar) uygun.Add(saha);
            }
            return uygun;
        }

        public static void SahaEkle(HaliSaha saha)
        {
            var liste = TumSahalariGetir();
            saha.Id = Guid.NewGuid().ToString();
            saha.EklenmeTarihi = DateTime.Now;
            liste.Add(saha);
            VeriServisi.Kaydet(SDosya, liste);
        }

        public static void RezervasyonEkle(Rezervasyon r)
        {
            var liste = VeriServisi.Yukle<Rezervasyon>(RDosya);
            r.Id = Guid.NewGuid().ToString();
            r.OlusturmaTarihi = DateTime.Now;
            liste.Add(r);
            VeriServisi.Kaydet(RDosya, liste);
        }

        public static List<Rezervasyon> TumRezervasyonlar()
            => VeriServisi.Yukle<Rezervasyon>(RDosya);

        private static string TurkceGunAdi(DayOfWeek gun)
        {
            switch (gun)
            {
                case DayOfWeek.Monday:    return "Pazartesi";
                case DayOfWeek.Tuesday:   return "Salı";
                case DayOfWeek.Wednesday: return "Çarşamba";
                case DayOfWeek.Thursday:  return "Perşembe";
                case DayOfWeek.Friday:    return "Cuma";
                case DayOfWeek.Saturday:  return "Cumartesi";
                default:                  return "Pazar";
            }
        }
    }
}
