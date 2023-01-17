using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.Services;
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
        private IProfesorService professorService = new ProfesorService();
        private RegistrovaniKorisnik ulogovanKorisnik;
        public AllProfesorsWindow(RegistrovaniKorisnik ulogovanKorisnik)
        {
            InitializeComponent();
            RefreshDataGrid();
            this.ulogovanKorisnik = ulogovanKorisnik;
        }

        private void miDodajProfesora_Click(object sender, RoutedEventArgs e)
        {
            var addEditProfesorWindow = new AddEditProfesorWindow();

            var successeful = addEditProfesorWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }

        private void miIzmeniProfesora_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = myDataGrid.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var professors = professorService.GetAll();

                var addEditProfessorWindow = new AddEditProfesorWindow(professors[selectedIndex]);

                var successeful = addEditProfessorWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }
       
        private void miObrisiProfesora_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = myDataGrid.SelectedItem as RegistrovaniKorisnik;

            if (selectedUser != null)
            {
                professorService.Delete(selectedUser.ID);
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
            List<RegistrovaniKorisnik> registrovaniKorisnici = professorService.GetAll().Select(p => p.Korisnik).ToList();
            myDataGrid.ItemsSource = registrovaniKorisnici;
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
