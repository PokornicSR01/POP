using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SR01_2021_POP2022.Modules
{
    public class Profesor
    {

        private RegistrovaniKorisnik _korisnik;
        public RegistrovaniKorisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }

        private Skola _skola;
        public Skola SkolaProfesora
        {
            get { return _skola; }
            set { _skola = value; }
        }

        private ObservableCollection<string> _jezici;
        public ObservableCollection<string> Jezici
        {
            get { return _jezici; }
            set { _jezici = value; }
        }

        private ObservableCollection<Cas> _casovi;
        public ObservableCollection<Cas> Casovi
        {
            get { return _casovi; }
            set { _casovi = value; }
        }

        public Profesor() { }

        public override string ToString()
        {
            return "Ja sam profesor i moje ime je:" + _korisnik.Ime + ", a moj email je :" + _korisnik.Email;
        }
  
        public string jeziciZaUpisUFajl()
        {
            string s = "";

            if (_jezici != null)
            {
                for (int i = 0; i < _jezici.Count; i++)
                {
                    if (i == _jezici.Count - 1)
                    {
                        s += _jezici[i];
                    }
                    else
                    {
                        s += _jezici[i] + ",";
                    }
                }
            }
            return s;
        }

        public string casoviZaUpisUFajl()
        {
            string s = "";

            if (_casovi != null)
            {
                for (int i = 0; i < _casovi.Count; i++)
                {
                    if (i == _casovi.Count - 1)
                    {
                        s += _casovi[i].ID;
                    }
                    else
                    {
                        s += _casovi[i].ID + ",";
                    }
                }
            }
            return s;
        }

        public string ProfesorZaUpisUFajl()
        {
                return _korisnik.Ime + ";" + _korisnik.Prezime + ";" + _korisnik.Email + ";" + _korisnik.Lozinka + ";" + _korisnik.JMBG + ";"
                + _korisnik.Pol + ";" + _korisnik.TipKorisnika + ";" + _korisnik.ID + ";" + _korisnik.Aktivan + ";" + _korisnik.Adresa.ID + ";" + "" + ";" + "";
        }

    }
}
