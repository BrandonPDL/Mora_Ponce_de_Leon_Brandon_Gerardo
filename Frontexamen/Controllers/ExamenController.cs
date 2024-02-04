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
    public async Task<ExamenCreate> Agregar(Examen examen)
    {
        if (ModelState.IsValid)
        {
            clsExamen dll = new clsExamen(true);
            ExamenCreate resultadoJson = await dll.CreateExamen(examen);
            return resultadoJson;
        }
        else
        {
            ExamenCreate ex = new ExamenCreate();
            ex.Descripcion = "Datos Invalidos,Favor de verificar la informacion.";
            ex.Respuesta = false;
            return ex;        
        }
    }

    public async Task<ApiResponse<ExamenConsultId>> Buscar(int id)
    {

        clsExamen dll = new clsExamen(true);
        ApiResponse<ExamenConsultId> jsonRespuesta = await dll.GetExamen(id);
        
        return jsonRespuesta;

    }

}
