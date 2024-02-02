using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiexamen
{
    public class clsExamen
    {
        private iDatabaseConnector _databaseConnector;

        public clsExamen(bool useWebService, string connectionString)
        {
            if (useWebService)
            {
                string baseUrl = connectionString;
                _databaseConnector = new DatabaseConnectorWebService(baseUrl);
            }
            else
            {
                _databaseConnector = new DatabaseConnectorSQL(connectionString);
            }
        }

        public void AgregarExamen(int id, string nombre, string descripcion)
        {
            if (!ValidarDatos(id, nombre, descripcion))
                throw new ArgumentException("Datos de examen inválidos");

            _databaseConnector.EjecutarProcedimientoAlmacenado("spAgregar", id, nombre, descripcion);
        }

        public void ActualizarExamen(int id, string nombre, string descripcion)
        {
            if (!ValidarDatos(id, nombre, descripcion))
                throw new ArgumentException("Datos de examen inválidos");

            _databaseConnector.EjecutarProcedimientoAlmacenado("spActualizar", id, nombre, descripcion);
        }

        private bool ValidarDatos(int id, string nombre, string descripcion)
        {
            if (id <= 0)
                return false;
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length > 100) 
                return false;
            if (string.IsNullOrWhiteSpace(descripcion) || descripcion.Length > 500) 
                return false;
            return true;
        }
    }
}
