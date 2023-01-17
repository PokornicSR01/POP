using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Repositories
{
    interface ISkolaRepository
    {
        List<Skola> GetAll();
        Skola GetById(int id);
        int Add(Skola skola);
        void Update(int id, Skola skola);
        void Delete(int id);
        List<Profesor> VratiSkolineProfesore(Skola skola);
        List<Profesor> DodeliSkoluProfesoru(List<Profesor> profesori);
        List<Skola> VratiSkolePoNazivu(string naziv);
        List<Skola> VratiSkolePoJeziku(string jezik);
    }
}
