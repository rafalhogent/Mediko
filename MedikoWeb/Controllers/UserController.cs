using MedikoData.Entities;
using MedikoData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MedikoWeb.Models;
using MedikoServices;
using System.Linq;

namespace MedikoWeb.Controllers
{
    [Route("Account")]
    public class UserController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly LogBookService _logbookService;

        public UserController(UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager,
                              LogBookService logBookService
            )
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _logbookService = logBookService;
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
                if (string.IsNullOrEmpty(userVM.UserName) || string.IsNullOrEmpty(userVM.Password))
                {
                    ModelState.AddModelError("LoginError", "Gebruikersnaam en wachtwoor zij verplicht");
                    return View();
                }
                var foundUser = await _userManager.FindByNameAsync(userVM.UserName);
                if (foundUser == null)
                {
                    ModelState.AddModelError("LoginError", "Gebruikersnaam of wachtoord niet correct");
                    return View();
                }

                var result = await _signinManager
                    .PasswordSignInAsync(foundUser, userVM.Password, false, false);

                if (result.Succeeded) return RedirectToAction(nameof(Dashboard));

            }
            return View();
        }



        [Route("Logout")]
        public async Task<IActionResult> Logout()
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
                    var nieuwUser = _userManager.FindByNameAsync(user.UserName).Result;


                    if (!_userManager.IsInRoleAsync(nieuwUser, "Patient").Result)
                    {
                        await _userManager.AddToRoleAsync(nieuwUser, "Patient");
                    }

                    await _signinManager.SignInAsync(nieuwUser, isPersistent: false);


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

        [Route("Options")]
        public async Task<IActionResult> Options()
        {
            if (User?.Identity?.IsAuthenticated != true)
                return RedirectToAction(nameof(Login));

            var user = await _userManager.GetUserAsync(User);

            var logbooksForUser = await _logbookService.GetLogBooksForUser(user.Id);
            var choosenLogbooks = await _logbookService.GetChoosenLogbooks(user.Id);

            List<LogbookSelection> logbooksSelections = new List<LogbookSelection>();

            foreach (var logbook in logbooksForUser)
            {
                logbooksSelections.Add(new LogbookSelection
                {
                    LogbookName = logbook.Name,
                    LogbookId = logbook.LogBookId,
                    IsSelected = choosenLogbooks.Contains(logbook)
                }); ;
            }

            UserOptionsViewModel optionsVM = new UserOptionsViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,

                LogbookSelections = logbooksSelections

            };
            return View(optionsVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateChoosenLogbooks(UserOptionsViewModel optionsVM)
        {
            var logbooksForUser = await _logbookService.GetLogBooksForUser(optionsVM.UserId);
            var choosenLogbooks = await _logbookService.GetChoosenLogbooks(optionsVM.UserId);

            foreach (var selection in optionsVM.LogbookSelections)
            {
                if (selection.IsSelected)
                {
                    if (!choosenLogbooks.Contains(_logbookService.GetLogBookById(selection.LogbookId).Result))
                    {
                        await _logbookService.AddChoosenLogbookForUser(optionsVM.UserId, selection.LogbookId);
                    }
                }
                else
                {
                    if (choosenLogbooks.Contains(_logbookService.GetLogBookById(selection.LogbookId).Result))
                    {
                        await _logbookService.RemoveFromChoosenLogbooksForUser(optionsVM.UserId, selection.LogbookId);
                    }
                }
            }

            return RedirectToAction(nameof(Options));
        }



    }
}
