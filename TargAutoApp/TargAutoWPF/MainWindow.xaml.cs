using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TargAutoApp;

namespace TargAutoWPF
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Tranzactie> TranzactiiOC { get; set; }
        public ObservableCollection<Persoana> PersoaneOC { get; set; }

        private IStocareData stocare;
        private Tranzactie? tSel;
        private Persoana? pSel;

        public MainWindow()
        {
            InitializeComponent();
            stocare = StocareFactory.GetStocare();

            // Incarcam datele din fisier
            TranzactiiOC = new ObservableCollection<Tranzactie>(stocare.GetTranzactii() ?? new List<Tranzactie>());
            PersoaneOC = new ObservableCollection<Persoana>(stocare.GetPersoane() ?? new List<Persoana>());

            this.DataContext = this;
            dpDataTranzactie.SelectedDate = DateTime.Today;
        }

        #region LOGICA TRANZACTII
        private void btnAdauga_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int.TryParse(txtAn.Text, out int an);
                double.TryParse(txtPret.Text, out double pret);

                var t = new Tranzactie(
                    new Persoana(txtVanzator.Text, "", ""),
                    new Persoana(txtCumparator.Text, "", ""),
                    new Masina(txtFirma.Text, txtModel.Text, an, CuloareMasina.Alb, OptiuniMasina.Standard),
                    dpDataTranzactie.SelectedDate ?? DateTime.Now,
                    pret
                );

                stocare.AddTranzactie(t);
                TranzactiiOC.Add(t);
                ArataNotificare("✅ Tranzacție adăugată!", false);
                ResetCampuri();
            }
            catch { ArataNotificare("❌ Eroare la salvare!", true); }
        }

        private void btnSterge_Click(object sender, RoutedEventArgs e)
        {
            if (tSel != null)
            {
                stocare.DeleteTranzactie(tSel);
                TranzactiiOC.Remove(tSel);
                ArataNotificare("🗑️ Șters!", false);
            }
        }

        // Metoda comuna pentru TextBox (TextChanged) si Slider (ValueChanged)
        private void Filtre_Changed(object sender, RoutedEventArgs e)
        {
            if (stocare == null || txtCautare == null || slPretFiltru == null) return;

            string m = txtCautare.Text.ToLower();
            double p = slPretFiltru.Value;

            var fil = stocare.GetTranzactii()
                .Where(x => x.Masina.Model.ToLower().Contains(m) && x.Pret <= p)
                .ToList();

            TranzactiiOC.Clear();
            foreach (var x in fil) TranzactiiOC.Add(x);
        }

        private void dgTranzactii_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tSel = dgTranzactii.SelectedItem as Tranzactie;
            if (tSel != null)
            {
                txtVanzator.Text = tSel.Vanzator.Nume;
                txtCumparator.Text = tSel.Cumparator.Nume;
                txtFirma.Text = tSel.Masina.Firma;
                txtModel.Text = tSel.Masina.Model;
                txtAn.Text = tSel.Masina.AnFabricatie.ToString();
                txtPret.Text = tSel.Pret.ToString();
                dpDataTranzactie.SelectedDate = tSel.DataTranzactie;
            }
        }
        #endregion

        #region LOGICA CLIENTI
        private void btnAdaugaPersoana_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNumePersoana.Text))
            {
                var p = new Persoana(txtNumePersoana.Text, txtTelefonPersoana.Text, txtEmailPersoana.Text);
                stocare.AddPersoana(p);
                PersoaneOC.Add(p);
                ArataNotificare("👤 Client salvat!", false);
            }
        }

        private void lstPersoane_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pSel = lstPersoane.SelectedItem as Persoana;
            if (pSel != null)
            {
                txtNumePersoana.Text = pSel.Nume;
                txtTelefonPersoana.Text = pSel.Telefon;
                txtEmailPersoana.Text = pSel.Email;
                dgIstoricClient.ItemsSource = TranzactiiOC
                    .Where(x => x.Vanzator.Nume == pSel.Nume || x.Cumparator.Nume == pSel.Nume)
                    .ToList();
            }
        }

        private void txtCautareClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (stocare == null) return;
            string c = txtCautareClient.Text.ToLower();
            var fil = stocare.GetPersoane().Where(x => x.Nume.ToLower().Contains(c)).ToList();
            PersoaneOC.Clear();
            foreach (var x in fil) PersoaneOC.Add(x);
        }
        #endregion

        private async void ArataNotificare(string m, bool eroare)
        {
            txtNotificare.Text = m;
            NotificareCard.Background = eroare ? Brushes.Red : Brushes.Green;
            NotificareCard.Visibility = Visibility.Visible;
            await Task.Delay(2500);
            NotificareCard.Visibility = Visibility.Collapsed;
        }

        private void ResetCampuri()
        {
            txtVanzator.Clear(); txtCumparator.Clear(); txtFirma.Clear();
            txtModel.Clear(); txtAn.Clear(); txtPret.Clear();
        }
    }
}