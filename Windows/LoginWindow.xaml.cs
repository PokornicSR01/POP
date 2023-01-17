using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.Repositories;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IUserService userService = new UserService();
        private IStudentServices studentService = new StudentService();
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik registrovaniKorisnik = userService.LoginKorisnik(txtEmail.Text, txtLozinka.Password.ToString());

            if (registrovaniKorisnik != null)
            {
                if(registrovaniKorisnik.TipKorisnika.Equals(TipKorisnika.STUDENT))
                {
                    StudentMenuWindow window = new StudentMenuWindow(registrovaniKorisnik);
                    window.Show();
                    this.Close();
                }
                else if (registrovaniKorisnik.TipKorisnika.Equals(TipKorisnika.ADMINISTRATOR))
                {
                    MenuWindow mw = new MenuWindow(registrovaniKorisnik);
                    mw.Show();
                    this.Close();
                }
                else if (registrovaniKorisnik.TipKorisnika.Equals(TipKorisnika.PROFESOR))
                {
                    ProfesorMenuWindow mw = new ProfesorMenuWindow(registrovaniKorisnik);
                    mw.Show();
                    this.Close();
                }
            }

        }
    }
}
