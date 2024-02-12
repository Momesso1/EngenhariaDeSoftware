using Microsoft.AspNetCore.Mvc;
using MoMotors.Models;

namespace MoMotors.Areas.Identity.Repositorio
{
    public interface IVeiculosRepositorio
    {

        void AdicionarVeiculoAoUsuario(VeiculosModel veiculo, List<IFormFile> imagens);
        VeiculosModel ListarPorId(int id);
        List<VeiculosModel> ObterTodosVeiculos();

    }
}
