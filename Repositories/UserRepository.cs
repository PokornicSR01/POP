using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SR01_2021_POP2022.Modules;

namespace LanguageSchools.Repositories
{
    class UserRepository : IUserRepository
    {
        public UserRepository()
        {
        }

        public int Add(RegistrovaniKorisnik user)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.RegistrovaniKorisnici (Email, Lozinka, Ime, Prezime, Jmbg, Pol, TipKorisnika, Aktivan, AdresaID)
                    output inserted.Id
                    values (@Email, @Password, @FirstName, @LastName, @Jmbg, @Gender, @UserType, @IsActive, @AddressId)";

               

                command.Parameters.Add(new SqlParameter("Email", user.Email));
                command.Parameters.Add(new SqlParameter("Password", user.Lozinka));
                command.Parameters.Add(new SqlParameter("FirstName", user.Ime));
                command.Parameters.Add(new SqlParameter("LastName", user.Prezime));
                command.Parameters.Add(new SqlParameter("Jmbg", user.JMBG));
                command.Parameters.Add(new SqlParameter("Gender", user.Pol));
                command.Parameters.Add(new SqlParameter("UserType", user.TipKorisnika));
                command.Parameters.Add(new SqlParameter("AddressId", user.Adresa.ID));
                command.Parameters.Add(new SqlParameter("IsActive", user.Aktivan));

                return (int)command.ExecuteScalar();
            }
        }

        public int AddAdministrator(RegistrovaniKorisnik user)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.RegistrovaniKorisnici (Email, Lozinka, Ime, Prezime, Jmbg, Pol, TipKorisnika, Aktivan, AdresaID)
                    output inserted.Id
                    values (@Email, @Password, @FirstName, @LastName, @Jmbg, @Gender, @UserType, @IsActive, @AddressId)";

                command.Parameters.Add(new SqlParameter("Email", user.Email));
                command.Parameters.Add(new SqlParameter("Password", user.Lozinka));
                command.Parameters.Add(new SqlParameter("FirstName", user.Ime));
                command.Parameters.Add(new SqlParameter("LastName", user.Prezime));
                command.Parameters.Add(new SqlParameter("Jmbg", user.JMBG));
                command.Parameters.Add(new SqlParameter("Gender", user.Pol));
                command.Parameters.Add(new SqlParameter("UserType", user.TipKorisnika));
                command.Parameters.Add(new SqlParameter("AddressId", user.Adresa.ID));
                command.Parameters.Add(new SqlParameter("IsActive", user.Aktivan));

                return (int)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.RegistrovaniKorisnici set Aktivan=0 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }

        public List<RegistrovaniKorisnik> GetAll()
        {
            List<RegistrovaniKorisnik> users = new List<RegistrovaniKorisnik>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.RegistrovaniKorisnici";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "RegistrovaniKorisnici");

                foreach (DataRow row in ds.Tables["RegistrovaniKorisnici"].Rows)
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

                    if (user.Aktivan)
                    {
                        users.Add(user);
                    }

                }
            }

            return users;
        }

        public RegistrovaniKorisnik GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.RegistrovaniKorisnici u, dbo.Adrese a where u.Id={id} and a.id = u.AdresaId";
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

                    if (user.Aktivan)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        public RegistrovaniKorisnik LoginKorisnik(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.RegistrovaniKorisnici u, dbo.Adrese a where u.Email like '{email}' and u.Lozinka like'{password}' and a.id = u.AdresaId";
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

                    if (user.Aktivan)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        public void Update(int id, RegistrovaniKorisnik user)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.RegistrovaniKorisnici set 
                        Ime = @FirstName,
                        Prezime = @LastName,
                        Lozinka = @Password,
                        Pol = @Gender,
                        TipKorisnika = @UserType
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("FirstName", user.Ime));
                command.Parameters.Add(new SqlParameter("LastName", user.Prezime));
                command.Parameters.Add(new SqlParameter("Password", user.Lozinka));
                command.Parameters.Add(new SqlParameter("Gender", user.Pol));
                command.Parameters.Add(new SqlParameter("UserType", user.TipKorisnika));

                command.ExecuteScalar();
            }
        }



    }
}
