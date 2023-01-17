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
    class SkolaService : ISkolaService
    {
        private ISkolaRepository repository;
        private IAddressRepository addressRepository;

        public SkolaService()
        {
            repository = new SkolaRepository();
            addressRepository = new AddressRepository();
        }

        public List<Profesor> DodeliSkoluProfesoru(List<Profesor> profesori)
        {
            return repository.DodeliSkoluProfesoru(profesori);
        }

        public List<Profesor> VratiSkolineProfesore(Skola skola)
        {
            return repository.VratiSkolineProfesore(skola);
        }

        public List<Skola> VratiSkolePoNazivu(string naziv)
        {
            return repository.VratiSkolePoNazivu(naziv);
        }

        void ISkolaService.Add(Skola skola)
        {
            var adressID = addressRepository.Add(skola.Adressa);
            skola.Adressa.ID = adressID;

            repository.Add(skola);
        }

        void ISkolaService.Delete(int id)
        {
            repository.Delete(id);
        }

        List<Skola> ISkolaService.GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        List<Skola> ISkolaService.GetAll()
        {
            return repository.GetAll();
        }

        void ISkolaService.Update(int id, Skola skola)
        {
            addressRepository.Update(skola.Adressa.ID, skola.Adressa);
            repository.Update(id, skola);
        }

        public List<Skola> VratiSkolePoJeziku(string jezik)
        {
            return repository.VratiSkolePoJeziku(jezik);
        }
    }
}
