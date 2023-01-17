using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SR01_2021_POP2022.Modules
{
    public class Skola
    {
        //šifra, naziv, adresa na kojoj se nalazi, lista jezika koje je moguće pohađati

        public string _naziv;
        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        public Adresa _adresa;
        public Adresa Adressa
        {
            get { return _adresa; }
            set { _adresa = value; }

        }

        public string _jezik;
        public string Jezik
        {
            get { return _jezik; }
            set { _jezik = value; }
        }

        public int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private Boolean _aktivan;
        public Boolean Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }

        public Skola() { }

        public object Clone()
        {
            return new Skola
            {
                Naziv = Naziv,
                Aktivan = Aktivan,
                Adressa = Adressa,
                Jezik = Jezik,
                ID = ID,
            };
        }

        public override string ToString()
        {
            return this.Naziv;
        }

    }
}
