using MoMotors.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoMotors.Models
{
    public class VeiculosModel
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string? Tipo { get; set; }

        [Required]
        public string? Marca { get; set; }

        [Required]
        public string? Preco { get; set; }

        [Required]
        public string? Modelo { get; set; }

        [Required]
        public string? AnoECombustivel { get; set; }

        [Required]
        public string? Condicao { get; set; }
        public string? Quilometragem { get; set; }

        
        
        public string? Cor {  get; set; }

        [Required]
        public string? Cambio { get; set; }

        [Required]
        public string? Descricao { get; set; }

        public string? FIPE { get; set; }

        public bool? Airbag { get; set; }
        public bool? Alarme { get; set; }
        public bool? ArCondicionado { get; set; }

        public bool? BancoComRegulagemDeAltura { get; set; }
        public bool? BancosComAquecimento { get; set; }
        public bool? BancosEmCouro { get; set; }
        public bool? ControleAutomaticoDeVelocidade { get; set; }
        public bool? ControleDeTracao { get; set; }
        public bool? DesembacadorTraseiro { get; set; }
        public bool? DirecaoHidraulica { get; set; }

        public bool? EncostoDeCabecaTraseiro { get; set; }
        public bool? FarolDeXenonio { get; set; }
        public bool? FreioABS { get; set; }
        public bool? GPS { get; set; }

        public bool? LimpadorTraseiro { get; set; }
        public bool? Radio { get; set; }
        public bool? RetrovisoresEletricos { get; set; }

        public bool? SensorDeChuva { get; set; }
        public bool? SensorDeEstacionamento { get; set; }
        public bool? TetoSolar { get; set; }

        public bool? Tracao4x4 { get; set; }
        public bool? TravasEletricas { get; set; }
        public bool? VidrosEletricos { get; set; }

        public bool? VolanteComRegulagemDeAltura { get; set; }

    }
}
