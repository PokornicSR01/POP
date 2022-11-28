using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
    internal interface ISkolaService
    {
        void SaveSkola(string filename);

        void ReadSkola(string filename);

        void DeleteSkola(string id);

        void SaveAdresa(string filename);

        void ReadAdresa(string filename);

    }
}
