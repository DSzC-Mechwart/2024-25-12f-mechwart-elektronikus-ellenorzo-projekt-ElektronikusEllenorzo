using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chalk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tanulo> Tanulok = new List<Tanulo>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void Kesz(object sender, RoutedEventArgs e) {

            string nev = Nev.Text;
            string szulHely = SzulHely.Text;
            DateOnly szulIdo = DateOnly.FromDateTime(SzulIdo.SelectedDate!.Value);
            string anyja = Anyja.Text;
            string lakcim = Lakcim.Text;
            DateOnly beirIdo = DateOnly.FromDateTime(BeirIdo.SelectedDate!.Value);
            string szak = Szak.Text;
            string osztaly = Osztaly.Text;
            bool kollis = Kollis.IsChecked == true;
            string kolliHely = KolliHely.Text;

            Tanulok.Add(new Tanulo(nev, szulHely, szulIdo, anyja, lakcim, beirIdo, szak, osztaly, kollis, kolliHely));



        }

        public void Kolli(object sender, RoutedEventArgs e)
        {
            if (Kollis.IsChecked == true) {
            
                KolliGrid.Opacity = 1;
            }
            else
            {
                KolliGrid.Opacity = 0;
            }


        }
    }
}