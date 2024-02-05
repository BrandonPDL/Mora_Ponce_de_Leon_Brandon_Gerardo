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

        public static async Task<ExamenCreate> EjecutarProcedimientoAlmacenado(string comand, Examen examen)
        {
            string connectionStrin = "Server=localhost; Database=BdiExamen; User Id=sa; Password=1234;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStrin))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(comand, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id", examen.IdExamen);
                        if (comand != "spEliminar")
                        {
                            command.Parameters.AddWithValue("@Nombre", examen.Nombre);
                            command.Parameters.AddWithValue("@Descripcion", examen.Descripcion);
                        }
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                ExamenCreate response = new ExamenCreate
                                {
                                    Respuesta = true,
                                    Descripcion = reader.GetString(reader.GetOrdinal("DescripcionRetorno"))
                                };

                                return response;
                            }
                            else
                            {
                                // Handle the case when no result set is returned
                                throw new InvalidOperationException("No data returned from stored procedure.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                return new ExamenCreate
                {
                    Respuesta = false,
                    Descripcion = ex.Message
                };
            }
        }


    }
}

