using Microsoft.AspNetCore.Mvc;
using SignalRDenemeler.BL.Abstract;
using SignalRDenemeler.DAL.Models;
using SignalRDenemeler.UI.Models;
using System.Diagnostics;

namespace SignalRDenemeler.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Chat(User user)
        {
            return View(user);
        }





        [HttpPost]
        public IActionResult UserExist(User user)
        {
            if (userService.VarMi(user))
            {
                return RedirectToAction("Chat",user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }






        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
