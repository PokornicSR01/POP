using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.Services;
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
        private ICasService casService = new CasService();
        private RegistrovaniKorisnik ulogovanKorisnik;
        public AllCasoviWindow(RegistrovaniKorisnik ulogovanKorisnik)
        {
            InitializeComponent();
            RefreshDataGrid();

            this.ulogovanKorisnik = ulogovanKorisnik;
        }

        private void miDodajCas_Click(object sender, RoutedEventArgs e)
        {
            var addEditProfessorWindow = new AddEditCasWindow();

            var successeful = addEditProfessorWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }

        private void miIzmeniCas_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = myDataGrid.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var professors = casService.GetAll();

                var addEditProfessorWindow = new AddEditCasWindow(professors[selectedIndex]);

                var successeful = addEditProfessorWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miObrisiCas_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = myDataGrid.SelectedItem as Cas;

            if (selectedUser != null)
            {
                casService.Delete(selectedUser.ID);
                RefreshDataGrid();
            }
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MenuWindow mw = new MenuWindow(ulogovanKorisnik);
            mw.Show();
        }
        private void RefreshDataGrid()
        {
            List<Cas> casovi = casService.GetAll().ToList();
            myDataGrid.ItemsSource = casovi;
        }

        private void dgProfessors_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Error" || e.PropertyName == "IsValid")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

    }
}
