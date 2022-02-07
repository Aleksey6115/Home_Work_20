using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class ContactContext : DbContext
    {
        /// <summary>
        /// Набор данных из БД
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Конструктор создаёт базу данных
        /// </summary>
        /// <param name="options"></param>
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
