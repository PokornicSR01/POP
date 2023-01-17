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
using System.Security.Cryptography.Xml;

namespace SR01_2021_POP2022.Modules
{
    sealed class Data
    {
        private static readonly Data instance = new Data();
        public static readonly string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IUserService userService;
        public IUserService profesorService;
        public ISkolaService skolaService;
        public IStudentServices studentService;
        public ICasService casService;
        public IAdresaService adresaService;

        static Data() { }

        private Data()
        {
            userService = new UserService();
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
        }

        public ObservableCollection<Profesor> VratiAktivneProfesori()
        {
            ObservableCollection<Profesor> aktivniProfesori = new ObservableCollection<Profesor>();

            foreach (Profesor profesor in Profesori)
            {
                if (profesor.Korisnik.Aktivan)
                {
                    aktivniProfesori.Add(profesor);
                }
            }
   

            return aktivniProfesori;
        }

        public ObservableCollection<Skola> VratiAktivneSkole()
        {
            ObservableCollection<Skola> aktivneSkole = new ObservableCollection<Skola>();

            foreach (Skola skola in Skole)
            {
                if (skola.Aktivan)
                {
                    aktivneSkole.Add(skola);
                }
            }

            return aktivneSkole;
        }

        public ObservableCollection<Student> VratiAktivneStudente()
        {
            ObservableCollection<Student> aktivniStudenti = new ObservableCollection<Student>();

            foreach (Student student in Studenti)
            {
                if (student.Korisnik.Aktivan)
                {
                    aktivniStudenti.Add(student);
                }
            }

            return aktivniStudenti;
        }

        public ObservableCollection<Cas> VratiAktivneCasove()
        {
            ObservableCollection<Cas> aktivniCasovi = new ObservableCollection<Cas>();

            foreach (Cas cas in Casovi)
            {
                if (cas.Aktivan)
                {
                    aktivniCasovi.Add(cas);
                }
            }

            return aktivniCasovi;
        }


        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
