using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace apiexamen
{
    public class DatabaseConnectorWebService : iDatabaseConnector
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri;

        public DatabaseConnectorWebService(string baseUri)
        {
            _httpClient = new HttpClient();
            _baseUri = baseUri;
        }

        public async Task AgregarExamenAsync(object examen)
        {
            string uri = $"{_baseUri}/api/Examen";
            string requestBody = JsonConvert.SerializeObject(examen);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task ActualizarExamenAsync(int id, object examen)
        {
            string uri = $"{_baseUri}/api/Examen/{id}";
            string requestBody = JsonConvert.SerializeObject(examen);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }

        public void EjecutarProcedimientoAlmacenado(string nombreProcedimiento, params object[] parametros)
        {
            // Dependiendo del nombre del procedimiento, llamar a la función adecuada.
            switch (nombreProcedimiento)
            {
                case "AgregarExamen":
                    AgregarExamenAsync(parametros[0]).Wait();
                    break;
                case "ActualizarExamen":
                    ActualizarExamenAsync((int)parametros[0], parametros[1]).Wait();
                    break;
                // Añadir casos para 'LeerExamen' y 'EliminarExamen' según sea necesario.
                default:
                    throw new ArgumentException("Procedimiento almacenado no reconocido");
            }
        }
    }
}
