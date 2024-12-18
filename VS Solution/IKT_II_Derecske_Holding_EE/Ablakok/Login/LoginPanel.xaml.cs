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
        MainWindow _mainWindow;
        public LoginPanel(MainWindow mainWindow)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            _mainWindow = mainWindow;
        }

        private async void Belepes(object sender, RoutedEventArgs e)
        {
            if (Felhasznalonev.Text != "admin" && jelszoBox.Password != "admin")
            {

                string res = await client.GetStringAsync($"api/Belepes/tipus?id={Convert.ToInt32(Felhasznalonev.Text)}");
                int tipus = Convert.ToInt32(res);
                bool match = false;
                switch (tipus)
                {
                    case -1:
                        MessageBox.Show("Nem létezik ilyen azonosítójú felhasználó!");
                        break;
                    case 1:
                        string tanulo_salt = await client.GetStringAsync($"api/Belepes/salt?id={Convert.ToInt32(Felhasznalonev.Text)}&type=1");
                        match = await JelszoEllenorzes(tanulo_salt, jelszoBox.Password,1);
                        if (match)
                        {
                            string tanuloJSON = await client.GetStringAsync($"api/Tanulo/tanulo/{Convert.ToInt32(Felhasznalonev.Text)}");
                            Tanulo_Obj tanulo = JsonConvert.DeserializeObject<Tanulo_Obj>(tanuloJSON);
                            _mainWindow.ChangeTo(1, null);
                        }
                        break;
                    case 2:
                        string tanar_salt = await client.GetStringAsync($"api/Belepes/salt?id={Convert.ToInt32(Felhasznalonev.Text)}&type=2");
                        match = await JelszoEllenorzes(tanar_salt, jelszoBox.Password,2);
                        if (match)
                        {
                            string tanarJSON = await client.GetStringAsync($"api/Tanarok/{Convert.ToInt32(Felhasznalonev.Text)}");
                            IKT_II_Derecske_Holding_EE.Models.Tanar tanar = JsonConvert.DeserializeObject<IKT_II_Derecske_Holding_EE.Models.Tanar>(tanarJSON);
                            _mainWindow.ChangeTo(2, tanar);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _mainWindow.ChangeTo(3, null);
            }

        }

        private async Task<bool> JelszoEllenorzes(string salt_, string pass, int type)
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
            byte[] passBytes = Encoding.UTF8.GetBytes(combinedPass);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new(passBytes, _saltArray, 25000, HashAlgorithmName.SHA256);
            byte[] hashByte = rfc2898DeriveBytes.GetBytes(32);
            string _hash = BitConverter.ToString(hashByte);
            string passHashJSON = await client.GetStringAsync($"api/Belepes/ellenorzes?id={Convert.ToInt32(Felhasznalonev.Text)}&type={type}");
            string passHash = JsonConvert.DeserializeObject<string>(passHashJSON);
            return _hash.Equals(passHash);
        }
    }
}
