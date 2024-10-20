using IKT_II_Derecske_Holding_EE.Models;
using LoginInterface;
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
    public class AdminAdatok
    {
        public event AdatokLekerdezveD TantargyakLekerdezve;
        public event AdatokLekerdezveD OsztalyokLekerdezve;

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
        /// A tantárgyak listája.
        /// </summary>
        public ObservableCollection<Tantargy> Tantargyak;
        /// <summary>
        /// Az összes osztály listája.
        /// </summary>
        public ObservableCollection<Osztaly> Osztalyok;

        HttpClient client = new();

        public AdminAdatok()
        {
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            Tantargyak = new();
            Osztalyok = new();
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

        private async void GetTantargyak()
        {
            try
            {
                var response = await client.GetStringAsync("api/Tantargyak");
                var tantargyak = JsonConvert.DeserializeObject<ObservableCollection<Tantargy>>(response);
                Tantargyak = tantargyak;
                TantargyakLekerdezve?.Invoke();
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
                OsztalyokLekerdezve?.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
                throw;
            }

        }

    }
}
