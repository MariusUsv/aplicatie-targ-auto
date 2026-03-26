using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        IStocareData admin = StocareFactory.GetStocare();

        while (true)
        {
            Console.WriteLine("\n=== MENIU ===");
            Console.WriteLine("1. Adauga tranzactie");
            Console.WriteLine("2. Afiseaza tranzactii");
            Console.WriteLine("3. Cauta dupa cumparator");
            Console.WriteLine("4. Tranzactii dintr-o zi");
            Console.WriteLine("5. Cea mai cautata masina");
            Console.WriteLine("6. Iesire");

            string opt = Console.ReadLine() ?? "";

            if (opt == "6")
                break;

            switch (opt)
            {
                case "1":
                    Console.Write("Vanzator: ");
                    string v = Console.ReadLine() ?? "";

                    Console.Write("Cumparator: ");
                    string c = Console.ReadLine() ?? "";

                    Console.Write("Firma: ");
                    string f = Console.ReadLine() ?? "";

                    Console.Write("Model: ");
                    string m = Console.ReadLine() ?? "";

                    Console.Write("An: ");
                    int an;
                    while (!int.TryParse(Console.ReadLine(), out an))
                    {
                        Console.Write("Introdu un an valid: ");
                    }

                    Console.Write("Culoare: ");
                    string culoare = Console.ReadLine() ?? "";

                    Console.WriteLine("Alege optiuni (ex: 1,3,5):");
                    Console.WriteLine("1. AC");
                    Console.WriteLine("2. Navigatie");
                    Console.WriteLine("3. Camera");
                    Console.WriteLine("4. Piele");
                    Console.WriteLine("5. Bluetooth");

                    string input = Console.ReadLine() ?? "";
                    string optiuni = "";

                    foreach (var x in input.Split(','))
                    {
                        switch (x.Trim())
                        {
                            case "1": optiuni += "AC+"; break;
                            case "2": optiuni += "Navigatie+"; break;
                            case "3": optiuni += "Camera+"; break;
                            case "4": optiuni += "Piele+"; break;
                            case "5": optiuni += "Bluetooth+"; break;
                        }
                    }

                    if (optiuni.EndsWith("+"))
                    {
                        optiuni = optiuni.TrimEnd('+');
                    }

                    Console.Write("Pret: ");
                    double pret;
                    while (!double.TryParse(Console.ReadLine(), out pret))
                    {
                        Console.Write("Introdu un pret valid: ");
                    }

                    Console.Write("Data tranzactiei (yyyy-mm-dd): ");
                    DateTime data;
                    while (!DateTime.TryParse(Console.ReadLine(), out data))
                    {
                        Console.Write("Introdu o data valida: ");
                    }

                    Persoana pv = new Persoana(v);
                    Persoana pc = new Persoana(c);
                    Masina masina = new Masina(f, m, an, culoare, optiuni);

                    Tranzactie t = new Tranzactie(pv, pc, masina, data, pret);

                    admin.AddTranzactie(t);

                    Console.WriteLine("✔ Tranzactie salvata!");
                    break;

                case "2":
                    List<Tranzactie> lista = admin.GetTranzactii();

                    if (lista.Count == 0)
                    {
                        Console.WriteLine("Nu exista tranzactii.");
                    }
                    else
                    {
                        foreach (var tr in lista)
                        {
                            Console.WriteLine($"{tr.Masina.Firma} {tr.Masina.Model} | {tr.Pret} | {tr.Cumparator.Nume} | {tr.DataTranzactie.ToShortDateString()}");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Nume cumparator: ");
                    string nume = Console.ReadLine() ?? "";

                    var listaCautare = admin.GetTranzactii();
                    bool gasit = false;

                    foreach (var tr in listaCautare)
                    {
                        if (tr.Cumparator.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"{tr.Masina.Model} - {tr.Pret} - {tr.DataTranzactie.ToShortDateString()}");
                            gasit = true;
                        }
                    }

                    if (!gasit)
                        Console.WriteLine("Nu s-a gasit nimic.");
                    break;

                case "4":
                    Console.Write("Data (yyyy-mm-dd): ");
                    DateTime dataCautare;

                    while (!DateTime.TryParse(Console.ReadLine(), out dataCautare))
                    {
                        Console.Write("Introdu o data valida: ");
                    }

                    var listaZi = admin.GetTranzactii();
                    bool exista = false;

                    foreach (var tr in listaZi)
                    {
                        if (tr.DataTranzactie.Date == dataCautare.Date)
                        {
                            Console.WriteLine($"{tr.Masina.Model} - {tr.Pret}");
                            exista = true;
                        }
                    }

                    if (!exista)
                        Console.WriteLine("Nu exista tranzactii in acea zi.");

                    break;

                case "5":
                    var listaStat = admin.GetTranzactii();

                    if (listaStat.Count == 0)
                    {
                        Console.WriteLine("Nu exista date.");
                        break;
                    }

                    Dictionary<string, int> frecventa = new Dictionary<string, int>();

                    foreach (var tr in listaStat)
                    {
                        string key = tr.Masina.Firma + " " + tr.Masina.Model;

                        if (frecventa.ContainsKey(key))
                            frecventa[key]++;
                        else
                            frecventa[key] = 1;
                    }

                    string maxMasina = "";
                    int max = 0;

                    foreach (var item in frecventa)
                    {
                        if (item.Value > max)
                        {
                            max = item.Value;
                            maxMasina = item.Key;
                        }
                    }

                    Console.WriteLine("Cea mai cautata masina: " + maxMasina);
                    break;

                default:
                    Console.WriteLine("Optiune invalida!");
                    break;
            }
        }
    }
}