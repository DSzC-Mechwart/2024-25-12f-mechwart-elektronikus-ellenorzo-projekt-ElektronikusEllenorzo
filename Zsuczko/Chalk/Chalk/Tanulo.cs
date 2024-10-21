using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chalk
{
    //internal class Tanulo
    //{
    //    public string Torzs { get; set; }
    //    public string Nev { get; set; }
    //    public string SzulHely { get; set; }
    //    public DateOnly SzulIdo { get; set; }
    //    public string Anyja { get; set; }
    //    public string Lakcim { get; set; }
    //    public DateOnly BeiratIdo { get; set; }
    //    public string Szak { get; set; }
    //    public string Osztaly{ get; set; }
    //    public bool Kolis { get; set; }
    //    public string KoliHely { get; set; }

    //    public Tanulo(string torzs, string nev, string szulHely, DateOnly szulIdo, string anyja, string lakcim, DateOnly beiratIdo, string szak, string osztaly, bool kolis, string koliHely)
    //    {
    //        Torzs = torzs;
    //        Nev = nev;
    //        SzulHely = szulHely;
    //        SzulIdo = szulIdo;
    //        Anyja = anyja;
    //        Lakcim = lakcim;
    //        BeiratIdo = beiratIdo;
    //        Szak = szak;
    //        Osztaly = osztaly;
    //        Kolis = kolis;
    //        KoliHely = koliHely;
    //    }



    //}
    internal class Tanulo : INotifyPropertyChanged
    {
        private string _torzs;
        private string _nev;
        private string _szulHely;
        private DateOnly _szulIdo;
        private string _anyja;
        private string _lakcim;
        private DateOnly _beiratIdo;
        private string _szak;
        private string _osztaly;
        private bool _kolis;
        private string _koliHely;

        public string Torzs
        {
            get => _torzs;
            set { _torzs = value; OnPropertyChanged(nameof(Torzs)); }
        }

        public string Nev
        {
            get => _nev;
            set { _nev = value; OnPropertyChanged(nameof(Nev)); }
        }

        public string SzulHely
        {
            get => _szulHely;
            set { _szulHely = value; OnPropertyChanged(nameof(SzulHely)); }
        }

        public DateOnly SzulIdo
        {
            get => _szulIdo;
            set { _szulIdo = value; OnPropertyChanged(nameof(SzulIdo)); }
        }

        public string Anyja
        {
            get => _anyja;
            set { _anyja = value; OnPropertyChanged(nameof(Anyja)); }
        }

        public string Lakcim
        {
            get => _lakcim;
            set { _lakcim = value; OnPropertyChanged(nameof(Lakcim)); }
        }

        public DateOnly BeiratIdo
        {
            get => _beiratIdo;
            set { _beiratIdo = value; OnPropertyChanged(nameof(BeiratIdo)); }
        }

        public string Szak
        {
            get => _szak;
            set { _szak = value; OnPropertyChanged(nameof(Szak)); }
        }

        public string Osztaly
        {
            get => _osztaly;
            set { _osztaly = value; OnPropertyChanged(nameof(Osztaly)); }
        }

        public bool Kolis
        {
            get => _kolis;
            set { _kolis = value; OnPropertyChanged(nameof(Kolis)); }
        }

        public string KoliHely
        {
            get => _koliHely;
            set { _koliHely = value; OnPropertyChanged(nameof(KoliHely)); }
        }

        public Tanulo(string torzs, string nev, string szulHely, DateOnly szulIdo, string anyja, string lakcim, DateOnly beiratIdo, string szak, string osztaly, bool kolis, string koliHely)
        {
            Torzs = torzs;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
