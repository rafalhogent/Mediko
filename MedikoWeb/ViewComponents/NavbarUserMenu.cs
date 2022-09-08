using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MedikoData.Entities;

namespace MedikoWeb.ViewComponents
{
    public class NavbarUserMenu : ViewComponent
    {
        private readonly SignInManager<AppUser> _signinManager;
        public NavbarUserMenu(SignInManager<AppUser> signinManager)
        {
            _signinManager = signinManager;
        }

        public IViewComponentResult Invoke()
        {
            var isUserSignedIn = _signinManager.IsSignedIn((System.Security.Claims.ClaimsPrincipal)User);

            var userName = User?.Identity?.Name;

            if (isUserSignedIn)
                return View("SignedUserMenu", (object)("" + User?.Identity?.Name));
            else return View("UnSignedUserMenu");
        }
    }
}
