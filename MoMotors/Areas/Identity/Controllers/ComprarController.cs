using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoMotors.Areas.Identity.Repositorio;
using MoMotors.Data;
using MoMotors.Models;

namespace MoMotors.Controllers
{
    public class ComprarController : Controller
    {
        private readonly IVeiculosRepositorio _veiculosRepositorio;
        private readonly MoMotorsDbContext _moMotorsDbContext; // Add this field

        public ComprarController(IVeiculosRepositorio veiculosRepositorio, MoMotorsDbContext moMotorsDbContext)
        {
            _veiculosRepositorio = veiculosRepositorio;
            _moMotorsDbContext = moMotorsDbContext; // Updated assignment
        }

        public IActionResult Index()
        {
            List<VeiculosModel> veiculos = _veiculosRepositorio.ObterTodosVeiculos();

            return View("~/Areas/Identity/Pages/Comprar/Index.cshtml", veiculos);
        }

        public IActionResult Detalhes(int id)
        {
            var veiculo = _moMotorsDbContext.Veiculos
                .Include(v => v.Imagens)  // Assuming "Imagens" is the correct property
                .FirstOrDefault(v => v.Id == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return View("~/Areas/Identity/Pages/Comprar/Detalhes.cshtml", veiculo);
        }
    }
}
