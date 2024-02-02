using Frontexamen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using apiexamen;
using Microsoft.Extensions.Options;
// ...otros using necesarios

public class ExamenController : Controller
{
    private clsExamen _clsExamen; // Asegúrate de inicializar esto adecuadamente

    // GET: Examen
    public IActionResult Index()
    {
        // Preparar el modelo inicial si es necesario
        return View();
    }
    public ExamenController(IOptions<ConnectionStrings> dbOptions, IOptions<WebServiceSettings> wsOptions)
    {
        // Decide si usar Web Service o procedimientos almacenados basado en la configuración o alguna acción del usuario
        bool useWebService = /* lógica para determinar esto */;
        string connectionString = useWebService ? wsOptions.Value.BaseUrl : dbOptions.Value.DefaultConnection;

        _clsExamen = new clsExamen(useWebService, connectionString);
    }
    [HttpPost]
    public IActionResult Agregar(ExamenModel model, bool useWebService)
    {
        try
        {
            // Inicializar clsExamen con la configuración de useWebService
            _clsExamen = new clsExamen(useWebService, "tu_connection_string");

            // Llamar a los métodos de clsExamen para agregar
            _clsExamen.AgregarExamen(model.Id, model.Nombre, model.Descripcion);
            ViewBag.Message = "Examen agregado con éxito.";
        }
        catch (Exception ex)
        {
            // Manejar excepciones y errores
            ViewBag.ErrorMessage = ex.Message;
        }
        return View("Index");
    }

    // Similar para las acciones de Actualizar y otros métodos necesarios
}
