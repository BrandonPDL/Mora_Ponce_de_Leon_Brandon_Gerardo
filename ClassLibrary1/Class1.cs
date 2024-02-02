using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ClassLibrary1
{
    public class Examen
    {
        public int IdExamen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class ApiHelper
    {
        public static async Task<string> GetFromApiAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"Error: {response.StatusCode}");
                }
            }
        }

        public static async Task<string> PostToApiAsync(string url, Examen examen)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(examen);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"Error: {response.StatusCode}");
                }
            }
        }
    }
}
