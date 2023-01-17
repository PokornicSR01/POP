using LanguageSchools.Repositories;
using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.MyExceptions;
using SR01_2021_POP2022.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
    internal class StudentService : IStudentServices
    {

        private IStudentRepository studentRepository;
        private IUserRepository userRepository;
        private IAddressRepository addressRepository;

        public StudentService()
        {
            studentRepository = new StudentRepository();
            userRepository = new UserRepository();
            addressRepository = new AddressRepository();
        }

        public Student GetById(int id)
        {
            return studentRepository.GetById(id);
        }

        public List<Student> GetAll()
        {
            return studentRepository.GetAll();
        }

        public List<Student> GetActiveProfessors()
        {
            return studentRepository.GetAll().Where(p => p.Korisnik.Aktivan).ToList();
        }

        public List<Student> GetActiveProfessorsByEmail(string email)
        {
            return studentRepository.GetAll().Where(p => p.Korisnik.Aktivan && p.Korisnik.Email.Contains(email)).ToList();
        }
        public List<Student> GetActiveProfessorsOrderedByEmail()
        {
            return studentRepository.GetAll().Where(p => p.Korisnik.Aktivan).OrderBy(p => p.Korisnik.Email).ToList();
        }

        public void Add(Student professor)
        {
            var adressID = addressRepository.Add(professor.Korisnik.Adresa);
            professor.Korisnik.Adresa.ID = adressID;

            var userId = userRepository.Add(professor.Korisnik);
            professor.Korisnik.ID = userId;

            studentRepository.Add(professor);
        }

        public void Update(int id, Student professor)
        {
            addressRepository.Update(professor.Korisnik.Adresa.ID, professor.Korisnik.Adresa);
            userRepository.Update(professor.Korisnik.ID, professor.Korisnik);
            studentRepository.Update(id, professor);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
            studentRepository.Delete(id);
        }

        public List<RegistrovaniKorisnik> ListAllStudents()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetActiveStudents()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetActiveStudentsByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetActiveStudentsOrderedByEmail()
        {
            throw new NotImplementedException();
        }

        public List<Student> VratiProfesoroveStudente(Profesor profesor)
        {
            return studentRepository.VratiProfesoroveStudente(profesor);
        }

        public Student getId(Student student)
        {
            return studentRepository.getId(student);
        }
    }
}
