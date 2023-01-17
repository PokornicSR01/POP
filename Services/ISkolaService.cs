using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
    internal interface ISkolaService
    {
        List<Skola> GetAll();
        List<Skola> GetActiveUsers();
        void Add(Skola skola);
        void Update(int id, Skola skola);
        void Delete(int id);
        List<Profesor> DodeliSkoluProfesoru(List<Profesor> profesori);
        List<Profesor> VratiSkolineProfesore(Skola skola);
        List<Skola> VratiSkolePoNazivu(string naziv);
        List<Skola> VratiSkolePoJeziku(string jezik);
    }
}
