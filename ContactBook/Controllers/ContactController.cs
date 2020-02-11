using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ContactBook.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactBook.Controllers
{
    public class ContactController : Controller
    {
        ContactContext db;

        public static List<Contact> contactsCash = new List<Contact>();

        public ContactController(ContactContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        public IActionResult findByName(string name)
        {
            Contact contact;

            var resultCash = contactsCash.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            if(resultCash == null)
            {
                contact = db.Contacts.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
                contactsCash.Add(contact);
            }
            else
            {
                contact = resultCash;
            }

            return Json(contact);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
