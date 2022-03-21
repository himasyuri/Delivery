using Delivery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Delivery.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Controllers
{
    public class CommentsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext db;

        public CommentsController(UserManager<User> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            db = context;
        }

        [HttpGet]
        public IActionResult AddComment()
        {
            return View("AddComment");
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel model, string id)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Application application = await db.Applications.FindAsync(id);
            if (user != null & application != null)
            {
                Comment comment = new Comment { Description = model.Description, Application = application };
                await db.Comments.AddAsync(comment);
                await db.SaveChangesAsync();
                return RedirectToAction("ApplicationList", "Application");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SeeComment(string id)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Application application = await db.Applications.FindAsync(id);
            if (user != null & application != null)
            {
                Comment comment = await db.Comments.FirstOrDefaultAsync(p => p.ApplicationId == application.Id);
                return View(comment);
            }
            return NotFound();
        }
    }
}
