// See https://aka.ms/new-console-template for more information
using apiexamen;

Console.WriteLine("Hello, World!");


clsExamen examen = new clsExamen(true, "https://localhost:7170");

examen.AgregarExamen(8, "hola", "hola2");