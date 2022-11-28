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

            dgStudenti.ItemsSource = null;
            dgStudenti.ItemsSource = Data.Instance.Studenti;
        }

        private void miDodajStudenta_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik k = new RegistrovaniKorisnik();
            AddEditStudentWindow addEditStudentWindow = new AddEditStudentWindow(EStatus.DODAJ, k);

            addEditStudentWindow.Show();
            return;
        }

        private void miIzmeniStudenta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miObrisiStudenta_Click(object sender, RoutedEventArgs e)
        {
            Student k = (Student)dgStudenti.SelectedItem;
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
