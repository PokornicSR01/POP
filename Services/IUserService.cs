using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
     interface IUserService
     {
        List<RegistrovaniKorisnik> GetAll();
        List<RegistrovaniKorisnik> GetActiveUsers();
        void Add(RegistrovaniKorisnik user);
        void Update(int id, RegistrovaniKorisnik user);
        void Delete(int id);
        RegistrovaniKorisnik LoginKorisnik(string korisnickoIme, string Lozinka);

    }
}
