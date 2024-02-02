using System;
<<<<<<< Updated upstream
using apiexamen; // Asegúrate de incluir este using
=======
using System.Threading.Tasks;
using ClassLibrary1; // Asegúrate de incluir este using
>>>>>>> Stashed changes

namespace MiAplicacionDeConsola
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://localhost:7170/api/Examen";
            Examen examen = new Examen
            {
                IdExamen = 11,
                Nombre = "Hi",
                Descripcion = "string"
            };

            try
            {
<<<<<<< Updated upstream
                clsExamen dll = new clsExamen(true);
                string resultado = await dll.GetExamenes();
                Console.WriteLine("Respuesta de la API: ");
                Console.WriteLine(resultado);
                resultado = await dll.CreateExamen(examen);
                Console.WriteLine("Respuesta de la API: ");
                Console.WriteLine(resultado);
                resultado = await dll.GetExamen(examen.IdExamen);
                Console.WriteLine("Respuesta de la API: ");
                Console.WriteLine(resultado);
                resultado = await dll.UpdateExamen(examen);
                Console.WriteLine("Respuesta de la API: ");
                Console.WriteLine(resultado);
                resultado = await dll.DeleteExamen(examen.IdExamen);
                Console.WriteLine("Respuesta de la API: ");
                Console.WriteLine(resultado);
                resultado = await dll.GetExamenes();
                Console.WriteLine("Respuesta de la API: ");
                Console.WriteLine(resultado);

=======
                // Asumiendo que PostToApiAsync ahora devuelve un objeto RespuestaApi
                RespuestaApi respuesta = await ApiHelper.PostToApiAsync(url, examen);
                Console.WriteLine("Respuesta de la API: ");
                Console.WriteLine($"Id: {respuesta.Id}, Mensaje: {respuesta.Mensaje}");
                // Imprimir otras propiedades según sea necesario
>>>>>>> Stashed changes
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            Console.WriteLine("Presiona cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}
