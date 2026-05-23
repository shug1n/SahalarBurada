using System;
using System.Web.Script.Serialization;

string json = "{\"Tarih\":\"\\/Date(1779483600000)\\/\"}";
var serializer = new JavaScriptSerializer();
var rez = serializer.Deserialize<RezervasyonTest>(json);
Console.WriteLine("Deserialized Tarih: " + rez.Tarih.ToString("o"));
Console.WriteLine("Deserialized Kind: " + rez.Tarih.Kind);
Console.WriteLine("Deserialized Date: " + rez.Tarih.Date.ToString("o"));

DateTime localInput = new DateTime(2026, 5, 24);
Console.WriteLine("Input Date: " + localInput.ToString("o"));
Console.WriteLine("Input Kind: " + localInput.Kind);
Console.WriteLine("Are they equal? " + (rez.Tarih.Date == localInput.Date));

public class RezervasyonTest
{
    public DateTime Tarih { get; set; }
}
