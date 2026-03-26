using System;

public class Tranzactie
{
    public Persoana Vanzator { get; set; }
    public Persoana Cumparator { get; set; }
    public Masina Masina { get; set; }
    public DateTime DataTranzactie { get; set; }
    public double Pret { get; set; }

    public Tranzactie(Persoana v, Persoana c, Masina m, DateTime data, double pret)
    {
        Vanzator = v;
        Cumparator = c;
        Masina = m;
        DataTranzactie = data;
        Pret = pret;
    }
}