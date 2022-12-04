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
    /// Interaction logic for AllStudentWindow.xaml
    /// </summary>
    public partial class AllStudentWindow : Window
    {
        public AllStudentWindow()
        {
            InitializeComponent();
            myDataGrid.ItemsSource = Data.Instance.VratiAktivneStudente();

        }

        private void miDodajStudenta_Click(object sender, RoutedEventArgs e)
        {
            Student k = new Student();
            AddEditStudentWindow addEditStudentWindow = new AddEditStudentWindow(EStatus.DODAJ, k);

            addEditStudentWindow.Show();
            return;
        }

        private void miIzmeniStudenta_Click(object sender, RoutedEventArgs e)
        {
            Student student = (Student)myDataGrid.SelectedItem;
            Student kopijastudenta = new Student();

            Adresa adresa = new Adresa
            {
                Ulica = student.Korisnik.Adresa.Ulica,
                Broj = student.Korisnik.Adresa.Broj,
                Grad = student.Korisnik.Adresa.Grad,
                Drzava = student.Korisnik.Adresa.Drzava,
                ID = student.Korisnik.Adresa.ID,
            };

            kopijastudenta.Korisnik = student.Korisnik;

            kopijastudenta.Korisnik.Aktivan = student.Korisnik.Aktivan;
            kopijastudenta.Korisnik.Prezime = student.Korisnik.Prezime;
            kopijastudenta.Korisnik.JMBG = student.Korisnik.JMBG;
            kopijastudenta.Korisnik.Email = student.Korisnik.Email;
            kopijastudenta.Korisnik.Pol = student.Korisnik.Pol;
            kopijastudenta.Korisnik.Lozinka = student.Korisnik.Lozinka;
            kopijastudenta.Korisnik.TipKorisnika = student.Korisnik.TipKorisnika;
            kopijastudenta.Korisnik.Ime = student.Korisnik.Ime;
            kopijastudenta.Korisnik.ID = student.Korisnik.ID;
            kopijastudenta.Korisnik.Adresa = adresa;

            AddEditStudentWindow addEditStudentWindow = new AddEditStudentWindow(EStatus.IZMENI, student);

            if ((bool)!addEditStudentWindow.ShowDialog())
            {
                //kopiju postavljam umesto izmenjenog objekta
                int index = Data.Instance.Studenti.ToList().FindIndex(ko => ko.Korisnik.ID.Equals(student.Korisnik.ID));
                Data.Instance.Studenti[index] = kopijastudenta;
            }
        }

        private void miObrisiStudenta_Click(object sender, RoutedEventArgs e)
        {
            Student k = (Student)myDataGrid.SelectedItem;
            k.Korisnik.Aktivan = false;
            Data.Instance.SacuvajEntitet("studenti.txt");

        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

    }
}
