using MoMotors.Areas.Identity.Models;
using MoMotors.Data;
using MoMotors.Models;
using System.Security.Claims;

namespace MoMotors.Areas.Identity.Repositorio
{
    public class ChatIARepositorio : IChatIARepositorio
    {
        private readonly MoMotorsDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatIARepositorio(MoMotorsDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public ChatIAModel AdicionarChat(ChatIAModel chats)
        {
            string currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            chats.UserId = currentUserId;

            _context.ChatIA.Add(chats);
            _context.SaveChanges();

            return chats;
        }

        public List<ChatIAModel> ObterTodosOsChats()
        {
             return _context.ChatIA.ToList();
        }
    }
}
