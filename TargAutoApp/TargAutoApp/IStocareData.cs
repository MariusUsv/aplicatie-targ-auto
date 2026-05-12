using System.Collections.Generic;
namespace TargAutoApp
{
    public interface IStocareData
    {
        void AddTranzactie(Tranzactie t);
        List<Tranzactie> GetTranzactii();
        void UpdateTranzactie(Tranzactie v, Tranzactie n);
        void DeleteTranzactie(Tranzactie t);
        void AddPersoana(Persoana p);
        List<Persoana> GetPersoane();
        void UpdatePersoana(Persoana v, Persoana n);
        void DeletePersoana(Persoana p);
    }
}