using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for HBWindow.xaml
    /// </summary>
    public partial class HBWindow : Window
    {
        public HBWindow(string HFNev)
        {
            InitializeComponent();
            HNameDisplay.Content = HFNev;
            TestAsync();
        }

        List<int> Matek = new List<int>();
        List<int> Irodalom = new List<int>();
        List<int> Nyelvtan = new List<int>();
        List<int> Töri = new List<int>();
        List<int> Tesi = new List<int>();
        List<int> Fizika = new List<int>();
        List<int> Szakma = new List<int>();
        List<int> IdegenNyelv = new List<int>();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int HSJegy = 0;
            if (H1.IsChecked == true)
                HSJegy = 1;
            else if (H2.IsChecked == true)
                HSJegy = 2;
            else if (H3.IsChecked == true)
                HSJegy = 3;
            else if (H4.IsChecked == true)
                HSJegy = 4;
            else if (H5.IsChecked == true)
                HSJegy = 5;

            HListBox.Items.Add(new Label
            {
                Width = 240,
                Height = 50,
                Content = HSelectedTantargy.Text + " " + HSJegy + " " + HSelectedTipus.Text + " " + HHozzafuzes.Text,
                HorizontalAlignment = HorizontalAlignment.Center
            });
            HAppendJegy(HSelectedTantargy.Text, HSJegy);
        }

        private void HAppendJegy(string HTargy, int HJegy)
        {
            switch (HTargy)
            {
                case "Matematika":
                    Matek.Append(HJegy); break;
                case "Történelem":
                    Töri.Append(HJegy); break;
                case "Irodalom":
                    Irodalom.Append(HJegy); break;
                case "Nyelvtan":
                    Nyelvtan.Append(HJegy); break;
                case "Idegen nyelv":
                    IdegenNyelv.Append(HJegy); break;
                case "Szakma":
                    Szakma.Append(HJegy); break;
                case "Tesi":
                    Tesi.Append(HJegy); break;
                case "Fizika":
                    Fizika.Append(HJegy); break;
            }
        }
        private async Task TestAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://023e-2001-4c4e-245b-4a00-3150-264-ad23-a94d.ngrok-free.app/GetTanulos");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            File.WriteAllText("asdasd.json", await response.Content.ReadAsStringAsync());
        }
    }
}
