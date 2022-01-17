using System.Linq;

namespace Home_Work_20.Models.ContactModel
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
                        ContactPhone = "8(345) 234-23-56",
                        Address = "Улица Ивановская",
                        Description = "Реальный пацан"
                    },
                    new Contact
                    {
                        LastName = "Петрович",
                        FirstName = "Пётр",
                        ContactPhone = "8(123) 987-43-87",
                        Address = "Улица Петровская",
                        Description = "Так себе пацан"
                    });

                context.SaveChanges();
            }
        }
    }
}
