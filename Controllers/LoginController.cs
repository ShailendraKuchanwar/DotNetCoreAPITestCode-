using Microsoft.AspNetCore.Mvc;

namespace ATMDotNetCoreApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginUser()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
