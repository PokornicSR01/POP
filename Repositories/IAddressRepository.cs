
using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Repositories
{
    interface IAddressRepository
    {
        List<Adresa> GetAll();
        Adresa GetById(int id);
        int Add(Adresa address);
        void Update(int id, Adresa address);
        void Delete(int id);
    }
}
