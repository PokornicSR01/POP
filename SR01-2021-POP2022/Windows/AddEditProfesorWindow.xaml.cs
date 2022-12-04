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
        private Profesor selektovaniKorisnik;
        private EStatus selektovaniStatus;

        public AddEditProfesorWindow(EStatus status, Profesor korisnik)
        {

            InitializeComponent();
            selektovaniKorisnik = korisnik;
            selektovaniStatus = status;

            cmbPol.ItemsSource = Enum.GetValues(typeof(Pol));


            if (status.Equals(EStatus.IZMENI))
            {
                txtUlicaAdrese.Text = korisnik.Korisnik.Adresa.Ulica;
                txtIDAdrese.Text = korisnik.Korisnik.Adresa.ID;
                txtGradAdrese.Text = korisnik.Korisnik.Adresa.Grad;
                txtDrzavaAdrese.Text = korisnik.Korisnik.Adresa.Drzava;
                txtBrojAdrese.Text = korisnik.Korisnik.Adresa.Broj;
                txtEmail.Text = korisnik.Korisnik.Email;
                txtID.Text = korisnik.Korisnik.ID;
                txtIme.Text = korisnik.Korisnik.Ime;
                txtPrezime.Text = korisnik.Korisnik.Prezime;
                txtLozinka.Text = korisnik.Korisnik.Lozinka;
                txtJMBG.Text = korisnik.Korisnik.JMBG;
                txtIDAdrese.IsEnabled = false;
                txtID.IsEnabled = false;
                cmbPol.IsEnabled = false;
                txtJMBG.IsEnabled = false;
            }

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
            if (selektovaniStatus.Equals(EStatus.IZMENI))
            {
                string IDAdrese = txtIDAdrese.Text;
                Adresa adresa = Data.Instance.VratiAdresu(IDAdrese);

                selektovaniKorisnik.Korisnik.Ime = txtIme.Text;
                selektovaniKorisnik.Korisnik.Prezime = txtPrezime.Text;
                selektovaniKorisnik.Korisnik.ID = txtID.Text;
                selektovaniKorisnik.Korisnik.JMBG = txtJMBG.Text;
                selektovaniKorisnik.Korisnik.Email = txtEmail.Text;
                selektovaniKorisnik.Korisnik.Lozinka = txtLozinka.Text;
                selektovaniKorisnik.Korisnik.Aktivan = true;
                selektovaniKorisnik.Korisnik.TipKorisnika = TipKorisnika.PROFESOR;
                selektovaniKorisnik.Korisnik.Adresa = adresa;
                selektovaniKorisnik.Korisnik.Adresa.Ulica = txtUlicaAdrese.Text;
                selektovaniKorisnik.Korisnik.Adresa.Broj = txtBrojAdrese.Text;
                selektovaniKorisnik.Korisnik.Adresa.Grad = txtGradAdrese.Text;
                selektovaniKorisnik.Korisnik.Adresa.Drzava = txtDrzavaAdrese.Text;

                Data.Instance.SacuvajEntitet("adrese.txt");
                Data.Instance.SacuvajEntitet("profesori.txt");

            }
            else
            {
                Adresa adresa = new Adresa
                {
                    Ulica = txtUlicaAdrese.Text,
                    Broj = txtBrojAdrese.Text,
                    ID = txtIDAdrese.Text,
                    Grad = txtGradAdrese.Text,
                    Drzava = txtDrzavaAdrese.Text
                };

                RegistrovaniKorisnik rk = new RegistrovaniKorisnik
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    ID = txtID.Text,
                    JMBG = txtJMBG.Text,
                    Email= txtEmail.Text,
                    Lozinka= txtLozinka.Text,
                    Adresa = adresa,
                    Aktivan = true,
                    TipKorisnika = TipKorisnika.PROFESOR,
                    Pol = (Pol)cmbPol.SelectedItem,
                };

                Data.Instance.Adrese.Add(adresa);

                Profesor profesor = new Profesor
                {
                    Korisnik = rk,
                };
                
                Data.Instance.Profesori.Add(profesor);

                Data.Instance.SacuvajEntitet("adrese.txt");
                Data.Instance.SacuvajEntitet("profesori.txt");

            }

            this.Close();
        }

    }
}
