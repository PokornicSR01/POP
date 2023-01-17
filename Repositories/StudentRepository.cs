using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        public int Add(Student professor)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Studenti (KorisnikId)
                    output inserted.Id
                    values (@KorisnikId)";

                command.Parameters.Add(new SqlParameter("KorisnikId", professor.Korisnik.ID));

                return (int)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
        }

        public List<Student> GetAll()
        {
            List<Student> professors = new List<Student>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Studenti p, dbo.RegistrovaniKorisnici u, dbo.Adrese a where p.KorisnikId=u.id and a.Id = u.AdresaId";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Studenti");

                foreach (DataRow row in ds.Tables["Studenti"].Rows)
                {
                    Adresa address = new Adresa
                    {
                        ID = (int)row["AdresaId"],
                        Ulica = row["Ulica"] as string,
                        Broj = row["Broj"] as string,
                        Grad = row["Grad"] as string,
                        Drzava = row["Drzava"] as string,
                    };

                    var user = new RegistrovaniKorisnik
                    {
                        ID = (int)row["KorisnikId"],
                        Ime = row["Ime"] as string,
                        Prezime = row["Prezime"] as string,
                        Email = row["Email"] as string,
                        Lozinka = row["Lozinka"] as string,
                        JMBG = row["Jmbg"] as string,
                        Pol = (Pol)Enum.Parse(typeof(Pol), row["Pol"] as string),
                        TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), row["TipKorisnika"] as string),
                        Aktivan = (bool)row["Aktivan"],
                        AdresaId = (int)row["AdresaId"],
                        Adresa = address
                    };

                    var professor = new Student
                    {
                        Id = (int)row["id"],
                        Korisnik = user
                    };

                    if (professor.Korisnik.Aktivan == true && professor.Korisnik.TipKorisnika.Equals(TipKorisnika.STUDENT))
                    {
                        professors.Add(professor);
                    }
                }
            }

            return professors;
        }

        public Student GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.RegistrovaniKorisnici u, Adrese a where u.Id = {id} and a.Id = u.AdresaId";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "RegistrovaniKorisnici");

                if (ds.Tables["RegistrovaniKorisnici"].Rows.Count > 0)
                {
                    var row = ds.Tables["RegistrovaniKorisnici"].Rows[0];

                    Adresa address = new Adresa
                    {
                        ID = (int)row["AdresaId"],
                        Ulica = row["Ulica"] as string,
                        Broj = row["Broj"] as string,
                        Grad = row["Grad"] as string,
                        Drzava = row["Drzava"] as string,
                    };

                    var user = new RegistrovaniKorisnik
                    {
                        ID = (int)row["Id"],
                        Ime = row["Ime"] as string,
                        Prezime = row["Prezime"] as string,
                        Email = row["Email"] as string,
                        Lozinka = row["Lozinka"] as string,
                        JMBG = row["Jmbg"] as string,
                        Pol = (Pol)Enum.Parse(typeof(Pol), row["Pol"] as string),
                        TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), row["TipKorisnika"] as string),
                        Aktivan = (bool)row["Aktivan"],
                        Adresa = address,
                        AdresaId = address.ID
                    };

                    var student = new Student
                    {
                        Korisnik = user,
                    };

                    return student;
                }
            }

            return null;
        }

        public Student getId(Student student)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Studenti u where u.KorisnikId = {student.Korisnik.ID}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Studenti");

                if (ds.Tables["Studenti"].Rows.Count > 0)
                {
                    var row = ds.Tables["Studenti"].Rows[0];

                    student.Id = (int)row["Id"];

                    return student;
                }
            }

            return null;
        }

        public void Update(int id, Student professor)
        {
        }

        public List<Student> VratiProfesoroveStudente(Profesor profesor)
        {
            List<Student> studenti = new List<Student>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.casovi c, dbo.studenti s, dbo.RegistrovaniKorisnici rk, dbo.Adrese a "
                        + $"where c.ProfesorId = {profesor.Id} and c.StudentId = s.Id and rk.Id = s.KorisnikID and a.id = rk.adresaId";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Studenti");

                foreach (DataRow row in ds.Tables["Studenti"].Rows)
                {
                    Adresa address = new Adresa
                    {
                        ID = (int)row["AdresaId"],
                        Ulica = row["Ulica"] as string,
                        Broj = row["Broj"] as string,
                        Grad = row["Grad"] as string,
                        Drzava = row["Drzava"] as string,
                    };

                    var user = new RegistrovaniKorisnik
                    {
                        ID = (int)row["KorisnikId"],
                        Ime = row["Ime"] as string,
                        Prezime = row["Prezime"] as string,
                        Email = row["Email"] as string,
                        Lozinka = row["Lozinka"] as string,
                        JMBG = row["Jmbg"] as string,
                        Pol = (Pol)Enum.Parse(typeof(Pol), row["Pol"] as string),
                        TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), row["TipKorisnika"] as string),
                        Aktivan = (bool)row["Aktivan"],
                        AdresaId = (int)row["AdresaId"],
                        Adresa = address
                    };

                    var student = new Student
                    {
                        Id = (int)row["id"],
                        Korisnik = user,
                    };

                    studenti.Add(student);
                }
            }

            return studenti;
        }
    }
}
