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
    /// Interaction logic for ReservisiCasWindow.xaml
    /// </summary>
    public partial class ReservisiCasWindow : Window
    {
        private Cas cas;
        IStudentServices sS = new StudentService();
        IProfesorService pS = new ProfesorService();
        ICasService cS = new CasService();
        public ReservisiCasWindow(Cas cas)
        {
            InitializeComponent();
            cmbStudent.ItemsSource = sS.GetAll();

            this.cas = cas;
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            Student s = cmbStudent.SelectedItem as Student;
            cS.RezervisiCas(cas, s);
        }
    }
}
