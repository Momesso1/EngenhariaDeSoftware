using MoMotors.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoMotors.Areas.Identity.Models
{

    public class ChatIAModel
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }

        public virtual List<PerguntaRespostaModel> Chats { get; set; }
    }

    public class PerguntaRespostaModel
    {
        public int Id { get; set; }

        [Required]
        public int ChatIAModelId { get; set; }

        [ForeignKey(nameof(ChatIAModelId))]
        public virtual ChatIAModel ChatIA { get; set; }

        public string Pergunta { get; set; }

        public string Resposta { get; set; }

        public DateTime DataEnvio { get; set; } 
    }
}
