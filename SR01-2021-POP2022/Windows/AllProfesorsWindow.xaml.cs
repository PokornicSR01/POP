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
    /// Interaction logic for AllProfesorsWindow.xaml
    /// </summary>
    public partial class AllProfesorsWindow : Window
    {
        public AllProfesorsWindow()
        {
            InitializeComponent();

            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = Data.Instance.VratiAktivneProfesori();

        }

        private void miDodajProfesora_Click(object sender, RoutedEventArgs e)
        {
            Profesor k = new Profesor();
            AddEditProfesorWindow addEditProfessorWindow = new AddEditProfesorWindow(EStatus.DODAJ, k);

            addEditProfessorWindow.Show();
            return;
        }

        private void miIzmeniProfesora_Click(object sender, RoutedEventArgs e)
        {
            Profesor profesor = (Profesor)myDataGrid.SelectedItem;
            Profesor kopijaProfesora = new Profesor();

            Adresa adresa = new Adresa
            {
                Ulica = profesor.Korisnik.Adresa.Ulica,
                Broj = profesor.Korisnik.Adresa.Broj,
                Grad = profesor.Korisnik.Adresa.Grad,
                Drzava = profesor.Korisnik.Adresa.Drzava,
                ID = profesor.Korisnik.Adresa.ID,
            };

            kopijaProfesora.Korisnik = profesor.Korisnik;

            kopijaProfesora.Korisnik.Aktivan = profesor.Korisnik.Aktivan;
            kopijaProfesora.Korisnik.Prezime = profesor.Korisnik.Prezime;
            kopijaProfesora.Korisnik.JMBG = profesor.Korisnik.JMBG;
            kopijaProfesora.Korisnik.Email = profesor.Korisnik.Email;
            kopijaProfesora.Korisnik.Pol = profesor.Korisnik.Pol;
            kopijaProfesora.Korisnik.Lozinka = profesor.Korisnik.Lozinka;
            kopijaProfesora.Korisnik.TipKorisnika = profesor.Korisnik.TipKorisnika;
            kopijaProfesora.Korisnik.Ime = profesor.Korisnik.Ime;
            kopijaProfesora.Korisnik.ID = profesor.Korisnik.ID;
            kopijaProfesora.Korisnik.Adresa = adresa;

            AddEditProfesorWindow addEditProfesorWindow = new AddEditProfesorWindow(EStatus.IZMENI, profesor);

            if ((bool)!addEditProfesorWindow.ShowDialog())
            {
                //kopiju postavljam umesto izmenjenog objekta
                int index = Data.Instance.Profesori.ToList().FindIndex(ko => ko.Korisnik.ID.Equals(profesor.Korisnik.ID));
                Data.Instance.Profesori[index] = kopijaProfesora;
            }
        }

        private void miObrisiProfesora_Click(object sender, RoutedEventArgs e)
        {
            Profesor k = (Profesor)myDataGrid.SelectedItem;
            k.Korisnik.Aktivan = false;
            Data.Instance.SacuvajEntitet("profesori.txt");
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
