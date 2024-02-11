using Microsoft.AspNetCore.Mvc;
using MoMotors.Models;

namespace MoMotors.Areas.Identity.Repositorio
{
    public interface IVeiculosRepositorio
    {

        void AdicionarVeiculoAoUsuario(VeiculosModel veiculos);
        VeiculosModel ListarPorId(int id);

        List<VeiculosModel> ObterTodosVeiculos();

    }
}
