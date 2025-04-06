﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Odato_UserManagement.Context;
using Odato_UserManagement.Models;
using System.Security.Cryptography;
using System.Text;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //CreateProcess
        public IActionResult Create(Person person)
        {
            if(!ModelState.IsValid) return View(person);

            person.DateCreated = DateTime.Now;

            _context.People.Add(person);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        //Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            Person person = _context.People.Include(p => p.User).FirstOrDefault(x => x.Id == id);

            return View(person);
        }
        //Update Process
        public IActionResult Update(Person person)
        {
            //Validate
            if (!ModelState.IsValid)
            {
                return View(person);
            }
   
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

        //Test incryption

        //private byte[] CalculateSHA256(string str)
        //{
        //    SHA256 sha256 = SHA256Managed.Create();
        //    byte[] hashValue;
        //    UTF8Encoding objUtf8 = new UTF8Encoding();
        //    hashValue = sha256.ComputeHash(objUtf8.GetBytes(str));

        //    return hashValue;
        //}
    }
}
