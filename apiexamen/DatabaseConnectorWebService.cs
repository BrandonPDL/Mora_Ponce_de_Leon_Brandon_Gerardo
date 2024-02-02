using System;
using System.Net.Http;
using System.Text;
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

        public async void EjecutarProcedimientoAlmacenado(string nombreProcedimiento, params object[] parametros)
        {
            var uri = $"{_baseUri}/{nombreProcedimiento}";
            var json = JsonConvert.SerializeObject(parametros);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
