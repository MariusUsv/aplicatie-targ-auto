using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TargAutoApp
{
    public class Tranzactie : INotifyPropertyChanged
    {
        private double _pret;
        private DateTime _dataActualizare;

        public Persoana Vanzator { get; set; }
        public Persoana Cumparator { get; set; }
        public Masina Masina { get; set; }
        public DateTime DataTranzactie { get; set; }
        public double Pret { get => _pret; set { _pret = value; OnPropertyChanged(); } }
        public DateTime DataActualizare { get => _dataActualizare; set { _dataActualizare = value; OnPropertyChanged(); } }

        public Tranzactie(Persoana v, Persoana c, Masina m, DateTime data, double pret)
        {
            Vanzator = v; Cumparator = c; Masina = m; DataTranzactie = data;
            Pret = pret; DataActualizare = DateTime.Now;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}