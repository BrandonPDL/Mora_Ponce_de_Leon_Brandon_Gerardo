using Frontexamen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using apiexamen;
using ClassLibrary1;

public class ExamenController : Controller
{
    private clsExamen _clsExamen; // Asegúrate de inicializar esto adecuadamente

    // GET: Examen
    public IActionResult Index()
    {
        // Preparar el modelo inicial si es necesario
        return View();
    }

    public ActionResult Agregar(Examen examen)
    {
        // Lógica para agregar el examen
        // ...

        return Json(new { success = true, message = "Examen agregado correctamente" });
    }
    // Similar para las acciones de Actualizar y otros métodos necesarios
}
