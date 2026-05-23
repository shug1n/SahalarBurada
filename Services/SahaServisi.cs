using System;
using System.Collections.Generic;
using System.Linq;
using SahalarBurada.Models;

namespace SahalarBurada.Services
{
    public static class SahaServisi
    {
        public static List<HaliSaha> TumSahalariGetir()
            => DatabaseServisi.GetAllFields();

        public static List<HaliSaha> OrganizatorSahalari(string orgId)
            => TumSahalariGetir().Where(s => s.OrganizatorId == orgId).ToList();

        /// <summary>
        /// Belirtilen tarih ve saatte müsait sahaları getirir (çakışma + şehir/ilçe filtresi dahil).
        /// sehir veya ilce boş/null geçilirse o filtre uygulanmaz.
        /// </summary>
        public static List<HaliSaha> UygunSahalariGetir(DateTime tarih, string saat,
            string sehir = null, string ilce = null)
        {
            var tumSahalar    = TumSahalariGetir();
            var rezervasyonlar = DatabaseServisi.GetAllReservations();
            var gunAdi = TurkceGunAdi(tarih.DayOfWeek);

            var uygun = new List<HaliSaha>();
            foreach (var saha in tumSahalar)
            {
                if (!saha.MüsaitGunler.Contains(gunAdi))   continue;
                if (!saha.MüsaitSaatler.Contains(saat))    continue;

                // Şehir filtresi
                if (!string.IsNullOrWhiteSpace(sehir) &&
                    !string.Equals(saha.Sehir, sehir, StringComparison.OrdinalIgnoreCase)) continue;

                // İlçe filtresi
                if (!string.IsNullOrWhiteSpace(ilce) &&
                    !string.Equals(saha.Ilce, ilce, StringComparison.OrdinalIgnoreCase)) continue;

                // Çakışma kontrolü: aynı saha, aynı tarih, aynı saat → dolu
                bool cakismaVar = rezervasyonlar.Any(r =>
                    r.SahaId == saha.Id &&
                    r.Tarih.ToLocalTime().Date == tarih.ToLocalTime().Date &&
                    r.Saat == saat);

                if (!cakismaVar) uygun.Add(saha);
            }
            return uygun;
        }

        public static void SahaEkle(HaliSaha saha)
        {
            saha.Id = Guid.NewGuid().ToString();
            saha.EklenmeTarihi = DateTime.Now;
            DatabaseServisi.InsertField(saha);
        }

        public static bool RezervasyonEkle(Rezervasyon r)
        {
            var liste = DatabaseServisi.GetAllReservations();

            // Çakışma kontrolü: aynı saha, aynı tarih, aynı saat → dolu
            bool cakismaVar = liste.Any(exist =>
                exist.SahaId == r.SahaId &&
                exist.Tarih.ToLocalTime().Date == r.Tarih.ToLocalTime().Date &&
                exist.Saat == r.Saat);

            if (cakismaVar)
            {
                return false;
            }

            r.Id = Guid.NewGuid().ToString();
            r.OlusturmaTarihi = DateTime.Now;
            DatabaseServisi.InsertReservation(r);
            return true;
        }

        public static List<Rezervasyon> TumRezervasyonlar()
            => DatabaseServisi.GetAllReservations();

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
