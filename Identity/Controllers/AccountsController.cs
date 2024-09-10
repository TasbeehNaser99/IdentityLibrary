using Identity.Data;
using Identity.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public AccountsController(ApplicationDbContext _context,UserManager<IdentityUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.phone
            };
         var result=  await userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        public IActionResult Login() { 
            return Content("login page"); 
        }
    }
}
