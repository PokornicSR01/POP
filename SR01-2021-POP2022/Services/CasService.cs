using SR01_2021_POP2022.Modules;
using SR01_2021_POP2022.MyExceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
    internal class CasService : ICasService
    {
        public void SaveCas(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Cas cas in Data.Instance.Casovi)
                {
                    file.WriteLine(cas.CasZaUpisUFajl());
                }
            }
        }

        public void ReadCas(string filename)
        {
            Data.Instance.Casovi = new ObservableCollection<Cas>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] casIzFajla = line.Split(';');

                    //string sifraProf = casIzFajla[1];
                    //string sifraStudenta = casIzFajla[2];

                    //Profesor profesor = Data.Instance.VratiProfesora(sifraProf);
                    //Student student = Data.Instance.VratiStudenta(sifraStudenta);


                    Boolean.TryParse(casIzFajla[5], out Boolean rezervisan);
                    Boolean.TryParse(casIzFajla[6], out Boolean aktivan);


                    Cas cas = new Cas
                    {
                        ID = casIzFajla[0],
                        //Professor = profesor,
                        //Student = student,
                        Datum = Convert.ToDateTime(casIzFajla[3]),
                        TrajanjeCasa = casIzFajla[4],
                        Rezervisan = rezervisan,
                        Aktivan = aktivan,
                    };

                    Data.Instance.Casovi.Add(cas);
                }
            }
        }

        public void DeleteCas(string id)
        {
            Cas cas = Data.Instance.Casovi.ToList().Find(p =>p.ID.Contains(id));
            if (cas == null)
            {
                throw new UserNotFoundException($"Ne postoji taj cas");
            }
            cas.Aktivan = false;
        }
    }
}
