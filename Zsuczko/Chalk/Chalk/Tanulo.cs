using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chalk
{
    internal class Tanulo
    {
        public string Nev { get; set; }
        public string SzulHely { get; set; }
        public DateOnly SzulIdo { get; set; }
        public string Anyja { get; set; }
        public string Lakcim { get; set; }
        public DateOnly BeiratIdo { get; set; }
        public string Szak { get; set; }
        public string Osztaly{ get; set; }
        public bool Kolis { get; set; }
        public string KoliHely { get; set; }

        public Tanulo(string nev, string szulHely, DateOnly szulIdo, string anyja, string lakcim, DateOnly beiratIdo, string szak, string osztaly, bool kolis, string koliHely)
        {
            
            Nev = nev;
            SzulHely = szulHely;
            SzulIdo = szulIdo;
            Anyja = anyja;
            Lakcim = lakcim;
            BeiratIdo = beiratIdo;
            Szak = szak;
            Osztaly = osztaly;
            Kolis = kolis;
            KoliHely = koliHely;
        }
    }
}
