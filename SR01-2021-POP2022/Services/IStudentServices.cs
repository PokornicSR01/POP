using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR01_2021_POP2022.Services
{
     interface IStudentServices
    {
        void SaveStudent(string filename);

        void ReadStudents(string filename);

        void DeleteStudents(string email);
    }
}
