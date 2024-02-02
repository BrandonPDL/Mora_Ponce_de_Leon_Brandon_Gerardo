using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace apiexamen
{
    public class DatabaseConnectorWebService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri;

        public DatabaseConnectorWebService(string baseUri)
        {
            _httpClient = new HttpClient();
            _baseUri = baseUri;
        }


        public static async Task<string> GetFromApiAsync(string baseUrl, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7170/api/Examen/{id}";
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
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7170/api/Examen");
            var jsonContent = $"{{\r\n  \"idExamen\": {examen.IdExamen},\r\n  \"nombre\": \"{examen.Nombre}\",\r\n  \"descripcion\": \"{examen.Descripcion}\"\r\n}}";
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            request.Content = content;

            var response = await client.SendAsync(request);

            // Asegúrate de que la solicitud fue exitosa
            response.EnsureSuccessStatusCode();

            // Leer y retornar el contenido de la respuesta como un string
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
        public static async Task<string> PutToApiAsync(string url, Examen examen)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7170/api/Examen/{examen.IdExamen}");
            var jsonContent = $"{{\r\n  \"idExamen\": {examen.IdExamen},\r\n  \"nombre\": \"{examen.Nombre}\",\r\n  \"descripcion\": \"{examen.Descripcion}\"\r\n}}";
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            request.Content = content;

            var response = await client.SendAsync(request);

            // Asegúrate de que la solicitud fue exitosa
            response.EnsureSuccessStatusCode();

            // Leer y retornar el contenido de la respuesta como un string
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
        public static async Task<string> DeleteFromApiAsync(string url, int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7170/api/Examen/{id}");

            var response = await client.SendAsync(request);

            // Asegúrate de que la solicitud fue exitosa
            response.EnsureSuccessStatusCode();

            // Leer y retornar el contenido de la respuesta como un string
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

    }
}
