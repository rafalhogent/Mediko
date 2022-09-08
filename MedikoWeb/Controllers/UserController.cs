using MedikoData.Entities;
using MedikoData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MedikoWeb.Models;

namespace MedikoWeb.Controllers
{
    [Route("")]
    public class UserController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly MedikoDbContext _medikoDbContext;

        public UserController(UserManager<AppUser> userManager,
                    SignInManager<AppUser> signInManager,
                    MedikoDbContext medikoDbContext)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _medikoDbContext = medikoDbContext;
        }



        public IActionResult Index()
        {

            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction(nameof(Dashboard));

            return RedirectToAction(nameof(Login));
        }


        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            ViewData["userName"] = User?.Identity?.Name + "";
            if (User?.Identity?.IsAuthenticated != true)
                return RedirectToAction(nameof(Login));

            return View();

        }


        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginViewModel userVM)
        {
            if (ModelState.IsValid)
            {

                var foundUser = await _userManager.FindByNameAsync(userVM.UserName);
                if (foundUser == null) return NotFound();

                var result = await _signinManager
                    .PasswordSignInAsync(foundUser, userVM.Password, false, false);

                if (result.Succeeded) return RedirectToAction(nameof(Dashboard));

            }
            return View();
        }


        //[Route("Logout")]
        //public async Task<IActionResult> LogOut()
        //{
        //    await _signinManager.SignOutAsync();
        //    return RedirectToAction(nameof(Index), nameof(HomeController));
        //}


        [Route("Logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }


        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegisterViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = userVM.UserName,

                };

                var result = await _userManager.CreateAsync(user, userVM.Password);

                if (result.Succeeded)
                {
                    await _signinManager.SignInAsync(user, isPersistent: false);


                    return RedirectToAction(nameof(Index), "Home");
                }

                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError("", error.Description);
                //}
                //ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(userVM);
        }
    }
}
