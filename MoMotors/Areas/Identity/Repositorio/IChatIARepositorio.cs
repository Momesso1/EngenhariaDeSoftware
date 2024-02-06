using MoMotors.Areas.Identity.Models;
using MoMotors.Models;

namespace MoMotors.Areas.Identity.Repositorio
{
    public interface IChatIARepositorio
    {

        ChatIAModel AdicionarChat(ChatIAModel chats);
        List<ChatIAModel> ObterTodosOsChats();

    }
}
