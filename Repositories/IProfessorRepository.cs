using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Repositories
{
    interface IProfessorRepository
    {
        List<Profesor> GetAll();
        Profesor GetById(int id);
        int Add(Profesor professor);
        void Update(int id, Profesor professor);
        void Delete(int id);
    }
}
