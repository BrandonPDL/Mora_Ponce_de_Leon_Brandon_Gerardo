
using System;

namespace apiexamen
{
    public class clsExamen
    {
        private iDatabaseConnector _databaseConnector;

        public clsExamen(bool useWebService)
        {
            if (useWebService)
            {
                string connectionStringOrBaseUrl = "";
                _databaseConnector = new DatabaseConnectorWebService(connectionStringOrBaseUrl);
            }
            else
            {
                string connectionStringOrBaseUrl ="";
                _databaseConnector = new DatabaseConnectorSQL(connectionStringOrBaseUrl);
            }
        }

        public void GuardarExamen(string nombreProcedimiento, params object[] parametros)
        {
            _databaseConnector.EjecutarProcedimientoAlmacenado(nombreProcedimiento, parametros);
        }
    }
}

