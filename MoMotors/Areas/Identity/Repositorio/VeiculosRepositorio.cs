using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoMotors.Areas.Identity.Repositorio;
using MoMotors.Data;
using MoMotors.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    private byte[] SalvarImagem(IFormFile imagem)
    {
        using (var memoryStream = new MemoryStream())
        {
            imagem.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }

    public void AdicionarVeiculoAoUsuario(VeiculosModel veiculos)
    {
        string currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(currentUserId))
        {
            throw new InvalidOperationException("Usuário não autenticado.");
        }

        veiculos.UserId = currentUserId;
       

        _context.Veiculos.Add(veiculos);
        _context.SaveChanges();
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
