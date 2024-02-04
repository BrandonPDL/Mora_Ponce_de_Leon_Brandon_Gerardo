
using System;
using System.Threading.Tasks;
using System.Security.Permissions;
using Newtonsoft.Json;
namespace apiexamen
{
    public class clsExamen
    {
        private iDatabaseConnector _databaseConnector;
        private bool usarWebApi;

        public clsExamen(bool useWebService)
        {
            if (useWebService)
            {
                string connectionStringOrBaseUrl = "";
                usarWebApi = true;
              //  _databaseConnector = new DatabaseConnectorWebService(connectionStringOrBaseUrl);
            }
            else
            {
                string connectionStringOrBaseUrl ="";
                new DatabaseConnectorSQL(connectionStringOrBaseUrl);
                usarWebApi=false;
            }
        }


        public async Task<string> GetExamenes()
        {
            if (usarWebApi)
            {
                string apiUrl = "https://localhost:7170/api/Examen";
                return  await DatabaseConnectorWebService.GetFromApiAsync(apiUrl);
            }
            else
            {
                return "";
            }
        }

        public async Task <ApiResponse<ExamenConsultId>> GetExamen(int id)
        {
            if (usarWebApi)
            {
                string apiUrl = "https://localhost:7170/api/Examen";
                return await DatabaseConnectorWebService.GetFromApiAsync(apiUrl, id);
            }
            else
            {
                return new ApiResponse<ExamenConsultId>();
            }
        }

        public async Task<ExamenCreate> CreateExamen(Examen examen)
        {
            if (usarWebApi)
            {
                string apiUrl = "https://localhost:7170/api/Examen";
                return await DatabaseConnectorWebService.PostToApiAsync(apiUrl, examen);
            }
            else
            {
                return await DatabaseConnectorSQL.EjecutarProcedimientoAlmacenado(examen);
            }
        }
        public async Task<string> UpdateExamen(Examen examen)
        {
            if (usarWebApi)
            {
                string apiUrl = "https://localhost:7170/api/Examen";
                return await DatabaseConnectorWebService.PutToApiAsync(apiUrl, examen);
            }
            else
            {
                return "";
            }
        }

        public async Task<string> DeleteExamen(int id)
        {
            if (usarWebApi)
            {
                string apiUrl = "https://localhost:7170/api/Examen";
                return await DatabaseConnectorWebService.DeleteFromApiAsync(apiUrl, id);
            }
            else
            {
                return "";
            }
        }

        public Examen Imprimir(Examen n)
        {


            // Serializa el objeto weatherForecast a una cadena JSON
            string jsonString = JsonConvert.SerializeObject(n);

            Console.WriteLine(jsonString);

            var deserializedForecast = JsonConvert.DeserializeObject<Examen>(jsonString);

            return deserializedForecast;
        }
    }
}

