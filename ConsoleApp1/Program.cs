using System;
using apiexamen;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)  // Note the 'async Task' instead of 'void'
        {
            Examen miObjeto = new Examen();
            miObjeto.Nombre = "Piel";
            miObjeto.IdExamen = 16;
            miObjeto.Descripcion = "Descripcion";

            clsExamen miClase = new clsExamen(false);

            var resultado = await miClase.CreateExamen(miObjeto);  // Await the result here

            Console.WriteLine(resultado);  // Now 'resultado' should be of type 'ExamenCreate'
        }
    }
}
