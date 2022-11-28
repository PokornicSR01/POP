using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {

        private RegistrovaniKorisnik selektovaniKorisnik;
        private EStatus selektovaniStatus;


        public AddEditStudentWindow(EStatus status, RegistrovaniKorisnik korisnik)
        {
            InitializeComponent();
            selektovaniKorisnik = korisnik;
            selektovaniStatus = status;

            this.DataContext = korisnik;  

            cmbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika));

            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj studenta";
            }
            else
            {
                this.Title = "Izmeni studenta";
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

            Student student = new Student
            {
                Korisnik = selektovaniKorisnik
            };

            if (selektovaniStatus.Equals(EStatus.DODAJ))
            {
                Data.Instance.Studenti.Add(student);
            }

            Data.Instance.SacuvajEntitet("adrese.txt");
            Data.Instance.SacuvajEntitet("studenti.txt");

            this.Close();
        }
    }
}
