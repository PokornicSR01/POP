using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
     interface ICasService
    {
        void SaveCas(string filename);

        void ReadCas(string filename);

        void DeleteCas(string email);
    }
}
