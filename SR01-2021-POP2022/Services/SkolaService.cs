using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.MyExceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
    class SkolaService : ISkolaService
    {

        public void SaveSkola(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Skola skola in Data.Instance.Skole)
                {
                    file.WriteLine(skola.SkolaZaUpisUFajl());
                }
            }
        }
        public void ReadSkola(string filename)
        {
            Data.Instance.Skole = new ObservableCollection<Skola>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] skolaIzFajla = line.Split(';');

                    string sifra = skolaIzFajla[1];
                    Adresa adresa = Data.Instance.VratiAdresu(sifra);
                    Boolean.TryParse(skolaIzFajla[4], out Boolean aktivan);

                    Skola skola = new Skola
                    {
                        Naziv = skolaIzFajla[0],
                        Adressa = adresa,
                        ID = skolaIzFajla[3],
                        Aktivan = aktivan
                    };

                    Data.Instance.Skole.Add(skola);
                }
            }
        }

        public void DeleteSkola(string Id)
        {
            Profesor profesor = Data.Instance.Profesori.ToList().Find(p => p.Korisnik.ID.Contains(Id));
            if (profesor == null)
            {
                throw new UserNotFoundException($"Ne postoji taj korisnik sa email adresom {Id}");
            }
            profesor.Korisnik.Aktivan = false; ;
        }

        public void SaveAdresa(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Adresa adresa in Data.Instance.Adrese)
                {
                    file.WriteLine(adresa.AdresaZaUpisUFajl());
                }
            }
        }

        public void ReadAdresa(string filename)
        {
            Data.Instance.Adrese = new ObservableCollection<Adresa>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] adresaIzFajla = line.Split(';');

                    Adresa adresa = new Adresa
                    {
                        Ulica = adresaIzFajla[0],
                        ID = adresaIzFajla[1],
                        Broj = adresaIzFajla[2],
                        Grad = adresaIzFajla[3],
                        Drzava = adresaIzFajla[4],
                    };

                    Data.Instance.Adrese.Add(adresa);
                }
            }
        }


    }
}
