using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SR01_2021_POP2022.Repositories
{
    class CasRepository : ICasRepository
    {

        public CasRepository() { }

        public List<Cas> VratiSveProfesoroveCasove(Profesor profesor)
        {
            List<Cas> casovi = new List<Cas>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from casovi c, RegistrovaniKorisnici rk, profesori p where rk.Id = {profesor.Korisnik.ID} and c.ProfesorId = p.Id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Casovi");

                foreach (DataRow row in ds.Tables["Casovi"].Rows)
                {

                    var cas = new Cas
                    {
                        ID = (int)row["Id"],
                        Datum = Convert.ToDateTime(row["Datum"]),
                        TrajanjeCasa = row["TrajanjeCasa"] as string,
                        Jezik = row["Jezik"] as string,
                        Rezervisan = (bool)row["Rezervisan"],
                        Aktivan = (bool)row["Aktivan"],
                        Profesor = profesor
                    };

                    if (cas.Aktivan)
                    {
                        casovi.Add(cas);
                    }
                    
                }
            }

            return casovi;
        }

        int ICasRepository.Add(Cas cas)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into dbo.Casovi (Datum, TrajanjeCasa, Rezervisan, Aktivan, Jezik, ProfesorId)
                output inserted.Id values (@Datum, @TrajanjeCasa, @Rezervisan, @Aktivan, @Jezik, @ProfesorId)";

                command.Parameters.Add(new SqlParameter("Datum", cas.Datum.ToString()));
                command.Parameters.Add(new SqlParameter("TrajanjeCasa", cas.TrajanjeCasa));
                command.Parameters.Add(new SqlParameter("Rezervisan", cas.Rezervisan));
                command.Parameters.Add(new SqlParameter("Aktivan", cas.Aktivan));
                command.Parameters.Add(new SqlParameter("Jezik", cas.Jezik));
                command.Parameters.Add(new SqlParameter("ProfesorId", cas.Profesor.Id));

                return (int)command.ExecuteScalar();
            }
           
        }

        void ICasRepository.Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Casovi set Aktivan=0 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }

        List<Cas> ICasRepository.GetAll()
        {
            List<Cas> casovi = new List<Cas>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Casovi c, dbo.Profesori p, dbo.RegistrovaniKorisnici u, dbo.Adrese a " +
                    "where p.KorisnikId=u.id and a.Id = u.AdresaId and c.ProfesorId = p.Id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Casovi");

                foreach (DataRow row in ds.Tables["Casovi"].Rows)
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

                    var professor = new Profesor
                    {
                        Id = (int)row["id"],
                        Korisnik = user,
                        Jezik = row["Jezik"] as string,
                    };

                    var cas = new Cas
                    {
                        ID = (int)row["Id"],
                        Datum = Convert.ToDateTime(row["Datum"]),
                        TrajanjeCasa = row["TrajanjeCasa"] as string,
                        Rezervisan = (bool)row["Rezervisan"],
                        Aktivan = (bool)row["Aktivan"],
                        Profesor = professor,
                        Jezik = row["Jezik"] as string
                    };

                    if(cas.Aktivan == true)
                    {
                        casovi.Add(cas);
                    }
                }
            }

            return casovi;
        }

        Cas ICasRepository.GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Casovi where Id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Casovi");
                if (ds.Tables["Casovi"].Rows.Count > 0)
                {
                    var row = ds.Tables["Casovi"].Rows[0];

                    var cas = new Cas
                    {
                        ID = (int)row["Id"],
                        Datum = DateTime.Parse(row["Datum"] as string),
                        TrajanjeCasa = row["TrajanjeCasa"] as string,
                        Aktivan = (bool)row["Aktivan"]
                    };

                    return cas;
                }
            }

            return null;
        }

        void ICasRepository.RezervisiCas(Cas cas, Student student)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Casovi set 
                        StudentId = @StudentId,
                        Rezervisan = 1
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", cas.ID));
                command.Parameters.Add(new SqlParameter("StudentId", student.Id));

                command.ExecuteScalar();
            }
        }

        void ICasRepository.DodeliCasProfesoru(Cas cas, Profesor profesor)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Casovi set 
                        ProfesorId = @ProfesorId
                        Rezervisan = 1
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", cas.ID));
                command.Parameters.Add(new SqlParameter("ProfesorId", profesor.Id));

                command.ExecuteScalar();
            }
        }

        void ICasRepository.Update(int id, Cas cas)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Casovi set 
                        Datum = @Datum,
                        TrajanjeCasa = @TrajanjeCasa,
                        Rezervisan = @Rezervisan,
                        Aktivan = @Aktivan,
                        Jezik = @Jezik
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("Datum", cas.Datum.ToString()));
                command.Parameters.Add(new SqlParameter("TrajanjeCasa", cas.TrajanjeCasa));
                command.Parameters.Add(new SqlParameter("Rezervisan", cas.Rezervisan));
                command.Parameters.Add(new SqlParameter("Jezik", cas.Jezik));
                command.Parameters.Add(new SqlParameter("Aktivan", cas.Aktivan));

                command.ExecuteScalar();
            }
        }

        public List<Cas> VratiSveStudentoveCasove(Student student)
        {
            List<Cas> casovi = new List<Cas>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from casovi c, RegistrovaniKorisnici rk, Profesori p where StudentId = {student.Id} and rK.Id = p.KorisnikId and c.ProfesorId = p.Id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Casovi");

                foreach (DataRow row in ds.Tables["Casovi"].Rows)
                {
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
                    };

                    var professor = new Profesor
                    {
                        Id = (int)row["ProfesorId"],
                        Korisnik = user,
                        Jezik = row["Jezik"] as string
                    };

                    var cas = new Cas
                    {
                        ID = (int)row["Id"],
                        Datum = Convert.ToDateTime(row["Datum"]),
                        TrajanjeCasa = row["TrajanjeCasa"] as string,
                        Jezik = row["Jezik"] as string,
                        Rezervisan = (bool)row["Rezervisan"],
                        Aktivan = (bool)row["Aktivan"],
                        Profesor = professor,
                        Student = student
                    };

                    if (cas.Aktivan)
                    {
                        casovi.Add(cas);
                    }

                }
            }

            return casovi;
        }

        public List<Cas> VratiSveNeRezervisaneProfesoroveCasove(Profesor profesor)
        {
            List<Cas> casovi = new List<Cas>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from casovi c, RegistrovaniKorisnici rk, profesori p where rk.Id = {profesor.Korisnik.ID} and c.ProfesorId = p.Id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Casovi");

                foreach (DataRow row in ds.Tables["Casovi"].Rows)
                {

                    var cas = new Cas
                    {
                        ID = (int)row["Id"],
                        Datum = Convert.ToDateTime(row["Datum"]),
                        TrajanjeCasa = row["TrajanjeCasa"] as string,
                        Jezik = row["Jezik"] as string,
                        Rezervisan = (bool)row["Rezervisan"],
                        Aktivan = (bool)row["Aktivan"],
                        Profesor = profesor
                    };

                    if (cas.Aktivan && !cas.Rezervisan)
                    {
                        casovi.Add(cas);
                    }

                }
            }

            return casovi;
        }

        public void OtkaziCas(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Casovi set 
                        StudentId = NULL,
                        Rezervisan = 0
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));

                command.ExecuteScalar();
            }
        }
    }
}
