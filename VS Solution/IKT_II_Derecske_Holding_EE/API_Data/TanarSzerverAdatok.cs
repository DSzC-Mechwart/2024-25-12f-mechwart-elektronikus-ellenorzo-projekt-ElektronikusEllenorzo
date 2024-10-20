using IKT_II_Derecske_Holding_EE.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static IKT_II_Derecske_Holding_EE.API_Data.SzerverAdatok;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Dynamic;
using Newtonsoft.Json.Linq;

namespace IKT_II_Derecske_Holding_EE.API_Data
{
    public class TanarSzerverAdatok
    {
        public event AdatokLekerdezveD TanulokLekerdezve;
        public event AdatokLekerdezveD OsztalyJegyekLekerdezve;
        public event AdatokLekerdezveD TantargyakLekerdezve;
        public event AdatokLekerdezveD OsztalyokLekerdezve;

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
        
        public ObservableCollection<Orarend> Orarendek;
        public ObservableCollection<Jegy> OsztalyJegyek;

        public dynamic TesztJegy { get; set; }

        HttpClient client = new();

        public TanarSzerverAdatok(string osztalyID)
        {
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            Tantargyak = new();
            Orarendek = new();
            Tanulok = new();
            Osztalyok = new();

            /*Osztaly o1 = new() { ID = "12.F", Evfolyam = 12, Ofo_ID = 1, Szak_ID = 1 };
            Osztaly o2 = new() { ID = "12.E", Evfolyam = 12, Ofo_ID = 2, Szak_ID = 1 };
            Osztaly o3 = new() { ID = "12.D", Evfolyam = 12, Ofo_ID = 3, Szak_ID = 2 };

            Osztalyok.Add(o1);
            Osztalyok.Add(o2);
            Osztalyok.Add(o3);

            Tanulo_Obj t1 = new() { ID = 1, Nev = "Szabó Balázs", Szul_Ido = new(2006, 12, 14), Szul_Hely = "Nagy-Derecske", Anya_Nev = "Mariann", Koli = null, Osztaly_ID = "12.F", Torzslapszam = "58965" };
            Tanulo_Obj t2 = new() { ID = 2, Nev = "Szabó Balázs2", Szul_Ido = new(2006, 12, 14), Szul_Hely = "Nagy-Derecske", Anya_Nev = "Mariann", Koli = null, Osztaly_ID = "12.F", Torzslapszam = "58936" };
            Tanulo_Obj t3 = new() { ID = 3, Nev = "Szabó Balázs3", Szul_Ido = new(2006, 12, 14), Szul_Hely = "Kis-Derecske", Anya_Nev = "Mariann", Koli = null, Osztaly_ID = "12.E", Torzslapszam = "52636" };

            Tanulok.Add(t1);
            Tanulok.Add(t2);
            Tanulok.Add(t3);*/

            OsztalyJegyek = new();
            GetTanulok(osztalyID);
            GetOsztalyJegyek2(osztalyID);
            GetTantargyak();
        }

        public TanarSzerverAdatok()
        {
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            Tantargyak = new();
            Orarendek = new();
            Tanulok = new();
            Osztalyok = new();
            OsztalyJegyek = new();

            GetOsztalyok();
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
                MessageBox.Show($"{response}");
                var jegyek = JsonConvert.DeserializeObject<ObservableCollection<Jegy>>(response);
                OsztalyJegyek = jegyek;
                OsztalyJegyekLekerdezve?.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver (Jegyek)");
                throw;
            }

        }

        private async void GetOsztalyJegyek2(string id)
        {
            try
            {
                OsztalyJegyek.Clear();
                var response = await client.GetStringAsync($"api/Jegyek/osztalyok/vmi/{id}");
                dynamic des = JsonConvert.DeserializeObject(response);
                foreach (dynamic tanulo in des)
                {
                    JObject honapLista = new ();
                    for (int i = 1; i < 13; i++)
                    {
                        if (i != 7 || i != 8)
                        {
                            string honap = "";
                            if (tanulo.jegyek[$"{i}"] != null)
                            {
                                foreach (dynamic jegy in tanulo.jegyek[$"{i}"])
                                {
                                    if ((int)jegy.jegy_Ertek > 0)
                                    {
                                        honap += $"{jegy.jegy_Ertek} ";
                                    }
                                    else
                                    {
                                        honap += $"- ";
                                    }
                                }
                            }
                            honapLista[$"{i}"] = honap;
                        }
                    }
                    tanulo.honapok = honapLista;
                }
                TesztJegy = des;
                /*var jegyek = JsonConvert.DeserializeObject<ObservableCollection<Jegy>>(response);
                OsztalyJegyek = jegyek;*/
                OsztalyJegyekLekerdezve?.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver (Jegyek)");
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
                throw ;
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



        private async void GetOrarend()
        {
            try
            {
                var response = await client.GetStringAsync("api/Orarendek/osszes");
                //var orarendek = JsonConvert.DeserializeObject<ObservableCollection<Orarend>>(response);
                //Orarendek = orarendek;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }

    }
}
