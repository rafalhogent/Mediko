using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MedikoData.Entities;

namespace MedikoWeb.ViewComponents
{
    public class NavbarSecurityMenu : ViewComponent
    {
        private readonly SignInManager<AppUser> _signinManager;
        private readonly UserManager<AppUser> _userManager;

        public NavbarSecurityMenu(SignInManager<AppUser> signinManager, UserManager<AppUser> userManager)
        {
            _signinManager = signinManager;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            //var isUserSignedIn = _signinManager.IsSignedIn((System.Security.Claims.ClaimsPrincipal)User);
            //var userName = User?.Identity?.Name;
            //var user = _signinManager.UserManager.GetUserAsync(User.);

            if (User.IsInRole("Admin"))
            {
                return View("NavbarSecurityMenu");
            }

            return View();

        }
    }
}
