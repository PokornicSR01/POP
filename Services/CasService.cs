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
using System.Windows.Controls;

namespace SR01_2021_POP2022.Services
{
    public class CasService : ICasService
    {
        private ICasRepository repository;
        private IProfessorRepository professorRepository;

        public CasService() 
        {
            repository = new CasRepository();
        }

        public void DodeliCasProfesoru(Cas cas, Profesor profesor)
        {
            repository.DodeliCasProfesoru(cas, profesor);
        }

        public void DodeliCasuProfesora(Cas cas, Profesor profesor)
        {
            repository.DodeliCasProfesoru(cas, profesor);
        }

        public void OtkaziCas(int id)
        {
            repository.OtkaziCas(id);
        }

        public void RezervisiCas(Cas cas, Profesor profesor, Student student)
        {
            throw new NotImplementedException();
        }

        public List<Cas> VratiSveNeRezervisaneProfesoroveCasove(Profesor profesor)
        {
            return repository.VratiSveNeRezervisaneProfesoroveCasove(profesor);
        }

        public List<Cas> VratiSveProfesoroveCasove(Profesor profesor)
        {
            return repository.VratiSveProfesoroveCasove(profesor);
        }

        public List<Cas> VratiSveStudentoveCasove(Student student)
        {
            return repository.VratiSveStudentoveCasove(student);
        }

        void ICasService.Add(Cas cas)
        {
            repository.Add(cas);
        }

        void ICasService.Delete(int id)
        {
            repository.Delete(id);
        }

        List<Cas> ICasService.GetActiveUsers()
        {
            return repository.GetAll().Where(p => p.Aktivan).ToList();
        }

        List<Cas> ICasService.GetAll()
        {
            return repository.GetAll();
        }

        void ICasService.RezervisiCas(Cas cas, Student student)
        {
            repository.RezervisiCas(cas, student);
        }

        void ICasService.Update(int id, Cas cas)
        {
            repository.Update(id, cas);
        }
    }
}
