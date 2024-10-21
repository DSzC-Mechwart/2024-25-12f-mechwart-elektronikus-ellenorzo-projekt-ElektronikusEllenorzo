using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CsvHelper;
using System.Globalization;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for KWindow.xaml
    /// </summary>
    public partial class KWindow : Window
    {
        public static List<Tantargyak> tantargyak = new List<Tantargyak>();
        public KWindow()
        {
            InitializeComponent();
            ReadIn();
            FillUpDataGrid();
        }

        public void ReadIn()
        {
            using (StreamReader r = new StreamReader("tantargyakK.json"))
            {
                if (r != null)
                {
                    string json = r.ReadToEnd();
                    tantargyak = JsonSerializer.Deserialize<List<Tantargyak>>(json);
                }
            }
        }
        public void WriteJson()
        {
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowCharacters('\u00F6', '\u00E1', '\u00E9'); // ö, á, é, betűk
            encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(tantargyak, options);
            File.WriteAllText("tantargyakK.json", json, Encoding.UTF8);
        }

        public void WriteCsv()
        {
            using (var writer = new StreamWriter("tantargyakK.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<Tantargyak>();
                foreach (var x in tantargyak)
                {
                    csv.NextRecord();
                    csv.WriteField(x.tantargy);
                    csv.WriteField(x.evfolyam);
                    csv.WriteField(x.kozSzak);
                    csv.WriteField(x.hetiora);
                    csv.WriteField(x.evesora);
                }
                
            }
        }

        public void FillUpDataGrid()
        {
            Kdatatable.ItemsSource = null;
            Kdatatable.ItemsSource = tantargyak;
        }

        private void KozismTan_Checked(object sender, RoutedEventArgs e)
        {
            SzakmaiTan.IsEnabled = false;
            Hetioraszam.IsEnabled = true;
        }
        private void KozismTan_Unchecked(object sender, RoutedEventArgs e)
        {
            SzakmaiTan.IsEnabled = true;
            Hetioraszam.IsEnabled = false;
        }

        private void SzakmaiTan_Checked(object sender, RoutedEventArgs e)
        {
            KozismTan.IsEnabled = false;
            Hetioraszam.IsEnabled = true;
        }
        private void SzakmaiTan_Unchecked(object sender, RoutedEventArgs e)
        {
            KozismTan.IsEnabled = true;
            Hetioraszam.IsEnabled = false;
        }

        private void Tantargy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tantargy.Text != null) { Evfolyam.IsEnabled = true; }
        }

        private void Evfolyam_TextChanged(object sender, TextChangedEventArgs e)
        {
            KozismTan.IsEnabled = false;
            SzakmaiTan.IsEnabled = false;

            if (Evfolyam.Text != null) 
            { 
                if (Evfolyam.Text.Contains("9") || Evfolyam.Text.Contains("10") || Evfolyam.Text.Contains("11") || Evfolyam.Text.Contains("12") || Evfolyam.Text.Contains("13"))
                {
                    KozismTan.IsEnabled = true;
                    SzakmaiTan.IsEnabled = true;
                }
            }
        }

        private void Hetioraszam_TextChanged(object sender, TextChangedEventArgs e)
        {
            Feltolt.IsEnabled = false;
            if (Hetioraszam.Text != null && CheckStrOrInt(Hetioraszam.Text) == "int") { Feltolt.IsEnabled = true; }
        }
        private void Feltolt_Click(object sender, RoutedEventArgs e)
        {
            string ujTantargy = Tantargy.Text;
            string evfolyam = Evfolyam.Text;
            string kozSzakTan = "";
            if (KozismTan.IsChecked == true) { kozSzakTan = "közismereti"; }
            if (SzakmaiTan.IsChecked == true) { kozSzakTan = "szakmai"; }
            int hetiOra = Convert.ToInt32(Hetioraszam.Text);
            int evesOra = GenerateYearlyLessons(evfolyam, kozSzakTan, hetiOra);

            tantargyak.Add(new Tantargyak(ujTantargy, evfolyam, kozSzakTan, hetiOra, evesOra));
            WriteJson();
            WriteCsv();
            FillUpDataGrid();
            ClearUI();
        }
        private void Kdatatable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tantargyTorles.IsEnabled = true;
        }
        private void tantargyTorles_Click(object sender, RoutedEventArgs e)
        {
            var remove = Kdatatable.SelectedItem as Tantargyak;
            if (remove != null)
            {
                tantargyak.Remove(remove);
            }
            WriteJson();
            WriteCsv();
            ReadIn();
            FillUpDataGrid();
            tantargyTorles.IsEnabled = false;
        }

        private string CheckStrOrInt(string str)
        {
            try
            {
                Convert.ToInt32(str);
            } catch (Exception e)
            {
                return "str";
            }
            return "int";
        }

        private int GenerateYearlyLessons(string evfolyam, string kozSzak, int hetiOra)
        {
            if (evfolyam.Contains("9") || evfolyam.Contains("10") || evfolyam.Contains("11")) {  return hetiOra * 36; }
            if (evfolyam.Contains("12") && kozSzak == "közismereti") { return hetiOra * 31; }
            if (evfolyam.Contains("12") && kozSzak == "szakmai") { return hetiOra * 36; }
            if (evfolyam.Contains("13")) { return hetiOra * 31; }
            else { return 0; }
        }

        private void ClearUI()
        {
            Tantargy.Clear();
            Evfolyam.Clear();
            Evfolyam.IsEnabled = false;
            KozismTan.IsChecked = false;
            KozismTan.IsEnabled = false;
            SzakmaiTan.IsChecked = false;
            SzakmaiTan.IsEnabled = false;
            Hetioraszam.Clear();
            Hetioraszam.IsEnabled = false;
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            var data = tantargyak.GroupBy(x => x.evfolyam)
                .Select(x => new
                {
                    ev = x.Key,
                    szakmaiOra = x.Count(y => y.kozSzak == "szakmai"),
                    kozismeretiOra = x.Count(y => y.kozSzak == "közismereti"),
                    szakmaiOraSzam = x.Sum(y => y.evesora * (y.kozSzak == "szakmai" ? 1 : 0)),
                    kozismeretiOraSzam = x.Sum(y => y.evesora * (y.kozSzak == "közismereti" ? 1 : 0)),
                    osszOra = x.Sum(y => y.evesora)
                })
                .OrderByDescending(x => x.ev);

            kAdminTable.ItemsSource = null;
            kAdminTable.ItemsSource = data;
        }
    }
}
