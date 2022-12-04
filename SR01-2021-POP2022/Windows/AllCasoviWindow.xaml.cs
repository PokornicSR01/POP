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
    /// Interaction logic for AllCasoviWindow.xaml
    /// </summary>
    public partial class AllCasoviWindow : Window
    {
        public AllCasoviWindow()
        {
            InitializeComponent();
            
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = Data.Instance.VratiAktivneCasove();

        }

        private void miDodajCas_Click(object sender, RoutedEventArgs e)
        {
            Cas c = new Cas();
            AddEditCasWindow addEditCasWindow = new AddEditCasWindow(EStatus.DODAJ, c);

            addEditCasWindow.Show();
            return;
        }

        private void miIzmeniCas_Click(object sender, RoutedEventArgs e)
        {
            Cas cas = (Cas)myDataGrid.SelectedItem;
            Cas kopijaCasa = new Cas();

            kopijaCasa.TrajanjeCasa = cas._trajanjeCasa;
            kopijaCasa.Aktivan = cas.Aktivan;
            kopijaCasa.Datum = cas.Datum;
            kopijaCasa.Rezervisan = cas.Rezervisan;
            kopijaCasa.ID = cas.ID;
            kopijaCasa.Professor = cas.Professor;
            kopijaCasa.Student = cas.Student;

            AddEditCasWindow aecw = new AddEditCasWindow(EStatus.IZMENI, cas);

            if ((bool)!aecw.ShowDialog())
            {
                //kopiju postavljam umesto izmenjenog objekta
                int index = Data.Instance.Casovi.ToList().FindIndex(ko => ko.ID.Equals(cas.ID));
                Data.Instance.Casovi[index] = kopijaCasa;
            }

        }

        private void miObrisiCas_Click(object sender, RoutedEventArgs e)
        {
            Cas cas = (Cas)myDataGrid.SelectedItem;
            cas.Aktivan = false;
            Data.Instance.SacuvajEntitet("casovi.txt");
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
