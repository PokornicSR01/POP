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
    /// Interaction logic for AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {
        private RegistrovaniKorisnik registrovaniKorisnik;
        private Adresa adresa;
        private Student student;
        private IStudentServices studentService = new StudentService();
        private bool isAddMode;

        public AddEditStudentWindow(Student student)
        {
            InitializeComponent();
            this.student = student.Clone() as Student;

            cmbPol.ItemsSource = Enum.GetValues(typeof(Pol));

            DataContext = this.student;

            isAddMode = false;
            txtJMBG.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
        }

        public AddEditStudentWindow()
        {
            InitializeComponent();
            cmbPol.ItemsSource = Enum.GetValues(typeof(Pol));

            Adresa adresa = new Adresa();

            var user = new RegistrovaniKorisnik
            {
                TipKorisnika = TipKorisnika.STUDENT,
                Aktivan = true,
                Adresa = adresa
            };

            student = new Student
            {
                Korisnik = user
            };

            isAddMode = true;
            DataContext = student;
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (isAddMode)
            {
                studentService.Add(student);
            }
            else
            {
                studentService.Update(student.Id, student);
            }

            Close();
        }
    }
}
