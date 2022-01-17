using Home_Work_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Home_Work_20.Models.ContactModel;
using Microsoft.EntityFrameworkCore;

namespace Home_Work_20.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext contactContext; // Контекст данных

        /// <summary>
        /// Конструктор определяет контекст данных при помощи DI
        /// </summary>
        /// <param name="cc"></param>
        public HomeController(ContactContext cc)
        {
            this.contactContext = cc;
        }

        /// <summary>
        /// Отображения на View списка контактов
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(contactContext.Contacts.ToList());
        }

        public IActionResult Show(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var contact = (from c in contactContext.Contacts
                           where c.Id == id
                           select c).ToList();

            Contact SelectedContact = new Contact();

            foreach (var c in contact)
                SelectedContact = c;

            ViewBag.Id = SelectedContact.Id;
            ViewBag.LastName = SelectedContact.LastName;
            ViewBag.FirstName = SelectedContact.FirstName;
            ViewBag.Address = SelectedContact.Address;
            ViewBag.ContactPhone = SelectedContact.ContactPhone;
            ViewBag.Descrip = SelectedContact.Description;

            return View();
        }
    }
}
