using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoMotors.Areas.Identity.Data;
using MoMotors.Areas.Identity.Models;
using MoMotors.Models;
using System.Reflection.Emit;

namespace MoMotors.Data
{
    public class MoMotorsDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<VeiculosModel> Veiculos { get; set; }
        public DbSet<ChatIAModel> ChatIA { get; set; }

        public DbSet<ImagemVeiculo> ImagensVeiculo { get; set; }

        public MoMotorsDbContext(DbContextOptions<MoMotorsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Veiculos)
                .WithOne(v => v.User)  
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.ChatIA)
                .WithOne(c => c.User)  // Corrigindo aqui para apontar para a propriedade User
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

          //  builder.Entity<VeiculosModel>()
            // .HasMany(v => v.ImagensVeiculo)
             //.WithOne(iv => iv.Veiculo)
             //.HasForeignKey(iv => iv.VeiculoId);
        }
    }
}
