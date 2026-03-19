using System;

class Program
{
    static void Main()
    {
        Persoana vanzator = new Persoana("Ion Popescu");
        Persoana cumparator = new Persoana("Mihai Ionescu");

        Masina masina = new Masina("Opel", "Astra 1.4", 2016, "Rosu", "AC");

        Tranzactie t = new Tranzactie(vanzator, cumparator, masina, DateTime.Now, 8500);

        TargAuto targ = new TargAuto();
        targ.AdaugaTranzactie(t);

        targ.AfiseazaTranzactiiDinZi(DateTime.Now);

        Console.ReadKey();
    }
}