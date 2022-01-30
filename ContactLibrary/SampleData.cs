using System.Linq;

namespace ContactLibrary
{
    /// <summary>
    /// Класс для добавления данных в пустую таблицу
    /// </summary>
    public static class SampleData
    {
        /// <summary>
        /// Если БД пуста метод создаёт 2 записи
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(ContactContext context)
        {
            if (!context.Contacts.Any())
            {
                context.Contacts.AddRange(
                    new Contact
                    {
                        LastName = "Иванов",
                        FirstName = "Иван",
                        ContactPhone = "8 (345) 23-23-564",
                        Address = "ivan@gmail.com",
                        Description = "Реальный пацан"
                    },
                    new Contact
                    {
                        LastName = "Петрович",
                        FirstName = "Пётр",
                        ContactPhone = "8 (123) 98-43-877",
                        Address = "petr@gmail.com",
                        Description = "Так себе пацан"
                    });

                context.SaveChanges();
            }
        }
    }
}
