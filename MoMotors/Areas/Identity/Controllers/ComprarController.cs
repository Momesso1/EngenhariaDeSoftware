using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoMotors.Areas.Identity.Repositorio;
using MoMotors.Data;
using MoMotors.Models;
using System.Globalization;

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
                .Include(v => v.Imagens)
                .FirstOrDefault(v => v.Id == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            var veiculosMesmoTipo = _moMotorsDbContext.Veiculos
                .Where(v => v.Marca == veiculo.Marca &&
                            v.Modelo == veiculo.Modelo &&
                            v.AnoECombustivel == veiculo.AnoECombustivel)
                .ToList();



            // Calcular a média dos preços
            decimal mediaPreco = veiculosMesmoTipo
        .Where(v => !string.IsNullOrWhiteSpace(v.Preco))
        .Select(v => decimal.Parse(v.Preco, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR")))
        .Average();

            ViewData["MediaPreco"] = mediaPreco.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

            return View("~/Areas/Identity/Pages/Comprar/Detalhes.cshtml", veiculo);
        }

    }
}
