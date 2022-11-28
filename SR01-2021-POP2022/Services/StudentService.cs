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
    internal class StudentService : IStudentServices
    {

        public void SaveStudent(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Student student in Data.Instance.Studenti)
                {
                    file.WriteLine(student.StudentZaUpisUFajl());
                }
            }
        }

        public void ReadStudents(string filename)
        {

            Data.Instance.Profesori = new ObservableCollection<Profesor>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] studentIzFajla = line.Split(';');

                    Enum.TryParse(studentIzFajla[5], out Pol pol);
                    Enum.TryParse(studentIzFajla[6], out TipKorisnika tip);
                    Boolean.TryParse(studentIzFajla[8], out Boolean aktivan);

                    string sifraAdrese = studentIzFajla[9];
                    string sifraSkole = studentIzFajla[10];

                    Adresa adresa = Data.Instance.VratiAdresu(sifraAdrese);
                    Skola skola = Data.Instance.VratiSkolu(sifraSkole);


                    RegistrovaniKorisnik rK = new RegistrovaniKorisnik
                    {
                        Ime = studentIzFajla[0],
                        Prezime = studentIzFajla[1],
                        Email = studentIzFajla[2],
                        Lozinka = studentIzFajla[3],
                        JMBG = studentIzFajla[4],
                        Pol = pol,
                        TipKorisnika = tip,
                        ID = studentIzFajla[7],
                        Aktivan = aktivan,
                        Adresa = adresa
                    };

                    Student student = new Student
                    {
                        Korisnik = rK,
                        SkolaStudenta= skola,
                    };

                    Data.Instance.Studenti.Add(student);
                }
            }

        }

        public void DeleteStudents(string Id)
        {
            Student student = Data.Instance.Studenti.ToList().Find(p => p.Korisnik.ID.Contains(Id));
            if (student == null)
            {
                throw new UserNotFoundException($"Ne postoji taj korisnik sa tim id: {Id}");
            }
            student.Korisnik.Aktivan = false; ;
        }
    }
}
