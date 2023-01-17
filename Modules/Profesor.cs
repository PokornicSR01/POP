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
        public int Id { get; set; }

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

        private string _jezik;
        public string Jezik
        {
            get { return _jezik; }
            set { _jezik = value; }
        }

        public Profesor() { }

        public override string ToString()
        {
            return _korisnik.Ime + " " + _korisnik.Prezime + ", email:" + _korisnik.Email;
        }

        public object Clone()
        {
            return new Profesor
            {
                Id = Id,
                Korisnik = Korisnik.Clone() as RegistrovaniKorisnik,
                Jezik = Jezik,
            };
        }
    }
}
