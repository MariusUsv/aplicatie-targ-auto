using System;
using System.Collections.Generic;
using System.IO;

public class AdministrareTranzactiiFisierText : IStocareData
{
    private string numeFisier;

    public AdministrareTranzactiiFisierText(string numeFisier)
    {
        this.numeFisier = numeFisier;
        File.Open(numeFisier, FileMode.OpenOrCreate).Close();
    }

    public void AddTranzactie(Tranzactie t)
    {
        using (StreamWriter sw = new StreamWriter(numeFisier, true))
        {
            sw.WriteLine($"{t.Vanzator.Nume};{t.Cumparator.Nume};{t.Masina.Firma};{t.Masina.Model};{t.Masina.AnFabricatie};{t.Masina.Culoare};{t.Masina.Optiuni};{t.Pret};{t.DataTranzactie}");
        }
    }

    public List<Tranzactie> GetTranzactii()
    {
        List<Tranzactie> lista = new List<Tranzactie>();

        using (StreamReader sr = new StreamReader(numeFisier))
        {
            string linie;

            while ((linie = sr.ReadLine()) != null)
            {
                string[] d = linie.Split(';');

                Persoana v = new Persoana(d[0]);
                Persoana c = new Persoana(d[1]);

                Masina m = new Masina(
                    d[2],
                    d[3],
                    int.Parse(d[4]),
                    d[5],
                    d[6]
                );

                Tranzactie t = new Tranzactie(
                    v,
                    c,
                    m,
                    DateTime.Parse(d[8]),
                    double.Parse(d[7])
                );

                lista.Add(t);
            }
        }

        return lista;
    }
}