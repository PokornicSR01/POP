using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.Services;
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
        private ISkolaService skolaService = new SkolaService();

        public MainWindow()
        {
            InitializeComponent();
            myDataGrid.ItemsSource = skolaService.GetAll();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lW = new LoginWindow();

            lW.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var addEditStudentWindow = new AddEditStudentWindow();

            addEditStudentWindow.Show();
        }

        private void miSkole_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.ItemsSource = skolaService.GetAll();
        }

        private void miProfesoriUSkoli_Click(object sender, RoutedEventArgs e)
        {
            var selectedSkola = myDataGrid.SelectedItem as Skola;
            if(selectedSkola != null) 
            {
                myDataGrid.ItemsSource = skolaService.VratiSkolineProfesore(selectedSkola);
            }
        }

        private void txtPretragaPoJezicima_KeyUp(object sender, KeyEventArgs e)
        {
            PretraziPoJezicima();
        }

        private void PretraziPoJezicima()
        {
            string jezik = txtPretragaPoJezicima.Text.Trim();
            if (jezik != null)
            {
                myDataGrid.ItemsSource = skolaService.VratiSkolePoJeziku(jezik);
            }
        }

        private void txtPretragaPoNazivu_KeyUp(object sender, KeyEventArgs e)
        {
            string naziv = txtPretragaPoNazivu.Text.Trim();
            if (naziv != null)
            {
                myDataGrid.ItemsSource = skolaService.VratiSkolePoNazivu(naziv);
            }
        }
    }
}
