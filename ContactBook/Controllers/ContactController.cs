using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ContactBook.Models;

namespace ContactBook.Controllers
{
    public class ContactController : Controller
    {
        ContactContext db;
        public static List<Contact> contactsCash = new List<Contact>();

        public ContactController(ContactContext context)
        {
            this.db = context;
        }

        public IActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        public IActionResult findByName(string name)
        {
            if(name == null)
            {
                return Json(null);
            }

            Contact contact;
            var resultCash = contactsCash.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            if (resultCash == null)
            {
                contact = db.Contacts.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
                if(contact != null)
                {
                    contactsCash.Add(contact);
                }
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
