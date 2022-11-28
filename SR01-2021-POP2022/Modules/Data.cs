using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SR01_2021_POP2022.Services;

namespace SR01_2021_POP2022.Modules
{
    sealed class Data
    {
        private static readonly Data instance = new Data();
        public IUserService userService;
        public IUserService profesorService;
        public ISkolaService skolaService;
        public IStudentServices studentService;
        public ICasService casService;

        static Data() { }

        private Data()
        {
            userService = new UserService();
            profesorService = new ProfesorService();
            skolaService = new SkolaService();
            studentService = new StudentService();
            casService = new CasService();
        }

        public static Data Instance
        {
            get
            {
                return instance;
            }
        }

        public ObservableCollection<RegistrovaniKorisnik> Korisnici { get; set; }
        public ObservableCollection<Profesor> Profesori { get; set; }
        public ObservableCollection<Skola> Skole { get; set; }
        public ObservableCollection<Adresa> Adrese { get; set; }
        public ObservableCollection<Student> Studenti { get; set; }
        public ObservableCollection<Cas> Casovi { get; set; }


        public void Initialize()
        {
            Korisnici = new ObservableCollection<RegistrovaniKorisnik>();
            Profesori = new ObservableCollection<Profesor>();
            Skole = new ObservableCollection<Skola>();
            Adrese = new ObservableCollection<Adresa>();
            Studenti = new ObservableCollection<Student>();
            Casovi = new ObservableCollection<Cas>();


            Adresa adresa = new Adresa
            {
                Grad = "Novi Sad",
                Drzava = "Srbija",
                Ulica = "ulica1",
                Broj = "22",
                ID = "1"
            };

            RegistrovaniKorisnik korisnik1 = new RegistrovaniKorisnik();
            korisnik1.Ime = "Pera";
            korisnik1.Prezime = "Peric";
            korisnik1.Email = "pera@gmail.com";
            korisnik1.JMBG = "121346";
            korisnik1.Lozinka = "peki";
            korisnik1.Adresa = adresa;
            korisnik1.Pol = Pol.MUSKI;
            korisnik1.ID = "66";
            korisnik1.TipKorisnika = TipKorisnika.ADMINISTRATOR;
            korisnik1.Aktivan = true;

            RegistrovaniKorisnik korisnik2 = new RegistrovaniKorisnik
            {
                Email = "mika@gmail.com",
                Ime = "mika",
                Prezime = "Mikic",
                JMBG = "121346",
                Lozinka = "zika",
                Pol = Pol.ZENSKI,
                TipKorisnika = TipKorisnika.PROFESOR,
                Aktivan = false,
                ID = "7"

            };

            RegistrovaniKorisnik korisnik3 = new RegistrovaniKorisnik
            {
                Email = "mika@gmail.com",
                Ime = "mika",
                Prezime = "Mikic",
                JMBG = "121346",
                Lozinka = "zika",
                Pol = Pol.ZENSKI,
                TipKorisnika = TipKorisnika.STUDENT,
                Aktivan = false,
                ID = "7"

            };

            Student korisnik7 = new Student
            {
                Korisnik = korisnik3,

            };

            //Studenti.Add(korisnik7);

            Skola skola1 = new Skola();
            skola1.Naziv = "Skola1";
            skola1.Adressa = adresa;
            skola1.ID = "5";

            Skole.Add(skola1);

            Profesor korisnik4 = new Profesor
            {
                Korisnik = korisnik1,
                SkolaProfesora = skola1,

            };

            Profesor korisnik5 = new Profesor
            {
                Korisnik = korisnik2,
                SkolaProfesora = skola1,

            };

            //Cas cas1 = new Cas
            //{
            //    ID = "cas broj 1",
            //};
            //Cas cas2 = new Cas
            //{
            //    ID = "cas broj 2",
            //};
            //Cas cas3 = new Cas
            //{
            //    ID = "cas broj 3",
            //};
            //Casovi.Add(cas1);
            //Casovi.Add(cas2);
            //Casovi.Add(cas3);



            //korisnik4.Jezici = korisnik4.Jezici.Add("66");
            //korisnik4.Casovi = "2";

            //Korisnici.Add(korisnik);
            //Korisnici.Add(korisnik2);
            Profesori.Add(korisnik4);
            Profesori.Add(korisnik5);

        }

        public void SacuvajEntitet(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                userService.SaveUsers(filename);
            }
            else if (filename.Contains("profesori"))
            {
                profesorService.SaveUsers(filename);
            }
            else if (filename.Contains("skole"))
            {
                skolaService.SaveSkola(filename);
            }
            else if (filename.Contains("studenti"))
            {
                studentService.SaveStudent(filename);
            }
            else if (filename.Contains("casovi"))
            {
                casService.SaveCas(filename);
            }
            else if (filename.Contains("adrese"))
            {
                skolaService.SaveAdresa(filename);
            }
        }

        public void CitanjeEntiteta(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                userService.ReadUsers(filename);
            }
            else if (filename.Contains("profesori"))
            {
                profesorService.ReadUsers(filename);
            }
            else if (filename.Contains("skole"))
            {
                skolaService.ReadSkola(filename);
            }
            else if (filename.Contains("studenti"))
            {
                studentService.ReadStudents(filename);
            }
            else if (filename.Contains("casovi"))
            {
                casService.ReadCas(filename);
            }
            else if (filename.Contains("adrese"))
            {
                skolaService.ReadAdresa(filename);
            }
        }

        public Profesor VratiProfesora(string id)
        {
            Profesor p = new Profesor();

            foreach (Profesor profesor in Profesori)
            {
                if (id == profesor.Korisnik.ID)
                {
                    p = profesor;
                }
            };

            return p;
        }

        public Student VratiStudenta(string id)
        {
            Student s = new Student();

            foreach (Student student in Studenti)
            {
                if (id == student.Korisnik.ID)
                {
                    s = student;
                }
            };

            return s;
        }


        public Adresa VratiAdresu(string id)
        {
            Adresa a = new Adresa();

            foreach (Adresa adresa in Adrese)
            {
                if (id == adresa.ID)
                {
                    a = adresa;
                }
            };

            return a;
        }

        public Skola VratiSkolu(string id)
        {
            Skola s = new Skola();

            foreach (Skola skola in Skole)
            {
                if (id == skola.ID)
                {
                    s = skola;
                }
            };

            return s;
        }

        public void ObrisiProfesora(string ID)
        {
            profesorService.DeleteUser(ID);
        }
    }
}
