using System;
using System.Collections.Generic;

public class TargAuto
{
    public List<Tranzactie> Tranzactii = new List<Tranzactie>();

    public void AdaugaTranzactie(Tranzactie t)
    {
        Tranzactii.Add(t);
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
}