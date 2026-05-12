using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TargAutoApp
{
    public class AdministrareTranzactiiFisierText : IStocareData
    {
        private readonly string fT;
        private readonly string fP;

        public AdministrareTranzactiiFisierText(string cale)
        {
            fT = cale;
            fP = cale.Replace("tranzactii.txt", "persoane.txt");
            if (!File.Exists(fT)) File.Create(fT).Close();
            if (!File.Exists(fP)) File.Create(fP).Close();
        }

        public void AddTranzactie(Tranzactie t) => File.AppendAllLines(fT, new[] { TtoS(t) });
        public List<Tranzactie> GetTranzactii() => File.ReadAllLines(fT).Select(StoT).ToList();
        public void DeleteTranzactie(Tranzactie t) => W(GetTranzactii().Where(x => !(x.Vanzator.Nume == t.Vanzator.Nume && x.DataTranzactie == t.DataTranzactie)).ToList());
        private void W(List<Tranzactie> l) => File.WriteAllLines(fT, l.Select(TtoS));

        public void AddPersoana(Persoana p) => File.AppendAllLines(fP, new[] { $"{p.Nume};{p.Telefon};{p.Email}" });
        public List<Persoana> GetPersoane() => File.ReadAllLines(fP).Where(s => !string.IsNullOrEmpty(s)).Select(s => {
            var d = s.Split(';');
            return new Persoana(d[0], d.Length > 1 ? d[1] : "", d.Length > 2 ? d[2] : "");
        }).ToList();
        public void DeletePersoana(Persoana p) => WP(GetPersoane().Where(x => x.Nume != p.Nume).ToList());
        private void WP(List<Persoana> l) => File.WriteAllLines(fP, l.Select(p => $"{p.Nume};{p.Telefon};{p.Email}"));

        private string TtoS(Tranzactie t) => $"{t.Vanzator.Nume};{t.Cumparator.Nume};{t.Masina.Firma};{t.Masina.Model};{t.Masina.AnFabricatie};{t.Masina.Culoare};{t.Masina.Optiuni};{t.Pret};{t.DataTranzactie}";
        private Tranzactie StoT(string l)
        {
            var d = l.Split(';');
            Enum.TryParse(d[5], out CuloareMasina c); Enum.TryParse(d[6], out OptiuniMasina o);
            return new Tranzactie(new Persoana(d[0]), new Persoana(d[1]), new Masina(d[2], d[3], int.Parse(d[4]), c, o), DateTime.Parse(d[8]), double.Parse(d[7]));
        }
        public void UpdateTranzactie(Tranzactie v, Tranzactie n) { }
        public void UpdatePersoana(Persoana v, Persoana n) { }
    }
}