using System.Collections.Generic;

public class AdministrareTranzactiiMemorie : IStocareData
{
    private List<Tranzactie> lista = new List<Tranzactie>();

    public void AddTranzactie(Tranzactie t)
    {
        lista.Add(t);
    }

    public List<Tranzactie> GetTranzactii()
    {
        return lista;
    }
}