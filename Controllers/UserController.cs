using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odato_UserManagement.Context;
using Odato_UserManagement.Models;

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
        //Update
        public IActionResult Update(int id)
        {
            Person person = _context.People.Include(p => p.User).FirstOrDefault(x => x.Id == id);

            return PartialView(person);
        }
        //Update Process
        public IActionResult UpdateProcess(Person person)
        {
            person.DateUpdated = DateTime.Now;

            _context.Update(person);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        //Delete Process
        public IActionResult Delete(int id)
        {
            Person person = _context.People.Include(p => p.User).FirstOrDefault(x => x.Id == id);

            if (person is null) return Json(new { success = false, message = "Error! Record not found please try again" });

            _context.Remove(person);
            _context.SaveChanges();

            return Json(new { success = true, message = "Record successfully removed!" });
        }
    }
}
