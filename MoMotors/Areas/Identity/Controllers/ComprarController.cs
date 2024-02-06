using Microsoft.AspNetCore.Mvc;
using MoMotors.Areas.Identity.Repositorio;
using MoMotors.Models;

namespace MoMotors.Controllers
{
    public class ComprarController : Controller
    {
        private readonly IVeiculosRepositorio _veiculosRepositorio;

        public ComprarController(IVeiculosRepositorio veiculosRepositorio)
        {
            _veiculosRepositorio = veiculosRepositorio;
        }

        public IActionResult Index()
        {
            List<VeiculosModel> veiculos = _veiculosRepositorio.ObterTodosVeiculos();

            return View("~/Areas/Identity/Pages/Comprar/Index.cshtml", veiculos);
        }

        public IActionResult Detalhes(int id)
        {
            VeiculosModel veiculo = _veiculosRepositorio.ListarPorId(id);
            return View("~/Areas/Identity/Pages/Comprar/Detalhes.cshtml", veiculo);
        }


        

    }
}
