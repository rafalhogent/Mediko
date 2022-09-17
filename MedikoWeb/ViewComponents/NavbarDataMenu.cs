using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MedikoData.Entities;
using MedikoWeb.Models;

namespace MedikoWeb.ViewComponents
{
    public class NavbarDataMenu : ViewComponent
    {
        private readonly SignInManager<AppUser> _signinManager;
        public NavbarDataMenu(SignInManager<AppUser> signinManager)
        {
            _signinManager = signinManager;
        }

        public IViewComponentResult Invoke()
        {
            if (_signinManager.IsSignedIn((System.Security.Claims.ClaimsPrincipal)User))
            {
                
                return View("NavbarDataMenu");
            }


            else return View();
        }
    }
}
