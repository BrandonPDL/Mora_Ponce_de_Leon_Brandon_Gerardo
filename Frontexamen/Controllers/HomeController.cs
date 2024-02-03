using Frontexamen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Frontexamen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private List<ExamenModel> ObtenerExamenes()
        {
          return new List<ExamenModel>
            {
                new ExamenModel { Id = 1, Nombre = "Examen 1", Descripcion = "Descripción del Examen 1" },
                new ExamenModel { Id = 2, Nombre = "Examen 2", Descripcion = "Descripción del Examen 2" },
            };
        }
        public IActionResult Index()
        {
            List<ExamenModel> examenes = ObtenerExamenes(); 
            return View(examenes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}