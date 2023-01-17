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
    /// Interaction logic for AddEditSkolaWindow.xaml
    /// </summary>
    public partial class AddEditSkolaWindow : Window
    {

        private Skola skola;
        private ISkolaService skolaService = new SkolaService();
        private bool isAddMode;

        public AddEditSkolaWindow(Skola skola)
        {
            InitializeComponent();
            this.skola = skola.Clone() as Skola;

            DataContext = this.skola;
        }

        public AddEditSkolaWindow()
        {
            InitializeComponent();
            
            Adresa adresa = new Adresa();

            skola = new Skola
            {
                Adressa = adresa,
                Aktivan = true,
            };

            isAddMode = true;
            DataContext = skola;
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (isAddMode)
            {
                skolaService.Add(skola);
            }
            else
            {
                skolaService.Update(skola.ID, skola);
            }

            DialogResult = true;
            Close();
        }
    }
}
