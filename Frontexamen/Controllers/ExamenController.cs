using Frontexamen.Models;
using Microsoft.AspNetCore.Mvc;
using System;

using apiexamen;
using Newtonsoft.Json; 
public class RespuestaExamen
{
    public bool Respuesta { get; set; }
    public string Descripcion { get; set; }
}
public class ExamenController : Controller
{
    

    public IActionResult Index()
    {

        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Agregar(Examen examen)
    {
        if (ModelState.IsValid)
        {
            clsExamen dll = new clsExamen(true);
            string jsonRespuesta = await dll.CreateExamen( examen);
            var resultado = JsonConvert.DeserializeObject<RespuestaExamen>(jsonRespuesta);

            if (!resultado.Respuesta)
            {
                return Json(new { success = false, message = resultado.Descripcion });
            }

            return Json(new { success = true, message = "Examen agregado correctamente" });
        }
        else
        {
            return Json(new { success = false, message = "Datos del examen no son válidos." });
        }
    }

    public async Task<ActionResult> Buscar(int id)
    {

        clsExamen dll = new clsExamen(true);
        string jsonRespuesta = await dll.GetExamen(id);
        var examen = JsonConvert.DeserializeObject<Examen>(jsonRespuesta);
        return Json(new { respuesta = examen });

    }

}
