using SR01_2021_POP2022.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
    internal interface IAdresaService
    {
        int SaveAdresa(Object obj);

        void ReadAdresa();

        void DeleteAdresa(int id);
    }
}
