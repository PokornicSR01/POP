using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
    interface IProfesorService
    {
        List<Profesor> GetAll();
        Profesor GetById(int id);
        List<Profesor> GetActiveProfessors();
        List<Profesor> GetActiveProfessorsByEmail(string email);
        List<Profesor> GetActiveProfessorsOrderedByEmail();
        void Add(Profesor profesor);
        void Update(int id, Profesor profesor);
        void Delete(int id);
        List<RegistrovaniKorisnik> ListAllStudents();
    }
}
