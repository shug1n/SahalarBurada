using SahalarBurada.Models;

namespace SahalarBurada.Helpers
{
    public static class Oturum
    {
        public static Kullanici AktifKullanici { get; set; }
        public static Organizator AktifOrganizator { get; set; }

        public static bool GirisYapildi => AktifKullanici != null;
        public static bool OrganizatorGirisYapildi => AktifOrganizator != null;

        public static void CikisYap()
        {
            AktifKullanici = null;
            AktifOrganizator = null;
        }
    }
}
