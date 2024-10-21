using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikusEllenőrzőProjekt
{
    internal class c_Read_Bevit
    {
        public c_Read_Bevit(string nev, string szulhely, DateTime szulido, string anyanev, string lakcim, int naploszam, DateTime beiratkozas, string szak, string osztaly, 
          string  kollegista, string kollegium, int torszszam)
        {
            Nev = nev;
            Szulhely = szulhely;
            Szulido = szulido;
            Anyanev = anyanev;
            Lakcim = lakcim;
            Naploszam = naploszam;
            Beiratkozas = beiratkozas;
            Szak = szak;
            Osztaly = osztaly;
            Kollegista = kollegista;
            Kollegium = kollegium;
            Torszszam = torszszam;
        }

        public string Nev { get; set; }
        public string Szulhely { get; set; }
        public DateTime Szulido { get; set; }
        public string Anyanev { get; set; } 
        public string Lakcim { get; set; }
        public int Naploszam {get; set; }
        public DateTime Beiratkozas { get; set; }
        public string Szak { get; set; }    
        public string Osztaly { get; set; }
        public string Kollegista { get; set; }
        public string Kollegium { get; set; }
        public int Torszszam { get; set; }

    }
}
