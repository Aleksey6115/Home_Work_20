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
        private IRepository<Contact> contactRepository;

        /// <summary>
        /// Механизм DI сам подставит зарегестрированную реализацию
        /// </summary>
        /// <param name="rep"></param>
        public HomeController(IRepository<Contact> rep) { contactRepository = rep; }

        [HttpGet]
        /// <summary>
        /// Отображения на View списка контактов
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View(contactRepository.GetList());

        [HttpGet]
        /// <summary>
        /// Показать информацию о контакте
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Show(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            return View(contactRepository.Get(id));
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
                contactRepository.Create(contact);
                contactRepository.Save();
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
            contactRepository.Delete(contact);
            contactRepository.Save();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Открыть страницу для редактирования
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditContact(int? id) => View(contactRepository.Get(id));

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
                contactRepository.Update(ChangeContact);
                contactRepository.Save();
            }

            return RedirectToAction("Index");
        }
    }
}
