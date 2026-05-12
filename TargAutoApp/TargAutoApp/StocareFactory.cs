using System;
using System.IO;
using TargAutoApp;

public static class StocareFactory
{
    public static IStocareData GetStocare()
    {
        // Generăm automat calea fișierului în folderul aplicației
        string numeFisier = "tranzactii.txt";
        string cale = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, numeFisier);

        return new AdministrareTranzactiiFisierText(cale);
    }
}