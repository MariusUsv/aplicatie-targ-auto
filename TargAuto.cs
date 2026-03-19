using System;
using System.Collections.Generic;
using System.Linq;

public class TargAuto
{
    public List<Tranzactie> Tranzactii { get; set; } = new List<Tranzactie>();

    public void AdaugaTranzactie(Tranzactie t)
    {
        bool vanzariMultiple = Tranzactii.Any(x =>
            x.Vanzator.Nume == t.Vanzator.Nume &&
            x.DataTranzactie.Date == t.DataTranzactie.Date);

        bool cumparariMultiple = Tranzactii.Any(x =>
            x.Cumparator.Nume == t.Cumparator.Nume &&
            x.DataTranzactie.Date == t.DataTranzactie.Date);

        if (vanzariMultiple)
            Console.WriteLine("Atenție: vânzătorul are mai multe tranzacții în aceeași zi!");

        if (cumparariMultiple)
            Console.WriteLine("Atenție: cumpărătorul are mai multe tranzacții în aceeași zi!");

        Tranzactii.Add(t);
    }

    public string CeaMaiCautataMasina()
    {
        var frecventa = new Dictionary<string, int>();

        foreach (var t in Tranzactii)
        {
            string key = $"{t.Masina.Firma}-{t.Masina.Model}";

            if (frecventa.ContainsKey(key))
                frecventa[key]++;
            else
                frecventa[key] = 1;
        }

        return frecventa.OrderByDescending(f => f.Value).First().Key;
    }

    public void AfiseazaTranzactiiDinZi(DateTime data)
    {
        foreach (var t in Tranzactii)
        {
            if (t.DataTranzactie.Date == data.Date)
            {
                Console.WriteLine($"{t.Masina.Firma} {t.Masina.Model} - {t.Pret} euro");
            }
        }
    }

    public void AfiseazaPreturiPePerioada(DateTime start, DateTime end)
    {
        foreach (var t in Tranzactii)
        {
            if (t.DataTranzactie.Date >= start.Date && t.DataTranzactie.Date <= end.Date)
            {
                Console.WriteLine($"{t.DataTranzactie.ToShortDateString()} - {t.Masina.Model} : {t.Pret} euro");
            }
        }
    }
}