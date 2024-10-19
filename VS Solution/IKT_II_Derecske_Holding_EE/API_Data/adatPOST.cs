using IKT_II_Derecske_Holding_EE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IKT_II_Derecske_Holding_EE.API_Data
{
    public class adatPOST
    {
        HttpClient client = new();
        public adatPOST()
        {
            client.BaseAddress = new Uri("https://localhost:7181/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }
        
        public async Task<bool> JegyBevitel(Jegy jegy)
        {
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/Jegyek", jegy);
            return res.IsSuccessStatusCode;   
        }

        public async Task<bool> TanuloBevitel(Tanulo_Obj tanulo)
        {
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/Tanulo", tanulo);
            return res.IsSuccessStatusCode;
        }
    }
}
