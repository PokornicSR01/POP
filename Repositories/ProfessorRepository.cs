using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Repositories
{
    class ProfessorRepository : IProfessorRepository
    {
        public int Add(Profesor professor)
        {

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Profesori (KorisnikId, Jezik, SkolaId)
                    output inserted.Id
                    values (@KorisnikId, @Jezik, @SkolaId)";

                command.Parameters.Add(new SqlParameter("KorisnikId", professor.Korisnik.ID));
                command.Parameters.Add(new SqlParameter("Jezik", professor.Jezik));
                command.Parameters.Add(new SqlParameter("SkolaId", professor.SkolaProfesora.ID));

                return (int)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
        }

        public List<Profesor> GetAll()
        {
            List<Profesor> professors = new List<Profesor>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Profesori p, dbo.RegistrovaniKorisnici u, dbo.Adrese a where p.KorisnikId=u.id and a.Id = u.AdresaId";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Profesori");

                foreach (DataRow row in ds.Tables["Profesori"].Rows)
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
                        Jezik = row["Jezik"] as string
                    };

                    if(professor.Korisnik.Aktivan == true)
                    {
                        professors.Add(professor);
                    }
                }
            }

            return professors;
        }

        public Profesor GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Profesori p, dbo.RegistrovaniKorisnici u  where u.Id = {id} and p.KorisnikId = u.Id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Profesori");

                if (ds.Tables["Profesori"].Rows.Count > 0)
                {
                    var row = ds.Tables["Profesori"].Rows[0];

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
                        Aktivan = (bool)row["Aktivan"]
                    };

                    var profesor = new Profesor
                    {
                        Korisnik = user,
                        Id = (int)row["Id"],
                    };

                    return profesor;
                }
            }

            return null;
        }

        public void Update(int id, Profesor professor)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Profesori set 
                        Jezik = @Jezik
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("Jezik", professor.Jezik));

                command.ExecuteScalar();
            }
        }
    }
}
