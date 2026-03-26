using System.Collections.Generic;

public interface IStocareData
{
    void AddTranzactie(Tranzactie t);
    List<Tranzactie> GetTranzactii();
}