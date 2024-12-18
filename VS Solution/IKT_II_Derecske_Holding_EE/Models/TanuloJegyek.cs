using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKT_II_Derecske_Holding_EE.Models
{
    public class TanuloJegyek
    {
        public string TanuloNev { get; set; }
        public ObservableCollection<Jegy> Szeptember{ get; set; }
        public ObservableCollection<Jegy> Oktober { get; set; }
        public ObservableCollection<Jegy> November { get; set; }
        public ObservableCollection<Jegy> December { get; set; }
        public ObservableCollection<Jegy> Januar { get; set; }
        public ObservableCollection<Jegy> Februar { get; set; }
        public ObservableCollection<Jegy> Marcius { get; set; }
        public ObservableCollection<Jegy> Aprilis { get; set; }
        public ObservableCollection<Jegy> Majus { get; set; }
        public ObservableCollection<Jegy> Junius { get; set; }
    }
}
