using Microsoft.AspNetCore.Mvc;

namespace Odato_UserManagement.Controllers
{
    public class UserController : Controller
    {
        //Fields
        private readonly MyDBContext _context;

        //Constructor
        public UserController(MyDBContext context)
        {
            _context = context;
        }

        //Index
        public IActionResult Index()
        {
            return View();
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
