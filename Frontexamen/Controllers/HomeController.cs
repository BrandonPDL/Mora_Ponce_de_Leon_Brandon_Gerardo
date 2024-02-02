using Frontexamen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Frontexamen.Controllers
{
    public class HomenController : Controller
    {
        private readonly ILogger<HomenController> _logger;

        public HomenController(ILogger<HomenController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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