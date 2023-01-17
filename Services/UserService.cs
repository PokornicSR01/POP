using LanguageSchools.Repositories;
using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.MyExceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
    class UserService : IUserService
    {
        private IUserRepository repostory;

        public UserService()
        {
            repostory = new UserRepository();
        }

        public List<RegistrovaniKorisnik> GetActiveUsers()
        {
            return repostory.GetAll().Where(p => p.Aktivan).ToList();
        }

        public List<RegistrovaniKorisnik> GetAll()
        {
            return repostory.GetAll();
        }

        public void Add(RegistrovaniKorisnik user)
        {
            repostory.Add(user);
        }

        public void Update(int id, RegistrovaniKorisnik user)
        {
            repostory.Update(id, user);
        }

        public void Delete(int id)
        {
            repostory.Delete(id);
        }

        RegistrovaniKorisnik IUserService.LoginKorisnik(string korisnickoIme, string Lozinka)
        {
            return repostory.LoginKorisnik(korisnickoIme, Lozinka);
        }
    }
}
