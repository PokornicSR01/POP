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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private RegistrovaniKorisnik ulogovanKorisnik;
        public MenuWindow(RegistrovaniKorisnik ulogovanKorisnik)
        {
            InitializeComponent();
            Data.Instance.Initialize();
            this.ulogovanKorisnik = ulogovanKorisnik;
        }

        private void miProfesor_Click(object sender, RoutedEventArgs e)
        {
            AllProfesorsWindow mainWindow = new AllProfesorsWindow(ulogovanKorisnik);
            this.Hide();
            mainWindow.Show();
        }

        private void miStudenti_Click(object sender, RoutedEventArgs e)
        {
            AllStudentWindow asw = new AllStudentWindow(ulogovanKorisnik);
            this.Hide();
            asw.Show();
        }

        private void miSkole_Click(object sender, RoutedEventArgs e)
        {
            AllSkoleWindow asw = new AllSkoleWindow(ulogovanKorisnik);
            this.Hide();
            asw.Show();
        }

        private void miCasovi_Click(object sender, RoutedEventArgs e)
        {
            AllCasoviWindow acw = new AllCasoviWindow(ulogovanKorisnik);
            this.Hide();
            acw.Show();
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();

        }
    }
}

