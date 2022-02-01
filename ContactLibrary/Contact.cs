using System.ComponentModel.DataAnnotations;

namespace Domain
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
        public int Id { get; set; }

        /// <summary>
        /// Фамилия контакта
        /// </summary>
        [Required(ErrorMessage ="Укажите фамилию!")]
        [StringLength(20, ErrorMessage = "Длинна строки не должна привышать 20 символов")]
        [RegularExpression(@"[A-Z|А-Я]{1}[a-z|а-я]{1}[a-z|а-я]*", 
            ErrorMessage ="Фамилия должна начинаться с заглавной буквы и включать в себя только алфавитные символы!")]
        public string LastName { get; set; }

        /// <summary>
        /// Имя контакта
        /// </summary>
        [Required(ErrorMessage ="Укажите имя!")]
        [StringLength(20, ErrorMessage = "Длинна строки не должна привышать 20 символов")]
        [RegularExpression(@"[A-Z|А-Я]{1}[a-z|а-я]{1}[a-z|а-я]*",
            ErrorMessage = "Имя должно начинаться с заглавной буквы и включать в себя только алфавитные символы!")]
        public string FirstName { get; set; }

        /// <summary>
        /// Контактный телефон
        /// </summary>
        [Required(ErrorMessage = "Укажите контактный телефон!")]
        [RegularExpression(@"[0-9]{1}[\s][(][0-9]{3}[)][\s][0-9]{2}[-][0-9]{2}[-][0-9]{3}",
            ErrorMessage = "Номер должен соответствовать формату: Х (ХХХ) ХХ-ХХ-ХХХ")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Адресс контакта
        /// </summary>
        [Required(ErrorMessage ="Укажите Email адрес!")]
        [EmailAddress(ErrorMessage ="Email адресс указан некоректно!")]
        public string Address { get; set; }

        /// <summary>
        /// Примечание к контакту
        /// </summary>
        public string Description { get; set; }
    }
}
