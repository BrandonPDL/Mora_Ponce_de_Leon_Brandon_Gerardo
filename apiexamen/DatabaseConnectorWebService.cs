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
