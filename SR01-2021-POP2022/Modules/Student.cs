using Accessibility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Modules
{
    public class Student 
    {
        private RegistrovaniKorisnik _korisnik;
        public RegistrovaniKorisnik Korisnik
        {
            get { return _korisnik;}
            set { _korisnik = value;}
        }

        private Skola _skolaStudenta;
        public Skola SkolaStudenta
        {
            get { return _skolaStudenta; }
            set { _skolaStudenta = value; }
        }

        private ObservableCollection<Cas> _casovi;
        public ObservableCollection<Cas> Casovi
        {
            get { return _casovi; }
            set { _casovi = value; }
        }

        public string StudentZaUpisUFajl()
        {
            return _korisnik.Ime + ";" + _korisnik.Prezime + ";" + _korisnik.Email + ";" + _korisnik.Lozinka + ";" + _korisnik.JMBG + ";"
                + _korisnik.Pol + ";" + _korisnik.TipKorisnika + ";" + _korisnik.ID + ";" + _korisnik.Aktivan + ";" + _korisnik.Adresa.ID + ";" + SkolaStudenta.ID + ";" +"";
        }

        public Student() { }
        
        public override string ToString()
        {
            return "Ja sam student i moje ime je:" + _korisnik.Ime + ", a moj email je :" + _korisnik.Email;
        }
    }
}
