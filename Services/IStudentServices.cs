using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
     interface IStudentServices
    {
        List<Student> GetAll();
        Student GetById(int id);
        List<Student> GetActiveStudents();
        List<Student> GetActiveStudentsByEmail(string email);
        List<Student> GetActiveStudentsOrderedByEmail();
        void Add(Student studnet);
        void Update(int id, Student student);
        void Delete(int id);
        List<RegistrovaniKorisnik> ListAllStudents();
        List<Student> VratiProfesoroveStudente(Profesor profesor);
        Student getId(Student student);

    }
}
