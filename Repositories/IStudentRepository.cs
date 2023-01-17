using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Repositories
{
    internal interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(int id);
        int Add(Student student);
        void Update(int id, Student student);
        void Delete(int id);
        List<Student> VratiProfesoroveStudente(Profesor profesor);
        Student getId(Student student);
    }
}
