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
    /// Interaction logic for AllStudentWindow.xaml
    /// </summary>
    public partial class AllStudentWindow : Window
    {
        private StudentService studentService = new StudentService();
        private RegistrovaniKorisnik ulogovanKorisnik;

        public AllStudentWindow(RegistrovaniKorisnik ulogovanKorisnik)
        {
            InitializeComponent();
            RefreshDataGrid();
            this.ulogovanKorisnik = ulogovanKorisnik;
        }

        private void miDodajStudenta_Click(object sender, RoutedEventArgs e)
        {
            var addEditProfessorWindow = new AddEditStudentWindow();

            var successeful = addEditProfessorWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }

        private void miIzmeniStudenta_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = myDataGrid.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var professors = studentService.GetAll();

                var addEditProfessorWindow = new AddEditStudentWindow(professors[selectedIndex]);

                var successeful = addEditProfessorWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miObrisiStudenta_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = myDataGrid.SelectedItem as RegistrovaniKorisnik;

            if (selectedUser != null)
            {
                studentService.Delete(selectedUser.ID);
                RefreshDataGrid();
            }
        }

        private void RefreshDataGrid()
        {
            List<RegistrovaniKorisnik> users = studentService.GetAll().Select(p => p.Korisnik).ToList();
            myDataGrid.ItemsSource = users;
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MenuWindow mw = new MenuWindow(ulogovanKorisnik);
            mw.Show();
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
