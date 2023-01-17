using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.Repositories;
using SR01_2021_POP2022.Services;
using System;
using System.Collections;
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
        private ISkolaService skolaService = new SkolaService();
        private RegistrovaniKorisnik ulogovanKorisnik;
        public AllSkoleWindow(RegistrovaniKorisnik ulogovanKorisnik)
        {
            InitializeComponent();
            RefreshDataGrid();

            this.ulogovanKorisnik = ulogovanKorisnik;
        }
        public void miDodajSkolu_Click(object sender, RoutedEventArgs e)
        {
            var addEditSkolaWindow = new AddEditSkolaWindow();

            var successeful = addEditSkolaWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }


        public void miIzmeniSkolu_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = myDataGrid.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var skole = skolaService.GetAll();

                var addEditSkolaWindow = new AddEditSkolaWindow(skole[selectedIndex]);

                var successeful = addEditSkolaWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }

        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MenuWindow mw = new MenuWindow(ulogovanKorisnik);
            mw.Show();
        }

        public void miObrisiSkolu_Click(object sender, RoutedEventArgs e)
        {
            var selectedSkola = myDataGrid.SelectedItem as Skola;

            if (selectedSkola != null)
            {
                skolaService.Delete(selectedSkola.ID);
                RefreshDataGrid();
            }
        }

        private void RefreshDataGrid()
        {
            List<Skola> skole = skolaService.GetAll();
            myDataGrid.ItemsSource = skole;
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
