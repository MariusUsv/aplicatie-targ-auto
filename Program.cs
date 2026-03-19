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

                    Console.Write("Pret: ");
                    double pret = double.Parse(Console.ReadLine());

                    Console.Write("Data (yyyy-mm-dd): ");
                    DateTime data = DateTime.Parse(Console.ReadLine());

                    var vanzator = new Persoana { Nume = numeV };
                    var cumparator = new Persoana { Nume = numeC };
                    var masina = new Masina { Firma = firma, Model = model };

                    var tranzactie = new Tranzactie
                    {
                        Vanzator = vanzator,
                        Cumparator = cumparator,
                        Masina = masina,
                        Pret = pret,
                        DataTranzactie = data
                    };

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