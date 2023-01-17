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
        public int Id { get; set; }

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

        public object Clone()
        {
            return new Student
            {
                Id = Id,
                Korisnik = Korisnik.Clone() as RegistrovaniKorisnik
            };
        }

        public Student() { }
        
        public override string ToString()
        {
            return _korisnik.Ime + " " + _korisnik.Prezime + ", email:" + _korisnik.Email;
        }
    }
}
