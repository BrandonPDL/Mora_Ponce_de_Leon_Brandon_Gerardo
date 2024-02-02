
using System;
using System.Threading.Tasks;

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

        public async Task<string> GetExamen(int id)
        {
            if (usarWebApi)
            {
                string apiUrl = "https://localhost:7170/api/Examen";
                return await DatabaseConnectorWebService.GetFromApiAsync(apiUrl, id);
            }
            else
            {
                return "";
            }
        }

        public async Task<string> CreateExamen(Examen examen)
        {
            if (usarWebApi)
            {
                string apiUrl = "https://localhost:7170/api/Examen";
                return await DatabaseConnectorWebService.PostToApiAsync(apiUrl, examen);
            }
            else
            {
                return "";
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

    }
}

