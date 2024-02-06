using MoMotors.Areas.Identity.Repositorio;
using MoMotors.Data;
using MoMotors.Models;
using System.Security.Claims;

public class VeiculosRepositorio : IVeiculosRepositorio
{
    private readonly MoMotorsDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public VeiculosRepositorio(MoMotorsDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public VeiculosModel AdicionarVeiculoAoUsuario(VeiculosModel veiculos)
    {
        // Get the current user's ID from the HttpContext
        string currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        // Set the UserId property before adding to the context
        veiculos.UserId = currentUserId;

        _context.Veiculos.Add(veiculos);
        _context.SaveChanges();

        return veiculos;
    }

    public VeiculosModel ListarPorId(int id)
    {
        return _context.Veiculos.FirstOrDefault(x => x.Id == id);
    }

    public List<VeiculosModel> ObterTodosVeiculos()
    {
        return _context.Veiculos.ToList();
    }
}

