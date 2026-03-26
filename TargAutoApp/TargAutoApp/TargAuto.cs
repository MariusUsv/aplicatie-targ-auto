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

        return frecventa.OrderByDescending(f => f.Value).FirstOrDefault().Key ?? "Niciuna";
    }

    public void AfiseazaTranzactiiDinZi(DateTime data)
    {
        var tranzactiiZi = Tranzactii.Where(t => t.DataTranzactie.Date == data.Date);
        foreach (var t in tranzactiiZi)
        {
            Console.WriteLine(t);
        }
    }

    public void AfiseazaPreturiPePerioada(DateTime start, DateTime end)
    {
        var tranzactiiPerioada = Tranzactii
            .Where(t => t.DataTranzactie.Date >= start.Date && t.DataTranzactie.Date <= end.Date);

        foreach (var t in tranzactiiPerioada)
        {
            Console.WriteLine($"{t.DataTranzactie.ToShortDateString()} - {t.Masina.Model} : {t.Pret} euro");
        }
    }

    // LINQ: returnează lista de cumpărători unici dintr-o zi
    public List<Persoana> CautareCumparatoriUniciDinZi(DateTime data)
    {
        return Tranzactii
            .Where(t => t.DataTranzactie.Date == data.Date)
            .Select(t => t.Cumparator)
            .Distinct()
            .ToList();
    }
}