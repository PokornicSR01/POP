using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
    internal class AdresaService : IAdresaService
    {

        public int SaveAdresa(Object obj)
        {
            Adresa adresa = obj as Adresa;

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"insert into dbo.Adrese(Id, Ulica,
                 Broj, Grad, Drzava)
                output inserted.id values(@Id, @Ulica, @Broj, @Grad, @Drzava)";

                command.Parameters.Add(new SqlParameter("Id", adresa.ID));
                command.Parameters.Add(new SqlParameter("Ulica", adresa.Ulica));
                command.Parameters.Add(new SqlParameter("Broj", adresa.Broj));
                command.Parameters.Add(new SqlParameter("Grad", adresa.Grad));
                command.Parameters.Add(new SqlParameter("Drzava", adresa.Drzava));
                
                return (int)command.ExecuteScalar();
            }
        }

        public void ReadAdresa()
        {


        }

        public void DeleteAdresa(int id)
        {

        }
    }
}
