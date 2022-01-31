using Home_Work_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContactLibrary;
using Home_Work_20.Services;

namespace Home_Work_20.Controllers
{
    public class HomeController : Controller
    {
        private SQLContactService contactService;

        public HomeController(SQLContactService scs) { contactService = scs; }

        [HttpGet]
        /// <summary>
        /// Отображения на View списка контактов
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View(contactService.GetList());

        [HttpGet]
        /// <summary>
        /// Показать информацию о контакте
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Show(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            return View(contactService.Get(id));
        }

        /// <summary>
        /// Открыть страницу "Добавить контакт"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddContact() => View();

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
                contactService.Create(contact);
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
            contactService.Delete(contact);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Открыть страницу для редактирования
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditContact(int? id) => View(contactService.Get(id));

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
                contactService.Update(ChangeContact);
            }

            return RedirectToAction("Index");
        }
    }
}
