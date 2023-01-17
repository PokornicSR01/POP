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
    /// Interaction logic for AddEditCasWindow.xaml
    /// </summary>
    public partial class AddEditCasWindow : Window
    {
        private Cas cas;
        private ICasService casService = new CasService();
        private IProfesorService profesorService = new ProfesorService();
        private bool isAddMode;
        private bool profesorDodajeCas;
        
        public AddEditCasWindow(Cas cas)
        {
            InitializeComponent();

            this.cas = cas.Clone() as Cas;

            cmbProfesor.ItemsSource = profesorService.GetAll();
           
            DataContext = this.cas;

            isAddMode = false;
        }

        public AddEditCasWindow()
        { 
            InitializeComponent();
            cmbProfesor.ItemsSource = profesorService.GetAll();

            cas = new Cas
            {
                Aktivan = true,
                Rezervisan = false
            };

            profesorDodajeCas = false;
            isAddMode = true;
            DataContext = cas;
        }

        public AddEditCasWindow(Profesor profesor)
        {
            InitializeComponent();
            cmbProfesor.SelectedItem = profesor;

            cas = new Cas
            {
                Aktivan = true,
                Rezervisan = false,
                Profesor = profesor
            };

            isAddMode = true;
            profesorDodajeCas = true;
            DataContext = cas;
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            int compare = DateTime.Compare(Convert.ToDateTime(txtDatum.Text), DateTime.Now);
            if(compare > 0)
            {
                if (isAddMode)
                {
                    string datum = txtDatum.Text;
                    cas.Datum = Convert.ToDateTime(datum);
                    if (!profesorDodajeCas)
                    {
                        cas.Profesor = cmbProfesor.SelectedItem as Profesor;
                    }
                    casService.Add(cas);
                }
                else
                {
                    casService.Update(cas.ID, cas);
                }
            }

            DialogResult = true;
            this.Close();
        }
    }
}
