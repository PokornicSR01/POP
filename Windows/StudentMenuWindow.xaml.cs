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
    /// Interaction logic for StudentMenuWindow.xaml
    /// </summary>
    public partial class StudentMenuWindow : Window
    {
        private ICasService casService = new CasService();
        private IProfesorService profesorService = new ProfesorService();
        private IStudentServices studentService = new StudentService();
        private Student student;
        public StudentMenuWindow(RegistrovaniKorisnik registrovaniKorisnik)
        {
            InitializeComponent();
            this.student = studentService.GetById(registrovaniKorisnik.ID);
            this.student = studentService.getId(this.student);
        }

        private void miProfesori_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.ItemsSource = profesorService.GetAll();
        }

        private void miProfil_Click(object sender, RoutedEventArgs e)
        {
            AddEditStudentWindow window = new AddEditStudentWindow(student);

            var successeful = window.ShowDialog();

            if ((bool)successeful)
            {
                StudentMenuWindow smw = new StudentMenuWindow(this.student.Korisnik);
                smw.Show();
                this.Close();
            }
        }

        private void miCasovi_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.ItemsSource = casService.GetAll();
        }

        private void miRezervisiCas_Click(object sender, RoutedEventArgs e)
        {
            var selectedCas = myDataGrid.SelectedItem as Cas;

            if(selectedCas != null)
            {
                casService.RezervisiCas(selectedCas, student);
                myDataGrid.ItemsSource = casService.VratiSveStudentoveCasove(student);
            }
        }

        private void miVidiProfesoroveCasove_Click(object sender, RoutedEventArgs e)
        {
            var selectedProfesor = myDataGrid.SelectedItem as Profesor;
            if (selectedProfesor != null)
            {
                myDataGrid.ItemsSource = casService.VratiSveNeRezervisaneProfesoroveCasove(selectedProfesor); 
            }
        }

        private void miRezervisaniCasovi_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.ItemsSource = casService.VratiSveStudentoveCasove(student);
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();

        }

        private void miOtkaziCas_Click(object sender, RoutedEventArgs e)
        {
            var selectedCas = myDataGrid.SelectedItem as Cas;
            casService.OtkaziCas(selectedCas.ID);
            myDataGrid.ItemsSource = casService.VratiSveStudentoveCasove(student);
        }
    }
}
