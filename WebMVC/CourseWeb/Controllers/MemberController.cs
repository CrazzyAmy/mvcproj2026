using Microsoft.AspNetCore.Mvc;

namespace CourseWeb.Controllers
{
    public class MemberController : Controller
    {
        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
