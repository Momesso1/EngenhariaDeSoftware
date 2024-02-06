using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoMotors.Areas.Identity.Data;
using System.Diagnostics;

namespace MoMotors.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            return View("~/Areas/Identity/Pages/Home/Index.cshtml");

        }




    }
}
