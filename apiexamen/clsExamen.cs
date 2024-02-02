
using System;

namespace apiexamen
{
    public class clsExamen
    {
        private iDatabaseConnector _databaseConnector;

        public clsExamen(bool useWebService, string connectionStringOrBaseUrl)
        {
            if (useWebService)
            {
                _databaseConnector = new DatabaseConnectorWebService(connectionStringOrBaseUrl);
            }
            else
            {
                _databaseConnector = new DatabaseConnectorSQL(connectionStringOrBaseUrl);
            }
        }

        public void GuardarExamen(string nombreProcedimiento, params object[] parametros)
        {
            _databaseConnector.EjecutarProcedimientoAlmacenado(nombreProcedimiento, parametros);
        }
    }
}

