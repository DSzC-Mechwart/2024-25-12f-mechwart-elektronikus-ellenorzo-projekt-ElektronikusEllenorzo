using IKT_II_Derecske_Holding_EE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IKT_II_Derecske_Holding_EE.Ablakok.TanarPanel
{
    /// <summary>
    /// Interaction logic for Statisztika.xaml
    /// </summary>
    public partial class Statisztika : UserControl
    {
        List<Tanulo_Obj> tanulok;
        string szak;
        List<Jegy> osztalyJegyek;
        public Statisztika(string szak, List<Jegy> osztalyJegyek, List<Tanulo_Obj> _tanulok)
        {
            InitializeComponent();
            this.szak = szak;
            this.osztalyJegyek = osztalyJegyek; // Where jegy.Jegy_Ertek != -1
            tanulok = _tanulok;


        }
    }
}
