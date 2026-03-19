using System;

class Program
{
    static void Main()
    {
        TargAuto targ = new TargAuto();

        while (true)
        {
            Console.WriteLine("\n1. Adauga tranzactie");
            Console.WriteLine("2. Afiseaza tranzactii din zi");
            Console.WriteLine("3. Cea mai cautata masina");
            Console.WriteLine("4. Afiseaza preturi pe perioada");
            Console.WriteLine("5. Iesire");

            var opt = Console.ReadLine();
            if (opt == "5") break;

            switch (opt)
            {
                case "1":
                    Console.Write("Nume vanzator: ");
                    var numeV = Console.ReadLine();

                    Console.Write("Nume cumparator: ");
                    var numeC = Console.ReadLine();

                    Console.Write("Firma masina: ");
                    var firma = Console.ReadLine();

                    Console.Write("Model masina: ");
                    var model = Console.ReadLine();

                    Console.Write("An fabricatie: ");
                    int an = int.Parse(Console.ReadLine());

                    Console.WriteLine("Alege culoarea:");
                    foreach (var culoare in Enum.GetValues(typeof(CuloareMasina)))
                        Console.WriteLine($"{(int)culoare} - {culoare}");
                    CuloareMasina culoareAleasa = (CuloareMasina)int.Parse(Console.ReadLine());

                    Console.WriteLine("Selecteaza optiuni (separate prin virgula):");
                    foreach (var optiune in Enum.GetValues(typeof(OptiuniMasina)))
                        if ((int)optiune != 0) Console.WriteLine($"{(int)optiune} - {optiune}");
                    var inputOptiuni = Console.ReadLine().Split(',');
                    OptiuniMasina optiuni = OptiuniMasina.NicioOptiune;
                    foreach (var o in inputOptiuni)
                        optiuni |= (OptiuniMasina)int.Parse(o);

                    Console.Write("Pret: ");
                    double pret = double.Parse(Console.ReadLine());

                    Console.Write("Data (yyyy-mm-dd): ");
                    DateTime data = DateTime.Parse(Console.ReadLine());

                    var vanzator = new Persoana(numeV);
                    var cumparator = new Persoana(numeC);
                    var masina = new Masina(firma, model, an, culoareAleasa, optiuni);
                    var tranzactie = new Tranzactie(vanzator, cumparator, masina, data, pret);

                    targ.AdaugaTranzactie(tranzactie);
                    break;

                case "2":
                    Console.Write("Data (yyyy-mm-dd): ");
                    DateTime dataZi = DateTime.Parse(Console.ReadLine());
                    targ.AfiseazaTranzactiiDinZi(dataZi);
                    break;

                case "3":
                    Console.WriteLine("Cea mai cautata masina: " + targ.CeaMaiCautataMasina());
                    break;

                case "4":
                    Console.Write("Start (yyyy-mm-dd): ");
                    DateTime start = DateTime.Parse(Console.ReadLine());
                    Console.Write("End (yyyy-mm-dd): ");
                    DateTime end = DateTime.Parse(Console.ReadLine());
                    targ.AfiseazaPreturiPePerioada(start, end);
                    break;
            }
        }
    }
}