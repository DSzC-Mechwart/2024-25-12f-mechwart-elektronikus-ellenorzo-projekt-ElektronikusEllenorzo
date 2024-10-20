using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Chalk
{
    public partial class AdatTabla : Window
    {
        private MainVM Tanulok;

        Dictionary<string, int> szakok = new Dictionary<string, int>();

        public AdatTabla()
        {
            InitializeComponent();
            Tanulok = new MainVM();
            DataContext = Tanulok;
            Statics();
        }

        public void DeleteTanulok(object sender, RoutedEventArgs e) {
            try
            {
                if (DataTabla.SelectedItem is Tanulo SelectedItem)
                {

                    MessageBoxResult result = MessageBox.Show(
                        "Biztos szeretnéd folytatni?",
                        "Confirmation",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                        Tanulok.Tanulok.Remove(SelectedItem);
              

                }
                else
                {
                    MessageBox.Show("Kérlek válasz egy tanulót!");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }


        public void SaveTanulok(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("Tanulok.csv"))
                {
                    foreach (var item in Tanulok.Tanulok)
                    {
                        writer.WriteLine($"{item.Nev};{item.SzulHely};{item.SzulIdo};{item.Anyja};{item.Lakcim};{item.BeiratIdo};{item.Szak};{item.Osztaly};{item.Kolis};{item.KoliHely}"); // Format as needed
                    }
                }
                Statics();
                MessageBox.Show("Sikeres adatmentés!");

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        public void Vissza(object sender, RoutedEventArgs e) { 
        
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        
        }

        public void Statics()
        {
            int kollis = 0;
            int debreceni = 0;
            int bejaros = 0;


            foreach (var item in Tanulok.Tanulok)
            {
                if(item.Kolis) 
                    kollis++;
                if (item.Lakcim.ToLower().Contains("debrecen"))
                    debreceni++;
                else bejaros++;

                if(!szakok.ContainsKey(item.Szak)) szakok[item.Szak] = 0;
                szakok[item.Szak]++;

            }

            Statisztikak.Text = $"Kollisok: {kollis}\nDebreceniek: {debreceni}\nBejárosak: {bejaros}";
          
        }

        public void Szakok(object sender, RoutedEventArgs e) {

            string szak = "";
            foreach (var item in szakok)
            {
                szak += $"{item.Key}: {item.Value}\n";
            }
            MessageBox.Show(szak);

        }
    }
}
