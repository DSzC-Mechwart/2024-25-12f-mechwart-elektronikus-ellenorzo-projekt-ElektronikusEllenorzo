using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for dBevitel.xaml
    /// </summary>
    public partial class dBevitel : Window
    {
        List<c_Read_Bevit> adatok;

        public void Beolvas(string filepath)
        {
            adatok = new List<c_Read_Bevit>();

            foreach (var i in File.ReadAllLines(filepath))
            {
                var resz = i.Split(";");
                string nev = resz[0];
                string szulhely = resz[1];
                DateTime szulido = Convert.ToDateTime(resz[2]);
                string anyanev = resz[3];
                string lakcim = resz[4];
                int naploszam = Convert.ToInt32(resz[5]);
                DateTime beiratkozas = Convert.ToDateTime(resz[6]);
                string szak = resz[7];
                string osztaly = resz[8];
                string kollegista = resz[9];
                string kollegium = resz[10];
                int torszszam = Convert.ToInt32(resz[11]);

                c_Read_Bevit x = new(nev, szulhely, szulido, anyanev, lakcim, naploszam, beiratkozas, szak, osztaly, kollegista, kollegium, torszszam);
                adatok.Add(x);
            }
        }
        public dBevitel()
        {
            Beolvas("test.txt");
            InitializeComponent();
            Ckollegium.IsEnabled = false;
        }

        private void cBevitVissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void kollegista_Checked(object sender, RoutedEventArgs e)
        {
            Ckollegium.IsEnabled = true;
        }

        private void kollegista_Unchecked(object sender, RoutedEventArgs e)
        {
            Ckollegium.IsEnabled = false;
            Ckollegium.Text = string.Empty;
        }







        private void cBevitMentes_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("igen");
            File.WriteAllText("test.txt", String.Empty);

            string Dnev = Ctnev.Text;
            string Dszulhely = Cszulhely.Text;
            DateTime Dszulido = Convert.ToDateTime(Cszulido.Text);
            string Danyanev = Canya.Text;
            string Dlakcim = Clakcim.Text;
            int Dnaploszam = Convert.ToInt32(Cnaploszam.Text);
            DateTime Dbeiratkozas = Convert.ToDateTime(Cbeirido.Text);
            string Dszak = Cszak.Text;
            string Dosztaly = Cosztaly.Text;
            string Dkollegista = Ckollegista.IsChecked == true ? "Igen" : "Nem";
            string Dkollegium = Ckollegium.Text;
            int Dtorszszam = Convert.ToInt32(Ctorzsszam.Text);


          
            string line = "";
            line = $"{Dnev}; {Dszulhely}; {Dszulhely}; {Danyanev}; {Dlakcim}; {Dnaploszam};" +
                       $"{Dbeiratkozas}; {Dszak}; {Dosztaly}; {Dkollegista}; {Dkollegium}; {Dtorszszam}\n";    
            MessageBox.Show(line);
            string[] lines = line.Split(";");
            foreach(var i in  lines)
            {
                var resz = i.Split(";");
                string nev = resz[0];
                string szulhely = resz[1];
                DateTime szulido = Convert.ToDateTime(resz[2]);
                string anyanev = resz[3];
                string lakcim = resz[4];
                int naploszam = Convert.ToInt32(resz[5]);
                DateTime beiratkozas = Convert.ToDateTime(resz[6]);
                string szak = resz[7];
                string osztaly = resz[8];
                string kollegista = resz[9];
                string kollegium = resz[10];
                int torszszam = Convert.ToInt32(resz[11]);

                c_Read_Bevit x = new(nev, szulhely, szulido, anyanev, lakcim, naploszam, beiratkozas, szak, osztaly, kollegista, kollegium, torszszam);
                adatok.Add(x);
            }
            File.WriteAllText("test.txt", line);
            this.Close();
        }
    }
}
