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
using IKT_II_Derecske_Holding_EE.API_Data;
using IKT_II_Derecske_Holding_EE.Ablakok.Stilus;
using System.Collections.ObjectModel;
using System.Security;
using System.Security.Cryptography;

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
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

        }

        private async void Belepes(object sender, RoutedEventArgs e)
        {
            string res = await client.GetStringAsync($"api/Belepes/tipus?id={Convert.ToInt32(Felhasznalonev.Text)}");
            int tipus = Convert.ToInt32(res);
            switch (tipus)
            {
                case -1:
                    MessageBox.Show("Nem létezik ilyen azonosítójú felhasználó!");
                    break;
                case 1:
                    string tanulo_salt = await client.GetStringAsync($"api/Belepes/salt?id={Convert.ToInt32(Felhasznalonev.Text)}&type=1");
                    bool match = await JelszoEllenorzes(tanulo_salt, jelszoBox.Password);
                    MessageBox.Show($"{match}");
                    break;
                case 2:
                    MessageBox.Show("Tanár");
                    break;
                default:
                    break;
            }
        }

        private async Task<bool> JelszoEllenorzes(string salt_, string pass)
        {
            string salt = JsonConvert.DeserializeObject<string>(salt_);
            string[] strArray = salt.Split('-');
            byte[] _saltArray = new byte[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                _saltArray[i] = Convert.ToByte(strArray[i], 16);
            }
            string _salt = BitConverter.ToString(_saltArray);
            string combinedPass = pass + _salt;
            MessageBox.Show(combinedPass);
            byte[] passBytes = Encoding.UTF8.GetBytes(combinedPass);
            string test = "";
            foreach (var item in passBytes)
            {
                test += $"{item}";
            }
            MessageBox.Show(test);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new(passBytes, _saltArray, 25000, HashAlgorithmName.SHA256);
            byte[] hashByte = rfc2898DeriveBytes.GetBytes(32);
            string _hash = BitConverter.ToString(hashByte);
            MessageBox.Show(_salt);
            MessageBox.Show(_hash);
            string reply = await client.GetStringAsync($"api/Belepes/ellenorzes?id={Convert.ToInt32(Felhasznalonev.Text)}&passHash={_hash}&type=1");
            return bool.Parse(reply);
        }
    }
}
