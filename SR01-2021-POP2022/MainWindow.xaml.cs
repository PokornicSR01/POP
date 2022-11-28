using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SR01_2021_POP2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Data.Instance.Initialize();

            Data.Instance.CitanjeEntiteta("adrese.txt");
            Data.Instance.SacuvajEntitet("adrese.txt");

            Data.Instance.CitanjeEntiteta("skole.txt");
            Data.Instance.SacuvajEntitet("skole.txt");

            Data.Instance.CitanjeEntiteta("studenti.txt");
            Data.Instance.SacuvajEntitet("studenti.txt");

            Data.Instance.CitanjeEntiteta("profesori.txt");
            Data.Instance.SacuvajEntitet("profesori.txt");

            Data.Instance.CitanjeEntiteta("casovi.txt");
            Data.Instance.SacuvajEntitet("casovi.txt");

        }

        private void miProfesor_Click(object sender, RoutedEventArgs e)
        {
            AllProfesorsWindow mainWindow = new AllProfesorsWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void miStudenti_Click(object sender, RoutedEventArgs e)
        {
            AllStudentWindow asw = new AllStudentWindow();
            this.Hide(); 
            asw.Show();
        }

        private void miSkole_Click(object sender, RoutedEventArgs e)
        {
            AllSkoleWindow asw = new AllSkoleWindow();
            this.Hide(); 
            asw.Show();
        }

        private void miCasovi_Click(object sender, RoutedEventArgs e)
        {
            AllCasoviWindow acw = new AllCasoviWindow();
            this.Hide();
            acw.Show();

        }
    }
}
