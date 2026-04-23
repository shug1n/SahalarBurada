using System;
using System.Collections.Generic;

namespace SahalarBurada.Models
{
    public class HaliSaha
    {
        public string Id { get; set; }
        public string OrganizatorId { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public int Kapasite { get; set; }
        public double FiyatSaat { get; set; }
        public List<string> MüsaitGunler { get; set; }
        public List<string> MüsaitSaatler { get; set; }
        public string Aciklama { get; set; }
        public DateTime EklenmeTarihi { get; set; }
    }
}
