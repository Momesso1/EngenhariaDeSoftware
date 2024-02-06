using MoMotors.Models;

namespace MoMotors.Areas.Identity.Repositorio
{
    public interface IVeiculosRepositorio
    {

        VeiculosModel AdicionarVeiculoAoUsuario(VeiculosModel veiculos);
        VeiculosModel ListarPorId(int id);
        List<VeiculosModel> ObterTodosVeiculos();

    }
}
