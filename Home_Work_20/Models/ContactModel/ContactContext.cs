using Microsoft.EntityFrameworkCore;

namespace Home_Work_20.Models.ContactModel
{
    /// <summary>
    /// Контекст для класса Contact
    /// </summary>
    public class ContactContext : DbContext
    {
        /// <summary>
        /// Набор данных из БД
        /// </summary>
        public DbSet<Contact> Contacts { get; set;}

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
