using IKT_II_Derecske_Holding_EE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// A tanulók teljes listája.
        /// </summary>
        public List<Tanulo_Obj> Tanulok;
        /// <summary>
        /// Az összes osztály listája.
        /// </summary>
        public List<Osztaly> Osztalyok;
        /// <summary>
        /// Az összes jegy listája.
        /// </summary>
        public List<Jegy> Jegyek;
        /// <summary>
        /// A tantárgyak listája.
        /// </summary>
        public List<Tantargy> Tantargyak;
        /// <summary>
        /// A tanárok listája.
        /// </summary>
        public List<Tanar> Tanarok;
        /// <summary>
        /// A szakok listája.
        /// </summary>
        public List<Szak> Szakok;
        /// <summary>
        /// A tanórák listája.
        /// </summary>
        public List<Tanora> Tanorak;
        /// <summary>
        /// Az osztályonkénti órarendek.
        /// </summary>
        public List<Orarend> Orarendek;
        HttpClient client = new();

        public SzerverAdatok()
        {
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            Tanulok = new();
            Osztalyok = new();
            Jegyek = new();
            Tantargyak = new();
            Tanarok = new();
            Szakok = new();
            Tanorak = new();
            Orarendek = new();

            Tanulo_Obj t1 = new() { ID = 1, Nev = "Szabó Balázs", Szul_Ido = new(2006, 12, 14), Szul_Hely = "Nagy-Derecske", Anya_Nev = "Mariann", Koli = null, Osztaly_ID = "12.F", Torzslapszam = "58965" };
            Tanulo_Obj t2 = new() { ID = 2, Nev = "Szabó Balázs2", Szul_Ido = new(2006, 12, 14), Szul_Hely = "Nagy-Derecske", Anya_Nev = "Mariann", Koli = null, Osztaly_ID = "12.F", Torzslapszam = "58936" };
            Tanulo_Obj t3 = new() { ID = 3, Nev = "Szabó Balázs3", Szul_Ido = new(2006, 12, 14), Szul_Hely = "Kis-Derecske", Anya_Nev = "Mariann", Koli = null, Osztaly_ID = "12.E", Torzslapszam = "52636" };

            Tanulok.Add(t1);
            Tanulok.Add(t2);
            Tanulok.Add(t3);

            Osztaly o1 = new() { ID="12.F", Evfolyam = 12, Ofo_ID = 1, Szak_ID = 1 };
            Osztaly o2 = new() { ID="12.E", Evfolyam = 12, Ofo_ID = 2, Szak_ID = 1 };
            Osztaly o3 = new() { ID="12.D", Evfolyam = 12, Ofo_ID = 3, Szak_ID = 2 };

            Osztalyok.Add(o1);
            Osztalyok.Add(o2);
            Osztalyok.Add(o3);

            Tanar tr1 = new() { ID = 1, Nev = "Jancsika" };
            Tanar tr2 = new() { ID = 2, Nev = "Pista" };
            Tanar tr3 = new() { ID = 3, Nev = "Bela" };

            Tanarok.Add(tr1);
            Tanarok.Add(tr2);
            Tanarok.Add(tr3);

            Szak s1 = new() { ID = 1, Szak_Nev = "Szoftverfejlesztő" };
            Szak s2 = new() { ID = 2, Szak_Nev = "Vezérkari tiszt" };

            Szakok.Add(s1);
            Szakok.Add(s2);

        }


        private async void GetTanulok()
        {
            try
            {
                var response = await client.GetStringAsync("api/Tanulo");
                var tanulok = JsonConvert.DeserializeObject<List<Tanulo_Obj>>(response);
                Tanulok = tanulok.ToList();
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
                var szakok = JsonConvert.DeserializeObject<List<Szak>>(response);
                Szakok = szakok.ToList();
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
                var osztalyok = JsonConvert.DeserializeObject<List<Osztaly>>(response);
                Osztalyok = osztalyok.ToList();
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
                var tanarok = JsonConvert.DeserializeObject<List<IKT_II_Derecske_Holding_EE.Models.Tanar>>(response);
                Tanarok = tanarok.ToList();
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
                var jegyek = JsonConvert.DeserializeObject<List<Jegy>>(response);
                Jegyek = jegyek.ToList();
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
                var tantargyak = JsonConvert.DeserializeObject<List<Tantargy>>(response);
                Tantargyak = tantargyak.ToList();
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
                var tanorak = JsonConvert.DeserializeObject<List<Tanora>>(response);
                Tanorak = tanorak.ToList();
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
                var orarendek = JsonConvert.DeserializeObject<List<Orarend>>(response);
                Orarendek = orarendek.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Nem található a szerver");
            }

        }
    }
}
