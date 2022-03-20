using Delivery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Delivery.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Delivery.Controllers
{
    public class ApplicationController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly ApplicationContext db;

        public ApplicationController(UserManager<User> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            db = context;
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(HttpContext.User);
                if (user != null)
                {
                    Application application = new Application { Text = model.Text, StartedWay = model.StartedWay, EndedWay = model.EndedWay, NumberOfCars = model.NumberOfCars, UserId = user.Id };
                    if (application.StartedWay != null & application.EndedWay != null & application.NumberOfCars != 0)
                    {
                        await db.Applications.AddAsync(application);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View(model); 
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationList() => View(await db.Applications.ToListAsync());

        [HttpGet]
        public async Task<IActionResult> Approve(string id)
        {
            if (ModelState.IsValid)
            {
                Application application = await db.Applications.FindAsync(id);
                if (application != null)
                {
                    application.IsReeded = true;
                    application.IsApproved = true;
                    await db.SaveChangesAsync();
                    return RedirectToAction("ApplicationList", "Application");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Regect(string id)
        {
            if (ModelState.IsValid)
            {
                Application application = await db.Applications.FindAsync(id);
                if (application != null)
                {
                    application.IsReeded = true;
                    application.IsApproved = false;
                    await db.SaveChangesAsync();
                    return RedirectToAction("ApplicationList", "Application");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Application application = await db.Applications.FindAsync(id);
            if (application != null & user != null)
            {
                Comment comment = await db.Comments.FirstOrDefaultAsync(p => p.ApplicationId == application.Id);
                db.Comments.Remove(comment);
                db.Applications.Remove(application);
                await db.SaveChangesAsync();
                return RedirectToAction("ApplicationList", "Application");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Seemore(string id)
        {
            if (id != null)
            {
                Application application = await db.Applications.FirstOrDefaultAsync(p => p.Id == id);
                if (application != null)
                {
                    return View(application);
                }
            }
            return NotFound();
        }
        
        [HttpGet]
        public async Task<IActionResult> UsersApplications()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                return View(await db.Applications.Where(p => p.UserId == user.Id)
                                                  .ToListAsync());
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Pay() =>  View("Pay");
    }
}
