using Microsoft.AspNetCore.Mvc;
using StateManagement.Data;
using StateManagement.Models;
using System.Diagnostics;

namespace StateManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "Rabi");
            HttpContext.Session.SetInt32("Age", 12);

            TempData["UserId"] = 101;

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("UserName", "Harish", option);


            return View();
        }
        public IActionResult Student()
        {
            StudentData newUser = new StudentData
            {
                Name = HttpContext.Session.GetString("Name"),
                Age = HttpContext.Session.GetInt32("Age").Value
            };
            string userName = Request.Cookies["UserName"];
            TempData["UserName"] = userName;
            return View(newUser);
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