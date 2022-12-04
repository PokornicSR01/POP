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
    /// Interaction logic for AddEditSkolaWindow.xaml
    /// </summary>
    public partial class AddEditSkolaWindow : Window
    {

        private Skola selektovanaSkola;
        private EStatus selektovaniStatus;

        public AddEditSkolaWindow(EStatus status, Skola skola)
        {
            InitializeComponent();
            selektovanaSkola = skola;
            selektovaniStatus = status;

            if (status.Equals(EStatus.IZMENI))
            {
                txtUlicaAdrese.Text = skola.Adressa.Ulica;
                txtIDAdrese.Text = skola.Adressa.ID;
                txtGradAdrese.Text = skola.Adressa.Grad;
                txtDrzavaAdrese.Text = skola.Adressa.Drzava;
                txtBrojAdrese.Text = skola.Adressa.Broj;
            }

            this.DataContext = skola;  //setujem binding source


            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj skolu";
            }
            else
            {
                this.Title = "Izmeni skolu";
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
                Drzava = txtDrzavaAdrese.Text,
            };

            Data.Instance.Adrese.Add(adresa);

            Skola skola = new Skola
            {
                Naziv = selektovanaSkola.Naziv,
                ID = selektovanaSkola.ID,
                Adressa = adresa,
                Aktivan = true
            };

            if (selektovaniStatus.Equals(EStatus.DODAJ))
            {
                Data.Instance.Skole.Add(skola);
            }

            Data.Instance.SacuvajEntitet("adrese.txt");
            Data.Instance.SacuvajEntitet("skole.txt");
            this.Close();
        }
    }
}
