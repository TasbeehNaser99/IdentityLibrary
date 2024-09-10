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
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsController(ApplicationDbContext _context,UserManager<IdentityUser> _userManager,SignInManager<IdentityUser>_signInManager)
        {
            context = _context;
            userManager = _userManager;
            signInManager = _signInManager;
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
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
