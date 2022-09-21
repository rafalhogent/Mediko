using MedikoData.Entities;
using MedikoWeb.Models;
using MedikoServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace MedikoWeb.Controllers
{
    public class LogsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly LogBookService _logbookService;
        private readonly LogsService _logsService;

        public LogsController(UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager,
                              LogBookService logBookService,
                              LogsService logsService)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _logbookService = logBookService;
            _logsService = logsService;
        }

        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated != true)
                return RedirectToAction("Login", "User");
            //return View();
            return RedirectToAction("Dashboard", "User");
        }

        //[Route("{controller=Logs}/{action=Diary}/{logbookid?}")]
        public async Task<IActionResult> Diary(int logbookId)
        {
            if (logbookId < 1) return RedirectToAction("Dashboard", "User");
            if (User?.Identity?.IsAuthenticated != true)
                return RedirectToAction("Login", "User");

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return RedirectToAction("Login", "User");

            DiaryViewModel diaryVM = new DiaryViewModel();
            var logbook = _logbookService.GetLogBookById(logbookId).Result;
            if (logbook == null) RedirectToAction("Index", "Home");

            diaryVM.Logbook = _logbookService.GetLogBookById(logbookId).Result;
            diaryVM.UserLogs = new List<Log>();

            diaryVM.NewLog = new LogViewModel();

            diaryVM.NewLog.LogbookId = logbookId;
            //diaryVM.NewLog.Date = DateOnly.FromDateTime(DateTime.Now);
            //diaryVM.NewLog.Time = TimeOnly.FromDateTime(DateTime.Now);
            diaryVM.NewLog.DateAndTime = DateTime.Now;

            var userLogs = await _logsService.GetUserLogsByLogbookIdAsync(currentUser.Id, logbookId);
            diaryVM.UserLogs = userLogs != null ? userLogs.ToList() : new List<Log>();

            return View(diaryVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddLogToDiary(DiaryViewModel diaryVM)
        {
            var logBook = await _logbookService.GetLogBookById(diaryVM.NewLog.LogbookId);
            if (logBook == null)
            {
                ErrorViewModel error = new ErrorViewModel { Message = "Logbook not found" } ;
                return View("Error", error);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ErrorViewModel error = new ErrorViewModel { Message = "AppUser not found" };
                return View("Error", error);
            }

            Log newLog = new Log();

            newLog.LogTime = diaryVM.NewLog.DateAndTime;
            newLog.Value1 = diaryVM.NewLog.Value1;
            newLog.Value2 = diaryVM.NewLog.Value2;
            newLog.Value3 = diaryVM.NewLog.Value3;
            newLog.Comment = diaryVM.NewLog.Comment;
            //newLog.Comment = diaryVM.NewLog.DateAndTime + "";
            newLog.LogBook = logBook;

            var result = await _logsService.AddNewLog(
                                         newLog.LogBook.LogBookId,
                                         user.Id,
                                         newLog.LogTime,
                                         newLog.Value1,
                                         newLog.Value2,
                                         newLog.Value3,
                                         newLog.Comment);
            if (result == false)
            {
                ErrorViewModel error = new ErrorViewModel { Message = "Adding log failed" };
                return View("Error", error);
            }

            return RedirectToAction(nameof(Diary), new { logbookId = logBook.LogBookId});
        }


        public async Task<IActionResult> DeleteLog(int logId)
        {
            var log = await _logsService.GetLogByIdAsync(logId);
            if (log != null)
            {
                var result = _logsService.RemoveLogAsync(log);
                return RedirectToAction(nameof(Diary), new {logbookId = log.LogBook.LogBookId});
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
