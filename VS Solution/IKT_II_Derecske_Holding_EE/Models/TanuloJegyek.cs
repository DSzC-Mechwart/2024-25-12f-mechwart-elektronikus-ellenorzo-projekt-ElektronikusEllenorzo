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
        public ObservableCollection<Jegy> Oktober { get; set; }
    }
}
