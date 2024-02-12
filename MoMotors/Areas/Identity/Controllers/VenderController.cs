using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoMotors.Areas.Identity.Data;
using MoMotors.Areas.Identity.Repositorio;
using MoMotors.Data;
using MoMotors.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace MoMotors.Areas.Identity.Controllers
{
    [Authorize]
    public class VenderController : Controller
    {
        private readonly MoMotorsDbContext _context;
        private readonly IVeiculosRepositorio _veiculosRepositorio;
        private readonly UserManager<ApplicationUser> _userManager;


        public VenderController(MoMotorsDbContext context, IVeiculosRepositorio veiculosRepositorio, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _veiculosRepositorio = veiculosRepositorio;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View("~/Areas/Identity/Pages/Vender/Index.cshtml");
        }



        [HttpPost]
        public IActionResult AdicionarVeiculoAoUsuario(VeiculosModel veiculos, List<IFormFile> imagens)
        {
            _veiculosRepositorio.AdicionarVeiculoAoUsuario(veiculos, imagens);

            return RedirectToAction("Index");
        }





    }
}
