using System;
using System.Web.Script.Serialization;

public class TestTime
{
    public class Rezervasyon
    {
        public DateTime Tarih { get; set; }
    }

    public static void Main()
    {
        string json = "{\"Tarih\":\"\\/Date(1779483600000)\\/\"}";
        var serializer = new JavaScriptSerializer();
        var rez = serializer.Deserialize<Rezervasyon>(json);
        Console.WriteLine("Deserialized Tarih: " + rez.Tarih);
        Console.WriteLine("Deserialized Kind: " + rez.Tarih.Kind);
        Console.WriteLine("Deserialized Date: " + rez.Tarih.Date);

        // Simulated user input
        DateTime localInput = new DateTime(2026, 5, 24);
        Console.WriteLine("Input Date: " + localInput);
        Console.WriteLine("Input Kind: " + localInput.Kind);
        Console.WriteLine("Are they equal? " + (rez.Tarih.Date == localInput.Date));
    }
}
