using Microsoft.AspNetCore.Mvc;

namespace Odato_UserManagement.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
