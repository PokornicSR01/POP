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

            dgProfesori.ItemsSource = null;
            dgProfesori.ItemsSource = Data.Instance.Profesori;
        }

        private void miDodajProfesora_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik k = new RegistrovaniKorisnik();
            AddEditProfesorWindow addEditProfessorWindow = new AddEditProfesorWindow(EStatus.DODAJ, k);

            addEditProfessorWindow.Show();
            return;
        }

        private void miIzmeniProfesora_Click(object sender, RoutedEventArgs e)
        {
            // proveriti da li je nesto uopste selektovano u tabeli
            // ako nije, ispisi poruku korisniku
            RegistrovaniKorisnik k = (RegistrovaniKorisnik)dgProfesori.SelectedItem;
            //kopija originalnog korisnika
            RegistrovaniKorisnik kopijaProfesora = new RegistrovaniKorisnik();
            kopijaProfesora.Ime = k.Ime;
            kopijaProfesora.Prezime = k.Prezime;
            kopijaProfesora.Email = k.Email;
            kopijaProfesora.TipKorisnika = k.TipKorisnika;
            kopijaProfesora.Aktivan = k.Aktivan;

            AddEditProfesorWindow addEditProfessorWindow = new AddEditProfesorWindow(EStatus.IZMENI, k);


            if ((bool)!addEditProfessorWindow.ShowDialog())
            {
                //kopiju postavljam umesto izmenjenog objekta
                //int index = Data.Instance.Korisnici.ToList().FindIndex(ko => ko.Korisnik.Email.Equals(k.Korisnik.Email));
                //Data.Instance.Profesori[index] = kopijaProfesora;
            }

        }

        private void miObrisiProfesora_Click(object sender, RoutedEventArgs e)
        {
            Profesor k = (Profesor)dgProfesori.SelectedItem;
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
