using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using MoMotors.Areas.Identity.Models;
using MoMotors.Data;
using MoMotors.Models;

namespace MoMotors.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

       

        public int GetQuantidadeVeiculosRegistradosNoBancoDeDados(MoMotorsDbContext MoMotorsDbContext)
        {
            if (MoMotorsDbContext != null && !string.IsNullOrEmpty(Id))
            {
                // Consulta para contar a quantidade de veículos registrados para o usuário pelo Id
                return MoMotorsDbContext.Veiculos
                    .Where(v => v.UserId == Id)
                    .Count();
            }
            else
            {
                return 0; // Se o contexto ou o Id do usuário forem nulos, retorna 0
            }
        }

        public List<VeiculosModel> GetVeiculosÀVenda(MoMotorsDbContext MoMotorsDbContext)
        {
            if (MoMotorsDbContext != null && !string.IsNullOrEmpty(Id))
            {
                // Consulta para obter a lista de veículos registrados para o usuário pelo Id
                return MoMotorsDbContext.Veiculos
                    .Where(v => v.UserId == Id)
                    .ToList();
            }
            else
            {
                return new List<VeiculosModel>(); // Se o contexto ou o Id do usuário forem nulos, retorna uma lista vazia
            }
        }

        public virtual ICollection<VeiculosModel> Veiculos { get; set; }

        public virtual ICollection<ChatIAModel> ChatIA { get; set; }

    }

}
