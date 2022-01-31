using ContactLibrary;
using System.Collections.Generic;

namespace Home_Work_20.Services
{
    /// <summary>
    /// Сервис для работы с репозиторием
    /// </summary>
    public class SQLContactService
    {
        private IRepository<Contact> _contactRepository;

        /// <summary>
        /// Сервис регестрируется с помощью DI
        /// </summary>
        /// <param name="contact"></param>
        public SQLContactService(IRepository<Contact> contact) { _contactRepository = contact; }

        /// <summary>
        /// Добавление нового контакта
        /// </summary>
        /// <param name="contact"></param>
        public void Create(Contact contact)
        {
            _contactRepository.Create(contact);
            _contactRepository.Save();
        }

        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="contact"></param>
        public void Delete(Contact contact)
        {
            _contactRepository.Delete(contact);
            _contactRepository.Save();
        }

        /// <summary>
        /// Вернуть все контакты
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetList()
        {
            return _contactRepository.GetList();
        }

        /// <summary>
        /// Вернуть конкретный контакт
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact Get(int? id)
        {
            return _contactRepository.Get(id);
        }

        /// <summary>
        /// Редактировать контакт
        /// </summary>
        /// <param name="contact"></param>
        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
            _contactRepository.Save();
        }
    }
}
