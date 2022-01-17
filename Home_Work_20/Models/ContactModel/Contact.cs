using System.ComponentModel.DataAnnotations;

namespace Home_Work_20.Models.ContactModel
{
    /// <summary>
    /// Класс отображает сущность "Контакт"
    /// По классу строится таблица БД EF
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Идентификатор контакта
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// Фамилия контакта
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Имя контакта
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Контактный телефон
        /// </summary>
        [Required]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Адресс контакта
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Примечание к контакту
        /// </summary>
        public string Description { get; set; }
    }
}
