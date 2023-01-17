using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
     interface ICasService
    {
        List<Cas> GetAll();
        List<Cas> GetActiveUsers();
        void Add(Cas cas);
        void Update(int id, Cas cas);
        void Delete(int id);
        void RezervisiCas(Cas cas,Student student);
        List<Cas> VratiSveProfesoroveCasove(Profesor profesor);
        List<Cas> VratiSveNeRezervisaneProfesoroveCasove(Profesor profesor);
        List<Cas> VratiSveStudentoveCasove(Student student);
        void OtkaziCas(int id);
        void DodeliCasuProfesora(Cas cas, Profesor profesor);
    }
}
