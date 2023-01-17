using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR01_2021_POP2022.Modules;

namespace LanguageSchools.Repositories
{
    interface IUserRepository
    {
        List<RegistrovaniKorisnik> GetAll();
        RegistrovaniKorisnik GetById(int id);
        int Add(RegistrovaniKorisnik user);
        int AddAdministrator(RegistrovaniKorisnik user);
        void Update(int id, RegistrovaniKorisnik user);
        void Delete(int id);
        RegistrovaniKorisnik LoginKorisnik(string username, string password);
    }
}
