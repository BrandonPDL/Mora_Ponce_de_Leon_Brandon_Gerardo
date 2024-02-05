using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace apiexamen
{
    public class DatabaseConnectorWebService
    {
        private readonly HttpClient _httpClient;
        public static string _baseUri = "https://localhost:7170/api/Examen";

        public DatabaseConnectorWebService()
        {
            _httpClient = new HttpClient();
        }


        public static async Task<ApiResponse<ExamenConsultId>> GetFromApiAsync(string baseUrl, int id)
        {
            try
            {
                string url = $"{baseUrl}/{id}";
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ExamenConsultId>(responseString);
                    return ApiResponse<ExamenConsultId>.Ok(result);
                }
            }
            catch (HttpRequestException e)
            {
                return ApiResponse<ExamenConsultId>.Fail($"Error al realizar la solicitud: {e.Message}");
            }
            catch (Exception e)
            {
                return ApiResponse<ExamenConsultId>.Fail($"Error inesperado: {e.Message}");
            }
        }

        public static async Task<List<Examen>> GetFromApiAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_baseUri);
                if (response.IsSuccessStatusCode)
                {
                    string responseString= await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Examen>>(responseString);
                    return result;
                }
                else
                {
                    throw new HttpRequestException($"Error: {response.StatusCode}");
                }
            }
        }

        public static async Task<ExamenCreate> PostToApiAsync(string url, Examen examen)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url); // Use the passed URL
            var jsonContent = JsonConvert.SerializeObject(examen); // Serialize the examen object to JSON
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            request.Content = content;

            var response = await client.SendAsync(request);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content and deserialize it into an ExamenCreate object
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ExamenCreate>(responseString);
            return result;
        }
        public static async Task<ExamenCreate> PutToApiAsync( Examen examen)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7170/api/Examen/{examen.IdExamen}");
            var jsonContent = JsonConvert.SerializeObject(examen); // Serialize the examen object to JSON
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            request.Content = content;

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(responseString);

            return new ExamenCreate
            {
                Respuesta = result,
                Descripcion = "",
            }; 
        }
        public static async Task<ExamenCreate> DeleteFromApiAsync(Examen examen)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7170/api/Examen/{examen.IdExamen}");

            var response = await client.SendAsync(request);

            // Asegúrate de que la solicitud fue exitosa
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(responseString);

            return new ExamenCreate
            {
                Respuesta = result,
                Descripcion = "",
            };
        }

    }
}
