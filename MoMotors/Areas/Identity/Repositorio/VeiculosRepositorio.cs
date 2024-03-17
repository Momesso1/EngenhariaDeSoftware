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


    public void AdicionarVeiculoAoUsuario(VeiculosModel veiculo, List<IFormFile> imagens)
    {
        string currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(currentUserId))
        {
            throw new InvalidOperationException("Usuário não autenticado.");
        }

        veiculo.UserId = currentUserId;

        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();

        // Associar imagens ao veículo e salvar no banco de dados
        foreach (var imagem in imagens)
        {
            byte[] dadosImagem = ConverterImagemParaBytes(imagem);

            var novaImagem = new ImagemVeiculo
            {
                VeiculoId = veiculo.Id,
                DadosDaImagem = dadosImagem
            };

            _context.ImagensVeiculo.Add(novaImagem);
        }

        _context.SaveChanges();
    }

    // Método para converter IFormFile em byte[]
    private byte[] ConverterImagemParaBytes(IFormFile imagem)
    {
        using (var stream = new MemoryStream())
        {
            imagem.CopyTo(stream);
            return stream.ToArray();
        }
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
