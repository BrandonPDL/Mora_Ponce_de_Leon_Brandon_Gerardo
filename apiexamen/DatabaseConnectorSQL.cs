using System;
using System.Data;
using System.Data.SqlClient;

namespace apiexamen
{
    public class DatabaseConnectorSQL : iDatabaseConnector
    {
        private string _connectionString;

        public DatabaseConnectorSQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void EjecutarProcedimientoAlmacenado(string nombreProcedimiento, params object[] parametros)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(nombreProcedimiento, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Add parameters to the command
                foreach (var param in parametros)
                {
                    command.Parameters.AddWithValue(param.ToString(), parametros[Array.IndexOf(parametros, param) + 1]);
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

