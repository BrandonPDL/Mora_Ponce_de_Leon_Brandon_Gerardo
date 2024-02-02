using System;
using ClassLibrary1; // Asegúrate de incluir este using

namespace MiAplicacionDeConsola
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://localhost:7170/api/Examen";
            Examen examen = new Examen
            {
                IdExamen = 10,
                Nombre = "Hi",
                Descripcion = "string"
            };

            try
            {
                string resultado = await ApiHelper.PostToApiAsync(url, examen);
                Console.WriteLine("Respuesta de la API: ");
                Console.WriteLine(resultado);
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
