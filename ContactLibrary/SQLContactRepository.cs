using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibrary
{
    public class SQLContactRepository : IRepository<Contact>
    {
        private ContactContext contactContext; // Контекст данных

        /// <summary>
        /// Конструктор определяет контекст данных с помощью DI
        /// </summary>
        /// <param name="cc"></param>
        public SQLContactRepository(ContactContext cc)
        {
            contactContext = cc;
        }

        public void Create(Contact item)
        {
            contactContext.Add(item);
        }

        public void Delete(Contact item)
        {
            contactContext.Remove(item);
        }

        public IEnumerable<Contact> GetList()
        {
            return contactContext.Contacts;
        }

        public Contact Get(int? id)
        {
            return contactContext.Contacts.Find(id);
        }

        public void Save()
        {
            contactContext.SaveChanges();
        }

        public void Update(Contact item)
        {
            contactContext.Contacts.Update(item);
        }
    }
}
