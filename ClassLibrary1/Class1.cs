using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Permissions;
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
    }
}
