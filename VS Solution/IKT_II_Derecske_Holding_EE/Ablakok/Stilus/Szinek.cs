using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace IKT_II_Derecske_Holding_EE.Ablakok.Stilus
{
    static class Szinek
    {

        public static Brush RAISIN_BLACK
        {
            get => (Brush)new BrushConverter().ConvertFrom("#32292F");
        }

        public static Brush XANTHOUS
        {
            get => (Brush)new BrushConverter().ConvertFrom("#FFC15E");
        }

        public static Brush ASPARAGUS
        {
            get => (Brush)new BrushConverter().ConvertFrom("#63A46C");
        }

        public static Brush RESEDA_GREEN
        {
            get => (Brush)new BrushConverter().ConvertFrom("#6A7152");
        }

        public static Brush DARK_GREEN
        {
            get => (Brush)new BrushConverter().ConvertFrom("#002400");
        }
    }
}
