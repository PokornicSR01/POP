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
    /// Interaction logic for AllSkoleWindow.xaml
    /// </summary>
    public partial class AllSkoleWindow : Window
    {
        public AllSkoleWindow()
        {
            InitializeComponent();

            dgSkole.ItemsSource = null;
            dgSkole.ItemsSource = Data.Instance.Skole;
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        public void miIzmeniSkolu_Click(object sender, RoutedEventArgs e)
        {

        }
        public void miDodajSkolu_Click(object sender, RoutedEventArgs e)
        {
            Skola s = new Skola();
            AddEditSkolaWindow addEditSkolaWindow = new AddEditSkolaWindow(EStatus.DODAJ, s);

            addEditSkolaWindow.Show();
            return;
        }

        public void miObrisiSkolu_Click(object sender, RoutedEventArgs e)
        {
            Skola k = (Skola)dgSkole.SelectedItem;
            k.Aktivan = false;
            Data.Instance.SacuvajEntitet("skole.txt");
        }
    }
}
