using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using IKT_II_Derecske_Holding_EE.Models;

namespace IKT_II_Derecske_Holding_EE.Ablakok.Login
{
    /// <summary>
    /// Interaction logic for LoginPanel.xaml
    /// </summary>
    public partial class LoginPanel : UserControl
    {
        HttpClient client = new();
        public LoginPanel()
        {
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            InitializeComponent();
            GetTanulok();
        }

        private async void GetTanulok()
        {
            try
            {
                var response = await client.GetStringAsync("api/Tanulo");
                var tanulok = JsonConvert.DeserializeObject<List<Tanulo_Obj>>(response);
                MessageBox.Show($"{tanulok.Count()}");
                TestGrid.ItemsSource = tanulok;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }
    }
}
