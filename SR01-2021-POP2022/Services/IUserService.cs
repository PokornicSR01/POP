using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
     interface IUserService
     {
        void SaveUsers(string filename);

        void ReadUsers(string filename);

        void DeleteUser(string email);

     }
}
