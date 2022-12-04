using SR01_2021_POP2022.Modules;
using System;
using System.Collections;
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
    /// Interaction logic for AllSkoleWindow.xaml
    /// </summary>
    public partial class AllSkoleWindow : Window
    {
        public AllSkoleWindow()
        {
            InitializeComponent();

            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = Data.Instance.VratiAktivneSkole();

        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        public void miIzmeniSkolu_Click(object sender, RoutedEventArgs e)
        {
            Skola skola = (Skola)myDataGrid.SelectedItem;
            Skola kopijaSkole = new Skola();

            Adresa adresa = new Adresa
            {
                Ulica = skola.Adressa.Ulica,
                Broj = skola.Adressa.Broj,
                Grad = skola.Adressa.Grad,
                Drzava = skola.Adressa.Drzava,
                ID = skola.Adressa.ID,
            };

            kopijaSkole.Aktivan = skola.Aktivan;
            kopijaSkole.Naziv = skola.Naziv;
            kopijaSkole.ID = skola.ID;
            kopijaSkole.Adressa = adresa;

            AddEditSkolaWindow addEditSkolaWindow = new AddEditSkolaWindow(EStatus.IZMENI, skola);

            if ((bool)!addEditSkolaWindow.ShowDialog())
            {
                //kopiju postavljam umesto izmenjenog objekta
                int index = Data.Instance.Skole.ToList().FindIndex(ko => ko.ID.Equals(skola.ID));
                Data.Instance.Skole[index] = kopijaSkole;
            }

        }

        public void miDodajSkolu_Click(object sender, RoutedEventArgs e)
        {
            Skola s = new Skola();
            AddEditSkolaWindow addEditSkolaWindow = new AddEditSkolaWindow(EStatus.DODAJ, s);

            addEditSkolaWindow.Show();
            return;
        }

        public void miObrisiSkolu_Click(object sender, RoutedEventArgs e)
        {
            Skola k = (Skola)myDataGrid.SelectedItem;
            k.Aktivan = false;
            Data.Instance.SacuvajEntitet("skole.txt");
        }
    }
}
