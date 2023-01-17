using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Repositories
{
    class SkolaRepository : ISkolaRepository
    {
        public SkolaRepository() { }

        public List<Profesor> DodeliSkoluProfesoru(List<Profesor> profesori)
        {
            foreach(Profesor p in profesori)
            {
                List<Skola> skole = new List<Skola>();
            }
            return profesori;
        }

        public List<Skola> VratiSkolePoJeziku(string jezik)
        {
            List<Skola> skole = new List<Skola>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Skole s, dbo.Adrese a where s.AdresaId = a.Id and s.jezik like'%{jezik}%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Skole");

                foreach (DataRow row in ds.Tables["Skole"].Rows)
                {
                    Adresa address = new Adresa
                    {
                        ID = (int)row["AdresaId"],
                        Ulica = row["Ulica"] as string,
                        Broj = row["Broj"] as string,
                        Grad = row["Grad"] as string,
                        Drzava = row["Drzava"] as string,
                    };

                    var skola = new Skola
                    {
                        ID = (int)row["Id"],
                        Naziv = row["Naziv"] as string,
                        Aktivan = (bool)row["Aktivan"],
                        Adressa = address,
                        Jezik = row["Jezik"] as string
                    };

                    if (skola.Aktivan == true)
                    {
                        skole.Add(skola);
                    }
                }
            }
            return skole;
        }

        public List<Skola> VratiSkolePoNazivu(string naziv)
        {
            List<Skola> skole = new List<Skola>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Skole s, dbo.Adrese a where s.AdresaId = a.Id and s.naziv like'%{naziv}%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Skole");

                foreach (DataRow row in ds.Tables["Skole"].Rows)
                {
                    Adresa address = new Adresa
                    {
                        ID = (int)row["AdresaId"],
                        Ulica = row["Ulica"] as string,
                        Broj = row["Broj"] as string,
                        Grad = row["Grad"] as string,
                        Drzava = row["Drzava"] as string,
                    };

                    var skola = new Skola
                    {
                        ID = (int)row["Id"],
                        Naziv = row["Naziv"] as string,
                        Aktivan = (bool)row["Aktivan"],
                        Adressa = address,
                        Jezik = row["Jezik"] as string
                    };

                    if (skola.Aktivan == true)
                    {
                        skole.Add(skola);
                    }
                }
            }
            return skole;
        }

        public List<Profesor> VratiSkolineProfesore(Skola skola)
        {
            List<Profesor> professors = new List<Profesor>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Skole s, dbo.Profesori p, dbo.RegistrovaniKorisnici u, dbo.Adrese a where p.KorisnikId=u.id" +
                    $" and a.Id = u.AdresaId and p.SkolaId = {skola.ID}";
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
                        Jezik = row["Jezik"] as string,
                        SkolaProfesora = skola
                    };

                    if (professor.Korisnik.Aktivan == true)
                    {
                        professors.Add(professor);
                    }
                }
            }

            return professors;
        }

        int ISkolaRepository.Add(Skola skola)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Skole (Naziv, Aktivan, AdresaId, Jezik)
                    output inserted.Id
                    values (@Naziv, @Aktivan, @AdresaId, @Jezik)";

                command.Parameters.Add(new SqlParameter("Naziv", skola.Naziv));
                command.Parameters.Add(new SqlParameter("Aktivan", skola.Aktivan));
                command.Parameters.Add(new SqlParameter("Jezik", skola.Jezik));
                command.Parameters.Add(new SqlParameter("AdresaId", skola.Adressa.ID));

                return (int)command.ExecuteScalar();
            }
        }

        void ISkolaRepository.Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Skole set Aktivan=0 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }

        List<Skola> ISkolaRepository.GetAll()
        {
            List<Skola> skole = new List<Skola>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Skole s, dbo.Adrese a where s.AdresaId = a.Id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Skole");

                foreach (DataRow row in ds.Tables["Skole"].Rows)
                {
                    Adresa address = new Adresa
                    {
                        ID = (int)row["AdresaId"],
                        Ulica = row["Ulica"] as string,
                        Broj = row["Broj"] as string,
                        Grad = row["Grad"] as string,
                        Drzava = row["Drzava"] as string,
                    };

                    var skola = new Skola
                    {
                        ID = (int)row["Id"],
                        Naziv = row["Naziv"] as string,
                        Aktivan = (bool)row["Aktivan"],
                        Adressa= address,
                        Jezik = row["Jezik"] as string
                    };

                    if(skola.Aktivan == true)
                    { 
                        skole.Add(skola);
                    }
                }
            }
            return skole;
        }

        Skola ISkolaRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void ISkolaRepository.Update(int id, Skola skola)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Skole set 
                        Naziv = @Naziv
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("Naziv", skola.Naziv));

                command.ExecuteScalar();
            }
        }
    }
}
