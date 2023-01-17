using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Repositories
{
    interface ICasRepository
    {
        List<Cas> GetAll();
        Cas GetById(int id);
        int Add(Cas cas);
        void Update(int id, Cas cas);
        void Delete(int id);
        void RezervisiCas(Cas cas, Student student);
        List<Cas> VratiSveProfesoroveCasove(Profesor profesor);
        List<Cas> VratiSveNeRezervisaneProfesoroveCasove(Profesor profesor);
        void DodeliCasProfesoru(Cas cas, Profesor student);
        void OtkaziCas(int id);
        List<Cas> VratiSveStudentoveCasove(Student student);

    }
}
