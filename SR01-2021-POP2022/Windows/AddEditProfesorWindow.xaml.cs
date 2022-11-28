using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SR01_2021_POP2022.Windows
{
    /// <summary>
    /// Interaction logic for AddEditProfesorWindow.xaml
    /// </summary>
    public partial class AddEditProfesorWindow : Window
    {
        private RegistrovaniKorisnik selektovaniKorisnik;
        private EStatus selektovaniStatus;

        public AddEditProfesorWindow(EStatus status, RegistrovaniKorisnik korisnik)
        {

            InitializeComponent();
            selektovaniKorisnik = korisnik;
            selektovaniStatus = status;

            cmbCas.ItemsSource = Data.Instance.Casovi;

            this.DataContext = korisnik; 

            cmbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika));

            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj profesora";
            }
            else
            {
                this.Title = "Izmeni profesora";
            }
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            Adresa adresa = new Adresa
            {
                Ulica = txtUlicaAdrese.Text,
                Broj = txtBrojAdrese.Text,
                ID = txtIDAdrese.Text,
                Grad = txtGradAdrese.Text,
                Drzava = txtDrzavaAdrese.Text
            };

            Data.Instance.Adrese.Add(adresa);

            selektovaniKorisnik.Adresa = adresa;

            Profesor profesor = new Profesor
            {
                Korisnik = selektovaniKorisnik, 
            };

            if (selektovaniStatus.Equals(EStatus.DODAJ))
            {
                Data.Instance.Profesori.Add(profesor);
            }

            Data.Instance.SacuvajEntitet("adrese.txt");
            Data.Instance.SacuvajEntitet("profesori.txt");

            this.Close();
        }

    }
}
