
using System;
using System.Threading.Tasks;
using System.Security.Permissions;
using Newtonsoft.Json;
using System.Collections.Generic;
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
                new DatabaseConnectorWebService();
                usarWebApi = true;
            }
            else
            {
                string connectionStringOrBaseUrl ="";
                new DatabaseConnectorSQL(connectionStringOrBaseUrl);
                usarWebApi=false;
            }
        }


        public async Task<List<Examen>> GetExamenes()
        {
            if (usarWebApi)
            {
                return  await DatabaseConnectorWebService.GetFromApiAsync();
            }
            else
            {
                return new List<Examen>();
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
                return await DatabaseConnectorSQL.EjecutarProcedimientoAlmacenado("spAgregar", examen);
            }
        }
        public async Task<ExamenCreate> UpdateExamen(Examen examen)
        {
            if (usarWebApi)
            {
                string apiUrl = "https://localhost:7170/api/Examen";
                return await DatabaseConnectorWebService.PutToApiAsync(examen);
            }
            else
            {
                return await DatabaseConnectorSQL.EjecutarProcedimientoAlmacenado("spActualizar", examen);
            }
        }

        public async Task<ExamenCreate> DeleteExamen(Examen examen)
        {
            if (usarWebApi)
            {
                string apiUrl = "https://localhost:7170/api/Examen";
                return await DatabaseConnectorWebService.DeleteFromApiAsync(examen);
            }
            else
            {
                return await DatabaseConnectorSQL.EjecutarProcedimientoAlmacenado("spEliminar", examen);
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

