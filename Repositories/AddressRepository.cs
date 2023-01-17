using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Repositories
{
    class AddressRepository : IAddressRepository
    {
        public int Add(Adresa address)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Adrese (Ulica, Broj, Grad, Drzava)
                    output inserted.Id
                    values (@Ulica, @Broj, @Grad, @Drzava)";

                command.Parameters.Add(new SqlParameter("Ulica", address.Ulica));
                command.Parameters.Add(new SqlParameter("Broj", address.Broj));
                command.Parameters.Add(new SqlParameter("Grad", address.Grad));
                command.Parameters.Add(new SqlParameter("Drzava", address.Drzava));

                return (int)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Addresses set IsDeleted=1 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }

        public List<Adresa> GetAll()
        {
            List<Adresa> addresses = new List<Adresa>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Addresses";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Addresses");

                foreach (DataRow row in ds.Tables["Addresses"].Rows)
                {
                    var address = new Adresa
                    {
                        ID = (int)row["Id"],
                        Ulica = row["Street"] as string,
                        Broj = row["StreetNumber"] as string,
                        Grad = row["City"] as string,
                        Drzava = row["Country"] as string,
                    };

                    addresses.Add(address);
                }
            }

            return addresses;
        }

        public Adresa GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Adrese where Id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Adrese");
                if (ds.Tables["Adrese"].Rows.Count > 0)
                {
                    var row = ds.Tables["Adrese"].Rows[0];

                    var address = new Adresa
                    {
                        ID = (int)row["Id"],
                        Ulica = row["Ulica"] as string,
                        Broj = row["Broj"] as string,
                        Grad = row["Grad"] as string,
                        Drzava = row["Drzava"] as string,
                    };

                    return address;
                }
            }

            return null;
        }

        public void Update(int id, Adresa address)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Adrese set 
                        Ulica = @Street,
                        Broj = @StreetNumber,
                        Grad = @City,
                        Drzava = @Country
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("Street", address.Ulica));
                command.Parameters.Add(new SqlParameter("StreetNumber", address.Broj));
                command.Parameters.Add(new SqlParameter("City", address.Grad));
                command.Parameters.Add(new SqlParameter("Country", address.Drzava));

                command.ExecuteNonQuery();
            }
        }
    }
}
