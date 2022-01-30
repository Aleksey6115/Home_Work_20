using Home_Work_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContactLibrary;

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

        [HttpGet]
        /// <summary>
        /// Отображения на View списка контактов
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(contactContext.Contacts.ToList());
        }

        [HttpGet]
        /// <summary>
        /// Показать информацию о контакте
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Show(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            foreach(var contact in contactContext.Contacts)
            {
                if (contact.Id == id) return View(contact);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Открыть страницу "Добавить контакт"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        /// <summary>
        /// Добавление нового контакта
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="contactPhone"></param>
        /// <param name="address"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactContext.Add(contact);
                contactContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Удалить выбранный контакт
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteContact(Contact contact)
        {
            contactContext.Remove(contact);
            contactContext.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Открыть страницу для редактирования
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditContact(int? id)
        {
            Contact SelectedContact = contactContext.Contacts.FirstOrDefault(x=> x.Id == id);
            return View(SelectedContact);
        }

        /// <summary>
        /// Редактирования контакта
        /// </summary>
        /// <param name="ChangeContact"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditContact(Contact ChangeContact)
        {
            if (ModelState.IsValid)
            {
                contactContext.Contacts.Update(ChangeContact);
                contactContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
