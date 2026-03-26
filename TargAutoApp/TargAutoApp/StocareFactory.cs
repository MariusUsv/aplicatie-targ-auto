using System.IO;

public static class StocareFactory
{
    public static IStocareData GetStocare()
    {
        string cale = Directory.GetCurrentDirectory() + "\\tranzactii.txt";
        return new AdministrareTranzactiiFisierText(cale);
    }
}