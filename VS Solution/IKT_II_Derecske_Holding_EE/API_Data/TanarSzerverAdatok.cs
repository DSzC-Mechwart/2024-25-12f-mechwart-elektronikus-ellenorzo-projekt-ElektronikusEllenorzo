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
using static IKT_II_Derecske_Holding_EE.API_Data.SzerverAdatok;

namespace IKT_II_Derecske_Holding_EE.API_Data
{
    public class TanarSzerverAdatok
    {
        public event AdatokLekerdezveD TanulokLekerdezve;
        public event AdatokLekerdezveD OsztalyJegyekLekerdezve;

        /// <summary>
        /// A tanulók teljes listája.
        /// </summary>
        public ObservableCollection<Tanulo_Obj> Tanulok;
        /// <summary>
        /// Az összes osztály listája.
        /// </summary>
        public ObservableCollection<Osztaly> Osztalyok;
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
        public ObservableCollection<Jegy> OsztalyJegyek;

        HttpClient client = new();

        public TanarSzerverAdatok()
        {
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            Tantargyak = new();
            Tanarok = new();
            Szakok = new();
            Tanorak = new();
            Orarendek = new();
            Tanulok = new();
            Osztalyok = new();

            Osztaly o1 = new() { ID = "12.F", Evfolyam = 12, Ofo_ID = 1, Szak_ID = 1 };
            Osztaly o2 = new() { ID = "12.E", Evfolyam = 12, Ofo_ID = 2, Szak_ID = 1 };
            Osztaly o3 = new() { ID = "12.D", Evfolyam = 12, Ofo_ID = 3, Szak_ID = 2 };

            Osztalyok.Add(o1);
            Osztalyok.Add(o2);
            Osztalyok.Add(o3);

            OsztalyJegyek = new();
            GetTanulok("12.F");
            GetOsztalyJegyek("12.F");
        }

        private async void GetOsszesTanulok()
        {
            try
            {
                var response = await client.GetStringAsync("api/Tanulo");
                var tanulok = JsonConvert.DeserializeObject<ObservableCollection<Tanulo_Obj>>(response);
                Tanulok = tanulok;
                TanulokLekerdezve.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

        private async void GetTanulok(string id)
        {
            try
            {
                var response = await client.GetStringAsync($"api/Tanulo/{id}");
                var tanulok = JsonConvert.DeserializeObject<ObservableCollection<Tanulo_Obj>>(response);
                Tanulok = tanulok;
                TanulokLekerdezve?.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

        private async void GetOsztalyJegyek(string id)
        {
            try
            {
                OsztalyJegyek.Clear();
                var response = await client.GetStringAsync($"api/Jegyek/osztalyok/{id}");
                var jegyek = JsonConvert.DeserializeObject<ObservableCollection<Jegy>>(response);
                OsztalyJegyek = jegyek;
                OsztalyJegyekLekerdezve.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

        private async void GetOsztalyok()
        {
            try
            {
                var response = await client.GetStringAsync("api/Osztaly");
                var osztalyok = JsonConvert.DeserializeObject<ObservableCollection<Osztaly>>(response);
                Osztalyok = osztalyok;
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

    }
}
