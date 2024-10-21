using System.IO;
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
            BeirIdo.DisplayDate = DateTime.Now;

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


            //string sorszam = "";
            //int sor = 0;
            //DateOnly comparisonDate = new DateOnly(DateTime.Now.Year, 9, 1);
            //List<string> nevek = new List<string>();

            //for (int i = 0; i < Tanulok.Count; i++)
            //{

            //    if (Tanulok[i].Osztaly == osztaly) {
            //        if (Tanulok[i].BeiratIdo < comparisonDate) {

            //            nevek.Add(Tanulok[i].Nev);
            //        }

            //    }

            //}
            //if (beirIdo < comparisonDate) {

            //    nevek.Add(nev);
            //    var sortedNevek = nevek.OrderBy(x => x).ToList();
            //    for (int i = 0; i < sortedNevek.Count; i++)
            //    {
            //        if (sortedNevek[i] == nev) {
            //            sor = i;
            //            break;
            //        }
            //    }
            //}
            if (kolliHely =="") {
                kolliHely = "Nincs";
            }


            Tanulok.Add(new Tanulo("Null", nev, szulHely, szulIdo, anyja, lakcim, beirIdo, szak, osztaly, kollis, kolliHely));



            try
            {
                using (StreamWriter sw = new StreamWriter("Tanulok.csv", true))
                {
                    sw.WriteLine($"Null;{nev};{szulHely};{szulIdo};{anyja};{lakcim};{beirIdo};{szak};{osztaly};{kollis};{kolliHely}");
                }
                MessageBox.Show("Sikeres adat bevitel");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Nev.Text = "";
            SzulHely.Text = "";
            SzulIdo.SelectedDate = null;
            Anyja.Text = "";
            Lakcim.Text = "";
            BeirIdo.SelectedDate = null;
            Szak.Text = "";
            Osztaly.Text = "";
            Kollis.IsChecked = false;
            KolliHely.Text = "";
            KolliGrid.Opacity = 0;

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

        public void Adatbazis(object sender, RoutedEventArgs e) {

            Window adat = new AdatTabla();
            adat.Show();
            this.Close();
        }
    }
}