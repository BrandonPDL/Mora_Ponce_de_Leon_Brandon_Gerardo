using Frontexamen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using clsExamen;

public class ExamenController : Controller
{
    private clsExamen _clsExamen; // Asegúrate de inicializar esto adecuadamente

    // GET: Examen
    public IActionResult Index()
    {
        // Preparar el modelo inicial si es necesario
        return View();
    }

    
    // Similar para las acciones de Actualizar y otros métodos necesarios
}
