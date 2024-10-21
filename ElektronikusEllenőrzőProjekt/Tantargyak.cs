using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektronikusEllenőrzőProjekt
{
    public class Tantargyak
    {
        public Tantargyak(string tantargy, string evfolyam, string kozSzak, int hetiora, int evesora)
        {
            this.tantargy = tantargy;
            this.evfolyam = evfolyam;
            this.kozSzak = kozSzak;
            this.hetiora = hetiora;
            this.evesora = evesora;
        }

        public string tantargy { get; set; }
        public string evfolyam { get; set; }
        public string kozSzak { get; set; }
        public int hetiora { get; set; }
        public int evesora { get; set; }
    }
}
