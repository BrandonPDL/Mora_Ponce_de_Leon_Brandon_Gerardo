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
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Se Agregan los parametros al comando
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    string paramName = parametros[i].ToString();
                    object paramValue = parametros[i + 1];
                    cmd.Parameters.AddWithValue(paramName, paramValue ?? DBNull.Value);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
