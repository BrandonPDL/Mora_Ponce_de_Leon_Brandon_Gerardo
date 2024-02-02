using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apiexamen
{
    public class DatabaseConnectorSQL 
    {
        private string _connectionString;

        public DatabaseConnectorSQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static async Task<string> EjecutarProcedimientoAlmacenado(Examen examen)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=BdiExamen; User ID=sa; Password=1234;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spAgregar", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id", examen.IdExamen);
                        command.Parameters.AddWithValue("@Nombre", examen.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", examen.Descripcion);

                        command.Parameters.Add("@CodigoRetorno", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@DescripcionRetorno", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        int codigoRetorno = Convert.ToInt32(command.Parameters["@CodigoRetorno"].Value);
                        string descripcionRetorno = command.Parameters["@DescripcionRetorno"].Value.ToString();

                        return($"Resultado del procedimiento almacenado: Código {codigoRetorno}, Descripción: {descripcionRetorno}");
                    }
                }
            }
            catch (Exception ex)
            {
                return($"Error: {ex.Message}");
            }
        }


    }
}

