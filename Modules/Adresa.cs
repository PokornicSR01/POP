﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SR01_2021_POP2022.Modules
{
    public class Adresa
    {
        public int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string _ulica;

        public string Ulica
        {
            get { return _ulica; }
            set { _ulica = value; }
        }

        public string _broj;

        public string Broj
        {
            get { return _broj; }
            set { _broj = value; }
        }

        public string _grad;

        public string Grad
        {
            get { return _grad; }
            set { _grad = value; }
        }

        private string _drzava;
        public string Drzava
        {
            get { return _drzava; }
            set { _drzava = value; }
        }

        public string AdresaZaUpisUFajl()
        {

            return  Ulica + ";" + ID + ";" + Broj + ";" + Grad + ";" + Drzava;
        }

        public object Clone()
        {
            return new Adresa
            {
                ID = ID,
                Ulica = Ulica,
                Broj = Broj,
                Grad = Grad,
                Drzava = Drzava
            };
        }

        public override string ToString()
        {
            return Ulica + " " + Broj + " , " + Grad;
        }
    }
}
