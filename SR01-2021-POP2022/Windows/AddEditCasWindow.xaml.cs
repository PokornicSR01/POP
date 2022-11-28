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
    /// Interaction logic for AddEditCasWindow.xaml
    /// </summary>
    public partial class AddEditCasWindow : Window
    {

        private Cas selektovanCas;
        private EStatus selektovaniStatus;

        public AddEditCasWindow(EStatus status, Cas cas)
        {
            InitializeComponent();
            selektovanCas = cas;
            selektovaniStatus = status;

            cmbProfesor.ItemsSource = Data.Instance.Profesori;
            cmbStudent.ItemsSource = Data.Instance.Studenti;


            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj cas";
            }
            else
            {
                this.Title = "Izmeni cas";
            }
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik k = new RegistrovaniKorisnik();
            k.ID = "3";

            Profesor p = new Profesor
            {
                Korisnik =  k,
            };

            Student s = new Student
            {
                Korisnik = k,
            };

            Cas cas = new Cas
            {
                ID = txtID.Text,
                Datum = Convert.ToDateTime(txtDatum.Text),
                TrajanjeCasa = txtTrajanjeCasa.Text,
                Student = s,
                Professor = p,
                Rezervisan = false,
                Aktivan = true
            };


            if (selektovaniStatus.Equals(EStatus.DODAJ))
            {
                Data.Instance.Casovi.Add(cas);
            }

            Data.Instance.SacuvajEntitet("casovi.txt");

            this.Close();
        }
    }
}
