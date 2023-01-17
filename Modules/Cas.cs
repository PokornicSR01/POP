using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SR01_2021_POP2022.Modules
{
    public class Cas
    {

        public Profesor _profesor;
        public Profesor Profesor
        {
            get { return _profesor; }
            set { _profesor = value; }
        }

        public DateTime _datum;
        public DateTime Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }

        public string _trajanjeCasa;
        public string TrajanjeCasa
        {
            get { return _trajanjeCasa;}
            set {_trajanjeCasa = value;}
        }

        public string _jezik;
        public string Jezik
        {
            get { return _jezik; }
            set { _jezik = value; }
        }

        public Boolean _rezervisan;
        public Boolean Rezervisan
        {
            get { return _rezervisan; } 
            set { _rezervisan = value;}
        }

        public Student _student;
        public Student Student
        {
            get { return _student; }
            set {_student = value;}
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public Boolean _aktivan;
        public Boolean Aktivan
        {
            get { return _aktivan;}
            set { _aktivan = value;}
        }

        public object Clone()
        {
            return new Cas
            {
                ID = ID,
                Datum = Datum,
                TrajanjeCasa = TrajanjeCasa,
                Aktivan = Aktivan,
                Rezervisan = Rezervisan,
                Jezik = Jezik,
                Profesor = Profesor,
            };
        }



        public Cas() {}

    }
}
