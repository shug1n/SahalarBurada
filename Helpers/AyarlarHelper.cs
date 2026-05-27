using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace SahalarBurada.Helpers
{
    public class AyarlarModeli
    {
        public bool KiraciBeniHatirla { get; set; } = false;
        public string KiraciKayitliEposta { get; set; } = "";
        public string KiraciKayitliSifre { get; set; } = "";
        public List<string> KiraciOncekiEpostalar { get; set; } = new List<string>();

        public bool OrgBeniHatirla { get; set; } = false;
        public string OrgKayitliEposta { get; set; } = "";
        public string OrgKayitliSifre { get; set; } = "";
        public List<string> OrgOncekiEpostalar { get; set; } = new List<string>();
    }

    public static class AyarlarHelper
    {
        private static readonly string DosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ayarlar.json");
        private static readonly JavaScriptSerializer Jss = new JavaScriptSerializer();

        public static AyarlarModeli Yukle()
        {
            try
            {
                if (File.Exists(DosyaYolu))
                {
                    string json = File.ReadAllText(DosyaYolu);
                    return Jss.Deserialize<AyarlarModeli>(json) ?? new AyarlarModeli();
                }
            }
            catch { }
            return new AyarlarModeli();
        }

        public static void Kaydet(AyarlarModeli model)
        {
            try
            {
                string json = Jss.Serialize(model);
                File.WriteAllText(DosyaYolu, json);
            }
            catch { }
        }

        public static void KiraciEpostaEkle(string eposta)
        {
            if (string.IsNullOrWhiteSpace(eposta)) return;
            var ayarlar = Yukle();
            if (ayarlar.KiraciOncekiEpostalar == null)
            {
                ayarlar.KiraciOncekiEpostalar = new List<string>();
            }
            if (!ayarlar.KiraciOncekiEpostalar.Contains(eposta))
            {
                ayarlar.KiraciOncekiEpostalar.Add(eposta);
                Kaydet(ayarlar);
            }
        }

        public static void OrgEpostaEkle(string eposta)
        {
            if (string.IsNullOrWhiteSpace(eposta)) return;
            var ayarlar = Yukle();
            if (ayarlar.OrgOncekiEpostalar == null)
            {
                ayarlar.OrgOncekiEpostalar = new List<string>();
            }
            if (!ayarlar.OrgOncekiEpostalar.Contains(eposta))
            {
                ayarlar.OrgOncekiEpostalar.Add(eposta);
                Kaydet(ayarlar);
            }
        }
    }
}
