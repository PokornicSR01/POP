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
    class ProfesorService : IUserService, IProfesorService
    {
        public void DeleteUser(string Id)
        {
            Profesor profesor = Data.Instance.Profesori.ToList().Find(p => p.Korisnik.ID.Contains(Id));
            if (profesor == null)
            {
                throw new UserNotFoundException($"Ne postoji taj korisnik sa email adresom {Id}");
            }
            profesor.Korisnik.Aktivan = false; 
        }

        public List<RegistrovaniKorisnik> ListAllStudents()
        {
            throw new NotImplementedException();
        }

        public void ReadUsers(string filename)
        {
            Data.Instance.Profesori = new ObservableCollection<Profesor>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] profesorIzFajla = line.Split(';');

                    Enum.TryParse(profesorIzFajla[5], out Pol pol);
                    Enum.TryParse(profesorIzFajla[6], out TipKorisnika tip);
                    Boolean.TryParse(profesorIzFajla[8], out Boolean aktivan);

                    string sifraSkole = profesorIzFajla[10];
                    string sifraAdrese = profesorIzFajla[9];

                    Adresa adresa = Data.Instance.VratiAdresu(sifraAdrese);

                    Skola skola = Data.Instance.VratiSkolu(sifraSkole);

                    RegistrovaniKorisnik rK = new RegistrovaniKorisnik
                    {
                        Ime = profesorIzFajla[0],
                        Prezime = profesorIzFajla[1],
                        Email = profesorIzFajla[2],
                        Lozinka = profesorIzFajla[3],
                        JMBG = profesorIzFajla[4],
                        Pol = pol,
                        TipKorisnika = tip,
                        ID = profesorIzFajla[7],
                        Adresa = adresa,
                        Aktivan = aktivan

                    };

                    Profesor profesor = new Profesor
                    {
                        Korisnik = rK,
                        SkolaProfesora = skola
                    };

                    Data.Instance.Profesori.Add(profesor);
                }
            }
        }

        public void SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Profesor profesor in Data.Instance.Profesori)
                {
                    file.WriteLine(profesor.ProfesorZaUpisUFajl());
                }
            }
        }

    }
}
