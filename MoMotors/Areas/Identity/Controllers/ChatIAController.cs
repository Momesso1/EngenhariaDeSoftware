using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoMotors.Areas.Identity.Data;
using MoMotors.Areas.Identity.Models;
using MoMotors.Areas.Identity.Repositorio;
using MoMotors.Data;


namespace MoMotors.Controllers
{
    [Authorize]
    public class ChatIAController : Controller
    {
        private readonly MoMotorsDbContext _context;
        private readonly IChatIARepositorio _chatRepositorio;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatIAController(MoMotorsDbContext context, IChatIARepositorio chatRepositorio, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _chatRepositorio = chatRepositorio;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View("~/Areas/Identity/Pages/ChatIA/Index.cshtml");
        }

        public IActionResult AdicionarChat(ChatIAModel chats)
        {
            _chatRepositorio.AdicionarChat(chats);
            return RedirectToAction("Index");
        }

    }
}
