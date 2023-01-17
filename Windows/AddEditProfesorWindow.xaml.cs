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
    /// Interaction logic for AddEditProfesorWindow.xaml
    /// </summary>
    public partial class AddEditProfesorWindow : Window
    {
        private Profesor professor;
        private IProfesorService professorService = new ProfesorService();
        private ISkolaService skolaService = new SkolaService();

        private bool isAddMode;

        public AddEditProfesorWindow(Profesor professor)
        {
            InitializeComponent();
            this.professor = professor.Clone() as Profesor;

            cmbPol.ItemsSource = Enum.GetValues(typeof(Pol));
            cmbSkola.ItemsSource = skolaService.GetAll();

            DataContext = this.professor;

            isAddMode = false;
        }

        public AddEditProfesorWindow()
        {
            InitializeComponent();
            cmbPol.ItemsSource = Enum.GetValues(typeof(Pol));
            cmbSkola.ItemsSource = skolaService.GetAll();

            Adresa adresa = new Adresa();

            var user = new RegistrovaniKorisnik
            {
                TipKorisnika = TipKorisnika.PROFESOR,
                Aktivan = true,
                Adresa = adresa
            };

            professor = new Profesor
            {
                Korisnik = user
            };

            isAddMode = true;
            DataContext = professor;
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (isAddMode)
            {
                professor.SkolaProfesora = cmbSkola.SelectedItem as Skola;
                professorService.Add(professor);
            }
            else
            {
                professorService.Update(professor.Id, professor);
            }

            DialogResult = true;
            Close();
        }

    }
}
