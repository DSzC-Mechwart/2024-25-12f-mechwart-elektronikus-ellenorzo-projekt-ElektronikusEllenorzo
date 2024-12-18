using IKT_II_Derecske_Holding_EE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IKT_II_Derecske_Holding_EE.API_Data
{
    /// <summary>
    /// A szervertől kapott adatokat tároló objektum, az adatok a listákban vannak.
    /// </summary>
    public class SzerverAdatok
    {
        public delegate void AdatokLekerdezveD();
        public event AdatokLekerdezveD AdatokLekerdezve;
        public event AdatokLekerdezveD JegyekLekerdezve;
        /// <summary>
        /// Az összes jegy listája.
        /// </summary>
        public ObservableCollection<Jegy> Jegyek;
        /// <summary>
        /// A tantárgyak listája.
        /// </summary>
        public ObservableCollection<Tantargy> Tantargyak;
        /// <summary>
        /// A tanárok listája.
        /// </summary>
        public ObservableCollection<Tanar> Tanarok;
        /// <summary>
        /// A szakok listája.
        /// </summary>
        public ObservableCollection<Szak> Szakok;
        /// <summary>
        /// A tanórák listája.
        /// </summary>
        public ObservableCollection<Tanora> Tanorak;
        /// <summary>
        /// Az osztályonkénti órarendek.
        /// </summary>
        public ObservableCollection<Orarend> Orarendek;
        HttpClient client = new();

        public SzerverAdatok()
        {
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            Jegyek = new();
            Tantargyak = new();
            Tanarok = new();
            Szakok = new();
            Tanorak = new();
            Orarendek = new();
            /*
            Tanulo_Obj t1 = new() { ID = 1, Nev = "Szabó Balázs", Szul_Ido = new(2006, 12, 14), Szul_Hely = "Nagy-Derecske", Anya_Nev = "Mariann", Koli = null, Osztaly_ID = "12.F", Torzslapszam = "58965" };
            Tanulo_Obj t2 = new() { ID = 2, Nev = "Szabó Balázs2", Szul_Ido = new(2006, 12, 14), Szul_Hely = "Nagy-Derecske", Anya_Nev = "Mariann", Koli = null, Osztaly_ID = "12.F", Torzslapszam = "58936" };
            Tanulo_Obj t3 = new() { ID = 3, Nev = "Szabó Balázs3", Szul_Ido = new(2006, 12, 14), Szul_Hely = "Kis-Derecske", Anya_Nev = "Mariann", Koli = null, Osztaly_ID = "12.E", Torzslapszam = "52636" };

            Tanulok.Add(t1);
            Tanulok.Add(t2);
            Tanulok.Add(t3);

            Tanar tr1 = new() { ID = 1, Nev = "Jancsika" };
            Tanar tr2 = new() { ID = 2, Nev = "Pista" };
            Tanar tr3 = new() { ID = 3, Nev = "Bela" };

            Tanarok.Add(tr1);
            Tanarok.Add(tr2);
            Tanarok.Add(tr3);*/

            Szak s1 = new() { ID = 1, Szak_Nev = "Szoftverfejlesztő" };
            Szak s2 = new() { ID = 2, Szak_Nev = "Vezérkari tiszt" };

            Szakok.Add(s1);
            Szakok.Add(s2);

            Jegy jegy = new() { Datum= new(), ID = 1, Jegy_Ertek = 4, Tanar_ID = 1, Tantargy_ID = 1, Tanulo_ID = 2, Tema = "2.világháború", Osztaly_ID = "12.F" };
            Jegy jegy2 = new() { Datum= new(), ID = 2, Jegy_Ertek = 5, Tanar_ID = 1, Tantargy_ID = 1, Tanulo_ID = 2, Tema = "2.világháború", Osztaly_ID = "12.F" };
            Jegy jegy3 = new() { Datum= new(), ID = 3, Jegy_Ertek = 2, Tanar_ID = 1, Tantargy_ID = 1, Tanulo_ID = 3, Tema = "2.világháború", Osztaly_ID = "12.F" };
            Jegy jegy4 = new() { Datum= new(), ID = 1, Jegy_Ertek = 3, Tanar_ID = 1, Tantargy_ID = 1, Tanulo_ID = 4, Tema = "2.világháború", Osztaly_ID = "12.F" };
            Jegyek.Add(jegy);
            Jegyek.Add(jegy2);
            Jegyek.Add(jegy3);
            Jegyek.Add(jegy4);
            //GetTanuloJegyek(2);
        }

        private async void GetSzakok()
        {
            try
            {
                var response = await client.GetStringAsync("api/Szakok");
                var szakok = JsonConvert.DeserializeObject<ObservableCollection<Szak>>(response);
                Szakok = szakok;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

        private async void GetTanarok()
        {
            try
            {
                var response = await client.GetStringAsync("api/Tanarok");
                var tanarok = JsonConvert.DeserializeObject<ObservableCollection<IKT_II_Derecske_Holding_EE.Models.Tanar>>(response);
                Tanarok = tanarok;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

        private async void GetJegyek()
        {
            try
            {
                var response = await client.GetStringAsync("api/Jegyek");
                var jegyek = JsonConvert.DeserializeObject<ObservableCollection<Jegy>>(response);
                Jegyek = jegyek;
                JegyekLekerdezve?.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

        private async void GetTanuloJegyek(int id)
        {
            try
            {
                var response = await client.GetStringAsync($"api/Jegyek/{id}");
                var jegyek = JsonConvert.DeserializeObject<ObservableCollection<Jegy>>(response);
                Jegyek = jegyek;
                JegyekLekerdezve?.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

        private async void GetTantargyak()
        {
            try
            {
                var response = await client.GetStringAsync("api/Tantargyak");
                var tantargyak = JsonConvert.DeserializeObject<ObservableCollection<Tantargy>>(response);
                Tantargyak = tantargyak;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

        private async void GetTanorak()
        {
            try
            {
                var response = await client.GetStringAsync("api/Tanorak");
                var tanorak = JsonConvert.DeserializeObject<ObservableCollection<Tanora>>(response);
                Tanorak = tanorak;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

        private async void GetOrarend()
        {
            try
            {
                var response = await client.GetStringAsync("api/Orarendek/osszes");
                var orarendek = JsonConvert.DeserializeObject<ObservableCollection<Orarend>>(response);
                Orarendek = orarendek;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }
    }
}
