using System.Collections.Generic;
using System.Linq;

namespace TargAutoApp
{
    public class AdministrareTranzactiiMemorie : IStocareData
    {
        private List<Tranzactie> listaTranzactii = new List<Tranzactie>();
        private List<Persoana> listaPersoane = new List<Persoana>();

        public void AddTranzactie(Tranzactie t) => listaTranzactii.Add(t);
        public List<Tranzactie> GetTranzactii() => listaTranzactii;
        public void DeleteTranzactie(Tranzactie t) => listaTranzactii.Remove(t);
        public void AddPersoana(Persoana p) => listaPersoane.Add(p);
        public List<Persoana> GetPersoane() => listaPersoane;
        public void DeletePersoana(Persoana p) => listaPersoane.Remove(p);
        public void UpdateTranzactie(Tranzactie v, Tranzactie n) { }
        public void UpdatePersoana(Persoana v, Persoana n) { }
    }
}