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
            List<Person> people = _context.People.Include(p => p.User).ToList();
            return View(people);
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        //CreateProcess
        public IActionResult CreateProcess(Person person)
        {
            person.DateCreated = DateTime.Now;

            _context.People.Add(person);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
