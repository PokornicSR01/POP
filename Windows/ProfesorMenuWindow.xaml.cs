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
    /// Interaction logic for ProfesorMenuWindow.xaml
    /// </summary>
    public partial class ProfesorMenuWindow : Window
    {
        private Profesor profesor;
        private IProfesorService profesorService = new ProfesorService();
        private ICasService casService = new CasService();
        private IStudentServices studentServices = new StudentService();
        public ProfesorMenuWindow(RegistrovaniKorisnik ulogovanKorisnik)
        {
            InitializeComponent();
            this.profesor = profesorService.GetById(ulogovanKorisnik.ID);
        }

        private void miStudenti_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.ItemsSource = studentServices.VratiProfesoroveStudente(profesor);
        }

        private void miCasovi_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.ItemsSource = casService.VratiSveProfesoroveCasove(profesor);
        }

        private void miNapraviCas_Click(object sender, RoutedEventArgs e)
        {
            var addEditCas = new AddEditCasWindow(profesor);

            var successeful = addEditCas.ShowDialog();

            if ((bool)successeful)
            {
                myDataGrid.ItemsSource = casService.VratiSveProfesoroveCasove(profesor);
            }
        }

        private void miObirisiCas_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = myDataGrid.SelectedItem as Cas;

            if (selectedUser != null && !selectedUser.Rezervisan)
            {
                casService.Delete(selectedUser.ID);
                myDataGrid.ItemsSource = casService.VratiSveProfesoroveCasove(profesor);
            }
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void miProfil_Click(object sender, RoutedEventArgs e)
        {
            AddEditProfesorWindow window = new AddEditProfesorWindow(profesor);

            var successeful = window.ShowDialog();

            if ((bool)successeful)
            {
                ProfesorMenuWindow smw = new ProfesorMenuWindow(this.profesor.Korisnik);
                smw.Show();
                this.Close();
            }
        }
    }
}
