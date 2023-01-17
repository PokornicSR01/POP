using LanguageSchools.Repositories;
using Microsoft.Win32;
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
    class ProfesorService : IProfesorService
    {
        private IProfessorRepository professorRepository;
        private IUserRepository userRepository;
        private IAddressRepository addressRepository;

        public ProfesorService()
        {
            professorRepository = new ProfessorRepository();
            userRepository = new UserRepository();
            addressRepository = new AddressRepository();
        }

        public Profesor GetById(int id)
        {
            return professorRepository.GetById(id);
        }

        public List<Profesor> GetAll()
        {
            return professorRepository.GetAll();
        }

        public List<Profesor> GetActiveProfessors()
        {
            return professorRepository.GetAll().Where(p => p.Korisnik.Aktivan).ToList();
        }

        public List<Profesor> GetActiveProfessorsByEmail(string email)
        {
            return professorRepository.GetAll().Where(p => p.Korisnik.Aktivan && p.Korisnik.Email.Contains(email)).ToList();
        }
        public List<Profesor> GetActiveProfessorsOrderedByEmail()
        {
            return professorRepository.GetAll().Where(p => p.Korisnik.Aktivan).OrderBy(p => p.Korisnik.Email).ToList();
        }

        public void Add(Profesor professor)
        {
            var adressID = addressRepository.Add(professor.Korisnik.Adresa);
            professor.Korisnik.Adresa.ID = adressID;

            var userId = userRepository.Add(professor.Korisnik);
            professor.Korisnik.ID = userId;

            professorRepository.Add(professor);
        }

        public void Update(int id, Profesor professor)
        {
            addressRepository.Update(professor.Korisnik.Adresa.ID, professor.Korisnik.Adresa);
            userRepository.Update(professor.Korisnik.ID, professor.Korisnik);
            professorRepository.Update(id, professor);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
            professorRepository.Delete(id);
        }

        public List<RegistrovaniKorisnik> ListAllStudents()
        {
            throw new NotImplementedException();
        }

    }
}
